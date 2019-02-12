using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using StudentRecord;
using System;
using Data;

namespace PersonApplication
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            base.CreateShell();
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            Type reportModule = typeof(RecordModule);
            ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo { ModuleName = reportModule.Name, ModuleType = reportModule.AssemblyQualifiedName });
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            new Provider();
        }
    }
}
