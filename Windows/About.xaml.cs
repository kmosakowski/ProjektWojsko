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
    /// <summary>
    /// Logika interakcji dla klasy About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            loadText();
        }

        /// <summary>
        /// Loads the text. Text related to the project with which it is associated and the use case that it supports.
        /// </summary>
        public void loadText()
        {
            this.text.Text = "Program stworzony na przedmiot MAS.\n" +
                "1.Dziedzina problemowa: System znajdzie zastosowanie w Jednostkach Wojskowych lub innych jednostkach służb mundurowych.\n" +
                "2.Cel: Celem systemu jest zmniejszenie biurokracji i ułatwienie ewidencjonowania pracowników jednostek wojskowych jak i wyposażenia w celu sprawniejszego dowodzenia archiwizacji i zarządzania zasobami ludzkimi w przypadku sytuacji ekstremalnych jak i w czasie pokoju.\n" +
                "3.Zakres odpowiedzialności systemu: System będzie umożliwiałprzechowywanie całego stanu osobowego jednostki, sprzętu, aktualnych misji w których biorą udział żołnierze jednostki, oraz przydzielony sprzęt. Szczegółową ewidencję pojazdów wraz z przeglądami jak i osoby odpowiedzialne za sprzęt wojskowy, podległość służbową.\n" +
                "\n" +
                "Przypadek zaimplementowany: Zgłoś pojazd do naprawy\n" +
                "Warunek początkowy W jednostce jest co najmniej jeden pojazd.\n" +
                "Główny przepływ zdarzeń\n" +
                "1.Aktor żołnierz uruchamia przypadek użycia.\n" +
                "2.System wyświetla listę pojazdów które są do niego przypisane w formie listy z danymi o pojeździe.\n" +
                "3.Aktor wybiera pojazd który chce zgłosić do Naprawy / Przeglądu i akceptuje przyciskiem uruchamiając przypadek użycia „Wyślij pojazd do naprawy”.\n" +
                "4.System informuje o pozytywnym zgłoszeniu pojazdu i kończy przypadek użycia\n" +
                "Alternatywne przepływy zdarzeń\n" +
                "2a.Brak pojazdów przypisanych do aktora.System wyświetla odpowiedni komunikat i kończy przypadek użycia.\n" +
                "2b.Po zapoznaniu się aktor kończy przypadek użycia bez zgłaszania żadnego pojazdu.\n" +
                "Zakończenie Zgodnie ze scenariuszem\n" +
                "Warunek końcowy Pojazd zostaje zgłoszony do naprawy w przypadku gdy aktor zgłosi go do naprawy.\n";
        }
    }
}
