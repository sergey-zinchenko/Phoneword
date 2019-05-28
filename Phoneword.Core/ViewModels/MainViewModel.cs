using MvvmCross.ViewModels;
using Phoneword.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Core.ViewModels
{
    class MainViewModel : MvxViewModel
    {
        readonly ITranslationService _translationService;

        public MainViewModel(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _phoneNumberText = "adgjmptw";
            Translate();
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

        private void Translate()
        {
            TranslatedPhoneword = _translationService.ToNumber(_phoneNumberText);
        }
    }
}
