using SimulateurATM.Views;

namespace SimulateurATM
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Register all routes
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("guichet", typeof(GuichetPage));
            Routing.RegisterRoute("logout", typeof(LogoutPage));
            Routing.RegisterRoute("account", typeof(AccountPage));
        }
    }
}
