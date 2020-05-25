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
    /// Logika interakcji dla klasy PojazdMechanikPage.xaml
    /// </summary>
    public partial class PojazdMechanikPage : Page
    {
        DBConnection con = new DBConnection();
        /// <summary>
        /// Initializes a new instance of the <see cref="PojazdMechanikPage"/> class.
        /// </summary>
        public PojazdMechanikPage()
        {
            InitializeComponent();
            loadVehicle();
        }

        /// <summary>
        /// Loads vehicles to the table with the "oczekuję na naprawę" and "W naprawię" wave
        /// </summary>
        private void loadVehicle()
        {
            //this.pojazdGrid.ItemsSource = this.con.POJAZD.Join(this.con.HISTORIA_NAPRAW, poj => poj.ID, hp => hp.ID_POJAZD, (poj, hp) =>
            //new { poj.ID, poj.NR_REJESTRACYJNY, poj.ROK_PRODUKCJI, poj.CZY_SPECJALNY, poj.STATUS, hp.DO_KIEDY }).Where(poj => poj.STATUS == "W naprawie").Where(hp => hp.DO_KIEDY == null).ToList();
            this.pojazdGrid.ItemsSource = this.con.POJAZD.Where(poj => poj.STATUS == "W naprawie").ToList();
        }

        /// <summary>
        /// Handles the Click event of the Cassacion control. Changes the status of the vehicle from "w naprawie" to "Do kasacji". It does an update on the associative table specifying the end of the repair period.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Cassacion_Click(object sender, RoutedEventArgs e)
        {
            dynamic obj = this.pojazdGrid.SelectedValue;
            if (obj.STATUS != "W naprawie")
            {
                MessageBox.Show("Najpierw przyjmij pojazd do naprawy!");
            }
            else
            {
                int pojazdID = obj.ID;
                POJAZD newPojazd = (POJAZD)con.POJAZD.Where(poj => poj.ID == pojazdID).First();
                newPojazd.STATUS = "Do kasacji";
                con.POJAZD.Attach(newPojazd);
                con.Entry(newPojazd).Property(poj => poj.STATUS).IsModified = true;

                HISTORIA_NAPRAW historia = (HISTORIA_NAPRAW)con.HISTORIA_NAPRAW.Where(hn => hn.ID_POJAZD == pojazdID && hn.DO_KIEDY == null).First();
                historia.DO_KIEDY = DateTime.Now;
                con.HISTORIA_NAPRAW.Attach(historia);
                con.Entry(historia).Property(x => x.DO_KIEDY).IsModified = true;

                con.SaveChanges();
                loadVehicle();
                MessageBox.Show("Pojazd przeznaczony do kasacji");
            }
        }

        /// <summary>
        /// Handles the Click event of the Repair control. Changes the status of the vehicle from "w naprawie" to "Sprawny". It does an update on the associative HISTORY_NAPRAW table specifying the end of the repair period.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            dynamic obj = this.pojazdGrid.SelectedValue;
            if (obj.STATUS != "W naprawie")
            {
                MessageBox.Show("Najpierw przyjmij pojazd do naprawy!");
            }
            else
            {
                int pojazdID = obj.ID;

                POJAZD newPojazd = (POJAZD)con.POJAZD.Where(poj => poj.ID == pojazdID).First();
                newPojazd.STATUS = "Sprawny";
                con.POJAZD.Attach(newPojazd);
                con.Entry(newPojazd).Property(poj => poj.STATUS).IsModified = true;

                HISTORIA_NAPRAW historia = (HISTORIA_NAPRAW)con.HISTORIA_NAPRAW.Where(hn => hn.ID_POJAZD == pojazdID && hn.DO_KIEDY == null).First();
                historia.DO_KIEDY = DateTime.Now;
                con.HISTORIA_NAPRAW.Attach(historia);
                con.Entry(historia).Property(x => x.DO_KIEDY).IsModified = true;

                con.SaveChanges();
                loadVehicle();
                MessageBox.Show("Pojazd naprawiony, oddany do użytku.");
            }
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
    }
}
