using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = false)]
    public class MainActivity : AppCompatActivity
    {
        public const string BUNDLE_HISTORY_KEY = "history";
        private const int HISTORY_REQ_CODE = 202;

        EditText phoneNumberText;
        TextView translatedPhoneWord;
        List<string> history = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            translateButton.Click += (sender, e) =>
            {
                // Translate user's alphanumeric phone number to numeric
                if (!string.IsNullOrWhiteSpace(phoneNumberText.Text))
                {
                    history.Add(phoneNumberText.Text);
                    string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                    if (string.IsNullOrWhiteSpace(translatedNumber))
                    {
                        translatedPhoneWord.Text = string.Empty;
                    }
                    else
                    {
                        translatedPhoneWord.Text = translatedNumber;
                    }
                }
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Intent intent;
            switch (item.ItemId)
            {
                case Resource.Id.about_item:
                    intent = new Intent(this, typeof(AboutActivity));
                    StartActivity(intent);
                    return true;
                case Resource.Id.history_item:
                    Bundle bundle = new Bundle();
                    bundle.PutStringArray(BUNDLE_HISTORY_KEY, history.ToArray());
                    intent = new Intent(this, typeof(HistoryActivity));
                    intent.PutExtras(bundle);
                    StartActivityForResult(intent, HISTORY_REQ_CODE);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode != HISTORY_REQ_CODE || resultCode != Result.Ok)
                return;
            if (data == null)
                return;

            var phoneWord = data.GetStringExtra(HistoryActivity.PHONE_WORD_KEY);
            if (string.IsNullOrWhiteSpace(phoneWord))
            {
                phoneNumberText.Text = string.Empty;
                translatedPhoneWord.Text = string.Empty;
                return;
            }

            phoneNumberText.Text = phoneWord;
            string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneWord);
            if (string.IsNullOrWhiteSpace(translatedNumber))
            {
                translatedPhoneWord.Text = string.Empty;
            }
            else
            {
                translatedPhoneWord.Text = translatedNumber;
            }

        }
    }
}