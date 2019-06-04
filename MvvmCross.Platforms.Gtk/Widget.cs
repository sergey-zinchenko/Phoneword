using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using System;

namespace MvvmCross.Platforms.GTK
{
    public class Widget<TViewModel> : Gtk.Widget, IMvxView, IMvxDataConsumer, IMvxBindingContextOwner, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
    {
        public Widget(string gladeFile)
        {
            
        }
        public IMvxBindingContext BindingContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TViewModel ViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object DataContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IMvxViewModel IMvxView.ViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
