using MvvmCross;
using MvvmCross.Core;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Presenters;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using Phoneword.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.GTK;

namespace Phoneword.Forms.GtkLauncher
{
    class MainClass
    {
 

        [STAThread]
        public static void Main(string[] args)
        {
            Gtk.Application.Init();
           
            var setup = new MySetup<UI.FormsApp, Phoneword.Core.App>();
            setup.InitializePrimary();
            setup.InitializeSecondary();
            var window = new FormsWindow();
            window.SetApplicationTitle("XamarinFormsGtkLauncher");
            window.Show();
            window.LoadApplication(setup.FormsApplication);
            setup.FormsApplication.SendStart();
            var l = new MvxViewModelByNameLookup();
            Type t;
            var b = l.TryLookupByName("MainView", out t);
            if (Mvx.IoCProvider.TryResolve(out IMvxAppStart startup) && !startup.IsStarted)
                startup.Start();
            
           
           
           
            Gtk.Application.Run();
        }
    }

    class MySetup<T1, T2> : MvxSetup, IMvxFormsSetup where T1 : Xamarin.Forms.Application, new() where T2 : MvxApplication
    {
        private Xamarin.Forms.Application _formsApplication;

        public MySetup()
        {
          
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsSetup>(this);
        }
        public virtual Xamarin.Forms.Application FormsApplication
        {
            get
            {
                if (!Xamarin.Forms.Forms.IsInitialized)
                    Xamarin.Forms.Forms.Init();
                if (_formsApplication == null)
                {
                    _formsApplication = CreateFormsApplication();
                }
                return _formsApplication;
            }
        }

        protected Xamarin.Forms.Application CreateFormsApplication() => new T1();

        protected override IMvxApplication CreateApp() => Mvx.IoCProvider.IoCConstruct<T2>();


        protected override IMvxViewsContainer CreateViewsContainer()
        {
            return new MyViewsContainer();
        }
    

        protected override IMvxViewDispatcher CreateViewDispatcher()
        {
            return new MyViewDispatcher();
        }

        protected override IMvxNameMapping CreateViewToViewModelNaming()
        {
            return new MyMvxNameMapping();
        }
    }

    class MyViewsContainer : IMvxViewsContainer
    {
        public void Add(Type viewModelType, Type viewType)
        {
            throw new NotImplementedException();
        }

        public void Add<TViewModel, TView>()
            where TViewModel : IMvxViewModel
            where TView : IMvxView
        {
            throw new NotImplementedException();
        }

        public void AddAll(IDictionary<Type, Type> viewModelViewLookup)
        {
        //    throw new NotImplementedException();
        }

        public void AddSecondary(IMvxViewFinder finder)
        {
            throw new NotImplementedException();
        }

        public Type GetViewType(Type viewModelType)
        {
            throw new NotImplementedException();
        }

        public void SetLastResort(IMvxViewFinder finder)
        {
            throw new NotImplementedException();
        }
    }

    class MyViewDispatcher : IMvxViewDispatcher
    {
        public bool IsOnMainThread => throw new NotImplementedException();

        public Task<bool> ChangePresentation(MvxPresentationHint hint)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteOnMainThreadAsync(Action action, bool maskExceptions = true)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteOnMainThreadAsync(Func<Task> action, bool maskExceptions = true)
        {
            throw new NotImplementedException();
        }

        public bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ShowViewModel(MvxViewModelRequest request)
        {
            throw new NotImplementedException();
        }
    }
    class MyMvxNameMapping : IMvxNameMapping
    {
        public string Map(string inputName)
        {
            throw new NotImplementedException();
        }
    }
}
