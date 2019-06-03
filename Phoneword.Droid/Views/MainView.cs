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
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Views;
using Phoneword.Core.ViewModels;

namespace Phoneword.Droid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = false)]
    public class MainView : MvxAppCompatActivity<MainViewModel>
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
                    ViewModel.ShowHistoryCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}