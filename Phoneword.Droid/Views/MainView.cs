using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using Phoneword.Core.ViewModels;

namespace Phoneword.Droid.Views
{
    [Activity(Label = "Tip Calculator", MainLauncher = true)]
    public class MainView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.about_item:
                    ViewModel.ShowAboutCommand.Execute();
                    return true;
                case Resource.Id.history_item:
                    //Bundle bundle = new Bundle();
                    //bundle.PutStringArray(BUNDLE_HISTORY_KEY, history.ToArray());
                    //intent = new Intent(this, typeof(HistoryActivity));
                    //intent.PutExtras(bundle);
                    //StartActivityForResult(intent, HISTORY_REQ_CODE);
                    ViewModel.ShowHistoryCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}