using ProjektWojsko.Models;
using ProjektWojsko.Windows;
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

namespace ProjektWojsko
{
    public partial class MainWindow : Window
    {
        public enum mode {soldier, civilian,  mechanic, commander};
        /// <summary>
        /// The mode view. This field specified pages to show.
        /// </summary>
        public static mode modeView = mode.soldier;
        DBConnection con = new DBConnection();
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            new Login().ShowDialog();
            InitializeComponent();
            loadRole();
            LoadStructure();
            mainFrame.NavigationService.Navigate(new StartPage());
        }

        /// <summary>
        /// Loads the role of user and show it in window.
        /// </summary>
        public void loadRole()
        {
            switch (modeView)
            {
                case MainWindow.mode.soldier:
                    this.role.Content = "Żołnierz";
                    break;
                case MainWindow.mode.civilian:
                    this.role.Content = "Cywil";
                    break;
                case MainWindow.mode.mechanic:
                    this.role.Content = "Mechanik";
                    break;
                case MainWindow.mode.commander:
                    this.role.Content = "Dowódca";
                    break;

            }
        }
        /// <summary>
        /// Loading the structure of the unit with assigned soldiers and displaying in a tree form
        /// </summary>
        public void LoadStructure()
        {
            var jw = this.con.JEDNOSTKA_WOJSKOWA.ToList();
            foreach(JEDNOSTKA_WOJSKOWA j_w in jw)
            {
                TreeViewItem jednostkaWojskowa = new TreeViewItem();
                jednostkaWojskowa.Header = j_w.NAZWA;
                var joBatalion = this.con.JEDNOSTKA_ORGANIZACYJNA.Where(jo => jo.ID_JEDNOSTKA_ORGANIZACYJNA == null).ToList();
                foreach (JEDNOSTKA_ORGANIZACYJNA j_batalion in joBatalion)
                {
                    TreeViewItem batalion = new TreeViewItem();
                    batalion.Header = j_batalion.NAZWA;
                    foreach(JEDNOSTKA_ORGANIZACYJNA j_kompania in j_batalion.JEDNOSTKA_ORGANIZACYJNA1)
                    {
                        TreeViewItem kompania = new TreeViewItem();
                        kompania.Header = j_kompania.NAZWA;
                        foreach(JEDNOSTKA_ORGANIZACYJNA j_pluton in j_kompania.JEDNOSTKA_ORGANIZACYJNA1)
                        {
                            TreeViewItem pluton = new TreeViewItem();
                            pluton.Header = j_pluton.NAZWA;
                            foreach (JEDNOSTKA_ORGANIZACYJNA j_druzyna in j_pluton.JEDNOSTKA_ORGANIZACYJNA1)
                            {
                                TreeViewItem druzyna = new TreeViewItem();
                                druzyna.Header = j_druzyna.NAZWA;
                                pluton.Items.Add(druzyna);
                            }
                            kompania.Items.Add(pluton);
                        }
                        batalion.Items.Add(kompania);
                    }
                    jednostkaWojskowa.Items.Add(batalion);
                }
                treeView.Items.Add(jednostkaWojskowa);
            }
        }

        /// <summary>
        /// Closes the specified sender. Close the app.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the About control. Shows information about specified app case.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void About_Click(object sender, RoutedEventArgs e)
        {
            new About().ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the Soldier control. Change user for soldier
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Soldier_Click(object sender, RoutedEventArgs e)
        {
            modeView = mode.soldier;
            loadRole();
            mainFrame.NavigationService.Navigate(new StartPage());

        }

        /// <summary>
        /// Handles the Click event of the Mechanic control. Change user for mechanic
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Mechanik_Click(object sender, RoutedEventArgs e)
        {
            modeView = mode.mechanic;
            loadRole();
            mainFrame.NavigationService.Navigate(new StartPage());
        }

        /// <summary>
        /// Handles the Click event of the Civilian control. Change user for civilian
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Civilian_Click(object sender, RoutedEventArgs e)
        {
            modeView = mode.civilian;
            loadRole();
            mainFrame.NavigationService.Navigate(new StartPage());
        }

        /// <summary>
        /// Handles the Click event of the Commander control. Change user for commander
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Commander_Click(object sender, RoutedEventArgs e)
        {
            modeView = mode.commander;
            loadRole();
            mainFrame.NavigationService.Navigate(new StartPage());
        }
    }
}
