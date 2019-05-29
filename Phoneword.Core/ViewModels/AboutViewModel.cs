using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Core.ViewModels
{
    public class AboutViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand OkClickCommand { get; private set; }

        public AboutViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            OkClickCommand = new MvxAsyncCommand(async () => await _navigationService.Close(this));
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }
    }
}
