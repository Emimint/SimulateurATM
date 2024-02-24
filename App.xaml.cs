using SimulateurATM.Controllers;
using SimulateurATM.Views;

namespace SimulateurATM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            GuichetPage.Init();

            MainPage = new AppShell();
        }
    }
}
