using Foundation;
using Phoneword.Core;
using MvvmCross.Platforms.Ios.Core;

namespace Phoneword.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
  
    }
}