using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Phoneword.Core.ViewModels;
using System;
using UIKit;

namespace Phoneword.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController<MainViewModel>
    {

        public MainView(IntPtr handle)
           : base(handle)
        {
            Title = "Phoneword";
        }

        partial void TranslateUpInside(UIKit.UIButton sender)
        {
            ViewModel.TranslateCommand.Execute();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var rightButton = new UIBarButtonItem("Menu", UIBarButtonItemStyle.Bordered, null);
            rightButton.Clicked += MenuButtonClicked;
            NavigationItem.SetRightBarButtonItem(rightButton, false);
            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(InputField).To(vm => vm.PhoneNumberText);
            set.Bind(OutputLabel).To(vm => vm.TranslatedPhoneword);
            set.Apply();
        }

        private void MenuButtonClicked(object sender, EventArgs e)
        {
            var actionSheet = new UIActionSheet("Menu");
            actionSheet.AddButton("History");
            actionSheet.AddButton("About");
            actionSheet.AddButton("Cancel");
            actionSheet.CancelButtonIndex = 2;
            actionSheet.Clicked += delegate (object a, UIButtonEventArgs b) {
                switch (b.ButtonIndex) {
                    case 0:
                        ViewModel.ShowHistoryCommand.Execute();
                        break;
                    case 1:
                        ViewModel.ShowAboutCommand.Execute();
                        break;
                }
            };
            actionSheet.ShowInView(View);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
   
    }
}

