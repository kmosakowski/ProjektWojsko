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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektWojsko.Windows
{

    public partial class StartPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartPage"/> class.
        /// </summary>
        public StartPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the VehicleButton control. Specifies the display of the appropriate layout for a particular user when calling the "Pojazdy" button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void VehicleButton_Click(object sender, RoutedEventArgs e)
        {
            switch (MainWindow.modeView)
            {
                case MainWindow.mode.soldier:
                    this.NavigationService.Navigate(new PojazdPage());
                    break;
                case MainWindow.mode.civilian:
                    //this.NavigationService.Navigate(new PojazdPage());
                    break;
                case MainWindow.mode.mechanic:
                    this.NavigationService.Navigate(new PojazdMechanikPage());
                    break;
                case MainWindow.mode.commander:
                    this.NavigationService.Navigate(new PojazdPage());
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the Person control. Specifies the display of the appropriate layout for a particular user when calling the "Stan osobowy" button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Person_Click(object sender, RoutedEventArgs e)
        {
            switch (MainWindow.modeView)
            {
                case MainWindow.mode.soldier:
                    //this.NavigationService.Navigate(new OsobaPage());
                    break;
                case MainWindow.mode.civilian:
                    this.NavigationService.Navigate(new OsobaPage());
                    break;
                case MainWindow.mode.mechanic:
                    //this.NavigationService.Navigate(new PojazdMechanikPage());
                    break;
                case MainWindow.mode.commander:
                    this.NavigationService.Navigate(new OsobaPage());
                    break;
            }
        }
    }
}
