using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*tak nie rób!!!!
             * int liczba = int.Parse( liczba1_textbox.Text)+2;
             */

            int liczba;
            if (int.TryParse(liczba1_textbox.Text, out liczba)) {
                MessageBox.Show(liczba.ToString());
            }
            else
            {
                MessageBox.Show("Należy wprowadzić liczbę całkowitą");
            }

            double liczbaRzeczywista;
            if(double.TryParse(liczba2_textbox.Text,out liczbaRzeczywista))
            {
                MessageBox.Show("wprowadzono"+liczbaRzeczywista.ToString());
            }
            else
            {
                MessageBox.Show("Należy wprowadzić liczbe rzeczywistą");
            }
            
        }

        private void Button_Click_Silnia(object sender, RoutedEventArgs e)
        {
            int nDoObliczenSilni;
            if (int.TryParse(liczba1_textbox.Text, out nDoObliczenSilni))
            {
                long wynikSilni = silnia(nDoObliczenSilni);
                MessageBox.Show("Silnia Liczby "+nDoObliczenSilni.ToString()
                    +" wynosi "+wynikSilni.ToString(), "Silnia");
            }
        }


        private long silnia(int n)
        {
            long wynik = 1;

            for(int i = 1; i <= n; i++)
            {
                wynik = wynik * i;
            }


            return wynik;
        }

        private void Button_Click_Potega(object sender, RoutedEventArgs e)
        {
            double podstawa;
            int wykladnik;
            if (int.TryParse(liczba1_textbox.Text, out wykladnik) 
                && double.TryParse(liczba2_textbox.Text, out podstawa))
            {
                MessageBox.Show(potega(podstawa, wykladnik).ToString());
            }
            else
            {
                MessageBox.Show("wpisz poprawne dane");
            }
        }

        private double potega(double podstawa, int wykladnik)
        {
            double wynik = 1;
            bool czyUjemna = false;
            if (wykladnik < 0)
            {
                czyUjemna = true;
                wykladnik = -wykladnik;
            }

            for (int i = 0; i < wykladnik; i++)
            {
                wynik = wynik * podstawa;
            }
            if (czyUjemna)
            {
                return 1 / wynik;
            }
            return wynik;
        }

        private void Button_Click_Suma_cyfr(object sender, RoutedEventArgs e)
        {
            int liczba;
            if (int.TryParse(liczba1_textbox.Text, out liczba))
            {
                MessageBox.Show("Suma cyfr z liczby " + liczba + " wynosi " + sumaCyfr(liczba));
            }
            else
            {
                MessageBox.Show("Wprowadzono niewłaściwe dane");
            }
        }

        private int sumaCyfr(int liczba)
        {
            int suma = 0;
            while (liczba > 0)
            {
                int cyfra = liczba % 10;
                liczba = liczba / 10;
                suma = suma + cyfra;

            }
            return suma;
        }

        /*
* wczytanie pola tekstowego jako liczby (rzeczywista, calkowita)
* program nie wysypuje się jeżeli wprowadzę coś innego
* po wybraniu przycisku wyswietlanie wyniku w textblock lub messagebox
* 
* 
*/
    }
}