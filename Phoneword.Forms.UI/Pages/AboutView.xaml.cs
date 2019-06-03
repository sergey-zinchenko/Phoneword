using MvvmCross.Forms.Views;
using Phoneword.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword.Forms.UI.Pages
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutView : MvxContentPage<AboutViewModel>
    {
        public AboutView()
        {
            InitializeComponent();
        }
    }
}