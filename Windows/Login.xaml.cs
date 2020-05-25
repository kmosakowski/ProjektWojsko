using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektWojsko.Windows
{
    
    public partial class Login : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// This class is responsible for the login window
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A method allowing to determine the role of the user on the basis of which he will be able to use the system.
        /// In the future, user validation will be added.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Login_button(object sender, RoutedEventArgs e)
        {
            if (this.rola.SelectedIndex > -1)
            {
                ComboBoxItem s = (ComboBoxItem)this.rola.SelectedValue;
                switch (s.Content.ToString())
                {
                    case "Żołnierz":
                        MainWindow.modeView = MainWindow.mode.soldier;
                        break;
                    case "Cywil":
                        MainWindow.modeView = MainWindow.mode.civilian;
                        break;
                    case "Mechanik":
                        MainWindow.modeView = MainWindow.mode.mechanic;
                        break;
                    case "Dowódca":
                        MainWindow.modeView = MainWindow.mode.commander;
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Zaznacz rolę z jaką się logujesz");
            }
        }
    }
}
