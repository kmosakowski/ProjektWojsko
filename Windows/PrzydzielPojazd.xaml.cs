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
using ProjektWojsko.Models;
using ProjektWojsko.Windows;

namespace ProjektWojsko.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy PrzydzielPojazd.xaml
    /// </summary>
    public partial class PrzydzielPojazd : Window
    {
        DBConnection con = new DBConnection();
        /// <summary>
        /// Initializes a new instance of the <see cref="PrzydzielPojazd"/> class.
        /// </summary>
        public PrzydzielPojazd()
        {
            InitializeComponent();
            loadSoldiers();
        }
        /// <summary>
        /// Loads the soldiers to ComboBox and complementing the others ComboBox like as Special vehicle and status for vehicle.
        /// </summary>
        public void loadSoldiers()
        {
            this.przydzielComboBox.ItemsSource = this.con.OSOBA.Where(os => os.FUNKCJA == EnumOsoba.Żołnierz.ToString()).ToList();
            this.przydzielComboBox.DisplayMemberPath = "NAZWISKO";
            this.przydzielComboBox.SelectedValuePath = "ID";

            this.specjalnyComboBox.ItemsSource = new List<String>(){ "Y", "N" };
            this.statusComboBox.ItemsSource = new List<String>() { "Sprawny"};

        }

        /// <summary>
        /// Handles the Click event of the CreateVehivle control. He creates a new vehicle and connects him with a person. It also creates an object of the HISTORI_POJAZDU class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CreateVehivle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dataRejestracji = Convert.ToDateTime(rokProdukcjiTextBox.Text);
                int idPojazdu = con.POJAZD.Max(poj => poj.ID) + 1;
                POJAZD newPojazd = new POJAZD(idPojazdu, nrRejestracyjnyTextBox.Text, dataRejestracji, specjalnyComboBox.SelectedValue.ToString(), statusComboBox.SelectedValue.ToString(), ((OSOBA)przydzielComboBox.SelectedItem).ID);
                con.POJAZD.Add(newPojazd);
                con.SaveChanges();
                this.Close();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Taki pojazd już istnieje!");
            }
        }
        
        /// <summary>
        /// Handles the Click event of the Close control. Close the windows
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
