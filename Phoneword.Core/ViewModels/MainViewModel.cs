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
        readonly ITranslationService _translationService;
        private readonly IMvxNavigationService _navigationService;

        public IMvxCommand ShowHistoryCommand { get; private set; }
        public IMvxCommand ShowAboutCommand { get; private set; }
        public IMvxCommand TranslateCommand { get; private set; }

        List<string> history = new List<string>();

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
            PhoneNumberText = await _navigationService.Navigate<HistoryViewModel, List<string>, string>(history);
        }

        private void Translate()
        {
            history.Add(_phoneNumberText);
            TranslatedPhoneword = _translationService.ToNumber(_phoneNumberText);
        }
    }
}
