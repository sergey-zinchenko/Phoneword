
using System;
using System.Drawing;

using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Phoneword.Core.ViewModels;
using UIKit;

namespace Phoneword.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class AboutView : MvxViewController<AboutViewModel>
    {
        public AboutView(IntPtr handle) : base(handle)
        {
            Title = "About";
        }

        partial void OkUpInside(UIKit.UIButton sender)
        {
            ViewModel.OkClickCommand.Execute();
        }
    }
}