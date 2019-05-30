using Foundation;
using UIKit;
using Phoneword.Core;
using MvvmCross.Platforms.Ios.Core;

namespace Phoneword.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
        public override UIWindow Window { get; set; }

        // FinishedLaunching is the very first code to be executed in your app. Don't forget to call base!
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            return result;
        }
    }
}