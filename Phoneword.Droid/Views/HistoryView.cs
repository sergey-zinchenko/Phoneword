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
using Phoneword.Core.ViewModels;

namespace Phoneword.Droid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class HistoryView : MvxAppCompatActivity<HistoryViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_history);
        }
    }
}