using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
//using StudentRecord;
using System;
using Data;
using Prism.Modularity;

namespace PersonApplication
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            base.CreateShell();
            Application.Current.MainWindow = Container.Resolve<MainWindow>();
            return Application.Current.MainWindow;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog
            {
                ModulePath = AppDomain.CurrentDomain.BaseDirectory + "Modules"
            };
        }

        //protected override void ConfigureModuleCatalog()
        //{
        //    base.ConfigureModuleCatalog();



        //    //Type reportModule = typeof(RecordModule);
        //    //ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo { ModuleName = reportModule.Name, ModuleType = reportModule.AssemblyQualifiedName });
        //}

        protected override void ConfigureContainer()
        {
            Provider provider = new Provider();
            base.ConfigureContainer();
            Container.RegisterInstance(provider.GetAddressRepository(), new ContainerControlledLifetimeManager());
            Container.RegisterInstance(provider.GetPersonRepository(), new ContainerControlledLifetimeManager());
        }
    }
}
