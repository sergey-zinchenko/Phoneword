using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", NoHistory = false)]
    public class AboutActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_about);
            var button = FindViewById<Button>(Resource.Id.OkButton);
            button.Click += OkClick;
        }

        private void OkClick(object sender, EventArgs e)
        {
            Finish();
        }
    }
}