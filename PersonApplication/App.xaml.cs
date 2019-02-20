using PersonApplication.Login;
using System.Windows;

namespace PersonApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            base.OnStartup(e);

            var loginViewModel = new LoginViewModel();
            var loginView = new LoginView(loginViewModel);

            loginView.ShowDialog();
            if (loginViewModel.IsUserAuthenticated)
            {
                new Bootstrapper().Run();
                return;
            }
            Current.Shutdown();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
