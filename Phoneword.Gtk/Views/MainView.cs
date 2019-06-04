using Phoneword.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Gtk.Views
{
    class MainView : MvvmCross.Platforms.GTK.Widget<MainViewModel>
    {
        public MainView(): base("xyz")
        { }
    }
}
