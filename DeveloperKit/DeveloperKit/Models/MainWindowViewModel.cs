using System.Windows.Input;
using DeveloperKit.Command;

namespace DeveloperKit.Models
{
    public class MainWindowViewModel:ViewModelBase
    {
        public ICommand JavaConfigCommand
        {
            get
            {
                return new DelegateCommand<object>((obj) =>
                {
                    Views.JAVAConfig.Window1 view = new Views.JAVAConfig.Window1();
                    view.DataContext = new JavaConfigViewModel();
                    view.ShowDialog();
                });
            }
        }

        public ICommand CreateCodeCommand
        {
            get
            {
                return new DelegateCommand<object>((obj) =>
                {
                    Views.CreateCode.Form1 view = new Views.CreateCode.Form1();
                    view.ShowDialog();
                });
            }
        }
    }
}