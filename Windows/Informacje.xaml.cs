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

namespace ProjektWojsko.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Informacje.xaml
    /// </summary>
    public partial class Informacje : Window
    {
        public Informacje(OSOBA osoba)
        {
            InitializeComponent();
            ShowInformation(osoba);
        }

        /// <summary>
        /// Shows especially information about person.
        /// </summary>
        /// <param name="osoba">The osoba.</param>
        public void ShowInformation(OSOBA osoba)
        {
            this.imie.Content = osoba.IMIE;
            this.nazwisko.Content = osoba.NAZWISKO;
            this.pesel.Content = osoba.PESEL;
            this.ojciec.Content = osoba.IMIE_OJCA;
            this.stanowisko.Content = osoba.STANOWISKO;
            this.wynagrodzenie.Content = osoba.WYNAGRODZENIE;
            this.data.Content = osoba.DATA_ZATRUDNIENIA;
            this.funkcja.Content = osoba.FUNKCJA;
            if(osoba.FUNKCJA == EnumOsoba.Żołnierz.ToString())
            {
                this.stopien.Content = osoba.STOPIEN;
            }
            if (osoba.OSOBA2 != null)
            {
                this.przelozony.Content = osoba.OSOBA2.IMIE + " " + osoba.OSOBA2.NAZWISKO;
            }
            
            this.pojazdGrid.ItemsSource = osoba.POJAZD;
        }
    }
}
