using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phoneword.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly ITranslationService _translationService;
        private readonly IMvxNavigationService _navigationService;
        private readonly List<string> _history = new List<string>();

        public IMvxCommand ShowHistoryCommand { get; private set; }
        public IMvxCommand ShowAboutCommand { get; private set; }
        public IMvxCommand TranslateCommand { get; private set; }

        

        public MainViewModel(ITranslationService translationService, IMvxNavigationService navigationService)
        {
            _translationService = translationService;
            _navigationService = navigationService;

            TranslateCommand = new MvxCommand(() => Translate(), () => true);
            ShowHistoryCommand = new MvxAsyncCommand(ShowHistoryTask);
            ShowAboutCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _phoneNumberText = "adgjmptw";
        }

        private string _phoneNumberText;
        public string PhoneNumberText
        {
            get => _phoneNumberText;
            set
            {
                _phoneNumberText = value;
                RaisePropertyChanged(() => PhoneNumberText);
            }
        }

        private string _translatedPhoneword;
        public string TranslatedPhoneword
        {
            get => _translatedPhoneword;
            set
            {
                _translatedPhoneword = value;
                RaisePropertyChanged(() => TranslatedPhoneword);
            }
        }

        private async Task ShowHistoryTask()
        {
            var historyWord = await _navigationService.Navigate<HistoryViewModel, List<string>, string>(_history);
            if (!string.IsNullOrWhiteSpace(historyWord))
                PhoneNumberText = historyWord;
                Translate();
        }

        private void Translate()
        {
            _history.Add(_phoneNumberText);
            TranslatedPhoneword = _translationService.ToNumber(_phoneNumberText);
        }
    }
}
