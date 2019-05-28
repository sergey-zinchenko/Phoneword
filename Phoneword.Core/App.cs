using MvvmCross.ViewModels;
using MvvmCross;
using System;
using System.Collections.Generic;
using System.Text;
using Phoneword.Core.Services;
using Phoneword.Core.ViewModels;

namespace Phoneword.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<ITranslationService, TranslationServiceImpl>();

            RegisterAppStart<MainViewModel>();
        }
    }
}
