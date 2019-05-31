using Foundation;
using UIKit;
using Phoneword.Core;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using MvvmCross;

namespace Phoneword.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
  
    }
}