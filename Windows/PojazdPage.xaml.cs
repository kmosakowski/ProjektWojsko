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
    public partial class PojazdPage : Page
    {
        DBConnection con = new DBConnection();
        /// <summary>
        /// Initializes a new instance of the <see cref="PojazdPage"/> class.
        /// </summary>
        public PojazdPage()
        {
            InitializeComponent();
            loadSoldier();
            loadVehicle();
        }

        public void loadSoldier()
        {
            this.comboZolnierz.ItemsSource = this.con.OSOBA.Where(os => os.FUNKCJA == EnumOsoba.Żołnierz.ToString()).ToList();
            this.comboZolnierz.DisplayMemberPath = "NAZWISKO";
            this.comboZolnierz.SelectedValuePath = "ID";
        }

        /// <summary>
        /// Charges vehicles to the table with each wave
        /// </summary>
        private void loadVehicle()
        {
            this.pojazdGrid.ItemsSource = this.con.POJAZD.Join(this.con.OSOBA, poj => poj.ID_OSOBA,
            os => os.ID, (poj, os) => new { poj.NR_REJESTRACYJNY, poj.ROK_PRODUKCJI, poj.CZY_SPECJALNY, poj.STATUS, poj.ID, ID_OSOBA = os.ID }).ToList();
        }

        private void Pokaz_Click(object sender, RoutedEventArgs e)
        {

            loadSoldierVehicle(((OSOBA)comboZolnierz.SelectedItem));
        }

        private void loadSoldierVehicle(OSOBA Osoba)
        {
            this.pojazdGrid.ItemsSource = Osoba.POJAZD;
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
        /// Handles the Click event of the Report control. Changes the status of the vehicle with "Sprawny" to "Oczekuję na naprawę"
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            if(pojazdGrid.SelectedIndex > -1)
            {
                dynamic obj = this.pojazdGrid.SelectedValue;
                int pojID = obj.ID;
                int osID = obj.ID_OSOBA;
                if (obj.STATUS == "Do kasacji")
                {
                    MessageBox.Show("Ten pojazd jest przeznaczony do kasacji.");
                }
                else if (obj.STATUS == "W naprawie")
                {
                    MessageBox.Show("Ten pojazd jest już w naprawie");
                }
                else if (obj.STATUS == "Oczekuje na naprawę")
                {
                    MessageBox.Show("Ten pojazd już został zgłoszony");
                }
                else
                {
                    int idPrzeglad = con.PRZEGLAD.Select(h => h.ID).DefaultIfEmpty(0).Max() + 1;
                    PRZEGLAD newPrzeglad = new PRZEGLAD(idPrzeglad);
                    con.PRZEGLAD.Add(newPrzeglad);

                    //con.Entry<PRZEGLAD>(newPrzeglad).State = System.Data.Entity.EntityState.Added;

                    int idHistoriaNapraw = con.HISTORIA_NAPRAW.Select(h => h.ID).DefaultIfEmpty(0).Max() + 1;
                    HISTORIA_NAPRAW newHistoriaNapraw = new HISTORIA_NAPRAW(idHistoriaNapraw, DateTime.Now, obj.ID, idPrzeglad);
                    con.HISTORIA_NAPRAW.Add(newHistoriaNapraw);

                    //con.Entry<HISTORIA_NAPRAW>(newHistoriaNapraw).State = System.Data.Entity.EntityState.Added;

                    POJAZD newPojazd = (POJAZD)con.POJAZD.Where(poj => poj.ID == pojID).First();
                    newPojazd.STATUS = "W naprawie";
                    con.POJAZD.Attach(newPojazd);
                    con.Entry(newPojazd).Property(poj => poj.STATUS).IsModified = true;
                    con.SaveChanges();
                    loadVehicle();

                    //con.Entry<PRZEGLAD>(newPrzeglad).State = System.Data.Entity.EntityState.Detached;
                    //con.Entry<HISTORIA_NAPRAW>(newHistoriaNapraw).State = System.Data.Entity.EntityState.Detached;

                    con.Entry<POJAZD>(newPojazd).State = System.Data.Entity.EntityState.Detached;
                    MessageBox.Show("Zgłoszono Pojazd do naprawy");
                }
            }
            
        }

        /// <summary>
        /// Handles the Click event of the Assign control. Opens a new window in which you can create a new object of the POJAZD class and link it to the right person.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Assign_Click(object sender, RoutedEventArgs e)
        {
            new PrzydzielPojazd().ShowDialog();
            loadVehicle();
        }
    }
}
