using AMS.UI.Domain.Exceptions;
using AMS.UI.Utils;
using AMS.UI.View_Models;
using AMS.UI.View_Models.Login;
using AMS.UI.UseCases.Auth;
using AMS.UI.UseCases.Loggers;
using System.Windows.Forms;
using AMS.UI.UseCases.Alerts;

namespace AMS.UI
{
    public partial class Login : Form
    {
        private LoginVM vm = new LoginVM();

        public Login()
        {
            InitializeComponent();
            LocalizeThePage();
        }

        private void txtLogin_TextChanged(object sender, System.EventArgs e)
        {
            vm.UserName.Value = txtLogin.Text;
        }

        private void txtPassword_TextChanged(object sender, System.EventArgs e)
        {
            vm.Password.Value = txtPassword.Text;
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                Store.CurrentUser = AuthService.Authenticate(
                    vm.UserName.Value,
                    vm.Password.Value
                );
                LoginLogger.LogLogin(vm.UserName.Value);
                AlertsService.AppointmentsWithIn15MinsAlerts();

                FormHelper.Open(this, new Forms.Menu());
            }
            catch (NotAuthorizedException)
            {
                MessageBox.Show($"{LanguageUtil.Translate("LoginError")}");
            }
        }

        private void LocalizeThePage()
        {
            lblWelcome.Text = LanguageUtil.Translate("Welcome");
            lblUsername.Text = LanguageUtil.Translate("Username");
            lblPassword.Text = LanguageUtil.Translate("Password");
            btnLogin.Text = LanguageUtil.Translate("Login");
            btnClose.Text = LanguageUtil.Translate("Cancel");
            this.Text = LanguageUtil.Translate("Login");
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
