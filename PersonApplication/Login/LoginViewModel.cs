using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace PersonApplication.Login
{
    public class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(LoginAction);
        }

        private void LoginAction()
        {
            IsUserAuthenticated = true;
        }

        public ICommand LoginCommand { get; set; }
        public bool IsUserAuthenticated { get; internal set; }
    }
}
