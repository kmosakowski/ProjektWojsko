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
using ProjektWojsko.Models;

namespace ProjektWojsko.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaPage.xaml
    /// </summary>
    public partial class OsobaPage : Page
    {
        DBConnection con = new DBConnection();
        /// <summary>
        /// Initializes a new instance of the <see cref="OsobaPage"/> class.
        /// </summary>
        public OsobaPage()
        {
            InitializeComponent();
            loadPerson();
        }

        /// <summary>
        /// Loading a list of soldiers and entering DataGrid
        /// </summary>
        public void loadPerson()
        {
            this.osobaGrid.ItemsSource = this.con.OSOBA.ToList();
        }
        
        /// <summary>
        /// Handles the Click event of the Back control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        /// <summary>
        /// Opening a new window with information about the person
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Informacje_Click(object sender, RoutedEventArgs e)
        {
            if(osobaGrid.SelectedIndex > -1)
            {
                new Informacje(((OSOBA)osobaGrid.SelectedItem)).ShowDialog();
            }
            
        }
    }
}
