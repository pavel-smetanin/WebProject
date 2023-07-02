//Класс Веб-формы
//Стартовая страница
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butAutorise_Click(object sender, EventArgs e)
        {
            try
            {
                string login = inputLogin.Value;
                string password = inputPassword.Value;
                SecurityUtils.UserAutorisation(login, password);
                butAutorise.Enabled = false;
                Server.Transfer("ManagerPage.aspx");
            }
            catch
            {
                labelAutoriseStatus.Text = "Неверный логин и пароль";
            }

        }
    }
}