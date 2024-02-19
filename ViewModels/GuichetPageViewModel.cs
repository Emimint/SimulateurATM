using System.Windows.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SimulateurATM.ViewModels
{
    public class GuichetPageViewModel
    {
        public ICommand AddCharCommand { get; private set; }

        public GuichetPageViewModel()
        {
            AddCharCommand = new Command<string>(ExecuteAddCharCommand);
        }

        private void ExecuteAddCharCommand(string param)
        {
            textInput.Text += param;
        }
    }
}

