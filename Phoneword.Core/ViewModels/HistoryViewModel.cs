using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Core.ViewModels
{
    public class HistoryViewModel : MvxViewModel<List<string>, string>
    {
        private readonly IMvxNavigationService _navigationService;

        private List<string> _history;
        public IMvxCommand ChooseCommand { get; private set; }
        public List<string> History
        {
            get => _history;
            private set
            {
                _history = value;
                RaisePropertyChanged(() => History);
            }
        }

        public HistoryViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ChooseCommand = new MvxCommand<string>(Choose);
        }

        public override void Prepare(List<string> parameter)
        {
            _history = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public void Choose(string word)
        {
            _navigationService.Close(this, word);
        }
        
    }
}
