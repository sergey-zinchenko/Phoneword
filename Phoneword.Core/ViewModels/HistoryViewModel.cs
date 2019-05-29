using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Core.ViewModels
{
    public class HistoryViewModel : MvxViewModel<List<string>, string>
    {
        List<string> history;
        public IMvxCommand ChooseCommand;

        public HistoryViewModel()
        {
            ChooseCommand = new MvxCommand(Choose);
        }

        public override void Prepare(List<string> parameter)
        {
            history = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public void Choose()
        {

        }
        
    }
}
