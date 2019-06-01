
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Phoneword.Core.ViewModels;

namespace Phoneword.iOS.Views
{


    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class HistoryView : MvxViewController<HistoryViewModel>
    {
        public HistoryView(IntPtr handle) : base(handle)
        {
            Title = "History";
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var source = new MyTableViewSource(TableView);
            var set = this.CreateBindingSet<HistoryView, HistoryViewModel>();
            set.Bind(source).To(vm => vm.History);
            set.Apply();
            source.SelectedItemChanged += Source_SelectedItemChanged;
            TableView.Source = source;
            TableView.ReloadData();
        }

        private void Source_SelectedItemChanged(object sender, EventArgs e)
        {
            ViewModel.ChooseCommand.Execute(((MyTableViewSource)TableView.Source).SelectedItem);
        }
        #endregion
    }
}