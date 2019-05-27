using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Phoneword
{
    [Activity(Label = "@string/translation_history", Theme = "@style/AppTheme", NoHistory = false)]
    class HistoryActivity: ListActivity
    {

        string []items;

        public const string PHONE_WORD_KEY = "phone_word";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           
            items = Intent.GetStringArrayExtra(MainActivity.BUNDLE_HISTORY_KEY);
            this.ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            Intent intent = new Intent();
            Bundle bundle = new Bundle();
            bundle.PutString(PHONE_WORD_KEY, items[position]);
            intent.PutExtras(bundle);
            this.SetResult(Result.Ok, intent);
            Finish();
        }
    }
}