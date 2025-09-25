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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int liczba;
            if(int.TryParse(liczba1_textbox.Text,out liczba))
            {
                List<int> dzielniki = dzielnikiLiczby(liczba);
                listaDzielnikowListView.ItemsSource = dzielniki;
            }
            else
            {
                MessageBox.Show("Wprowadż liczbę");
            }
        }

        private List<int> dzielnikiLiczby(int liczba)
        {
            List<int> dzielniki = new List<int>();
            for(int i = 1; i <= Math.Sqrt(liczba); i++)
            {
                if(liczba%i == 0)
                {
                    dzielniki.Add(i);
                    if (i != liczba / i)
                    {
                        dzielniki.Add(liczba / i);
                    }
                }
            }
            return dzielniki;
        }

        private void Button_Click_CzyPierwsza(object sender, RoutedEventArgs e)
        {
            int liczba;
            if (int.TryParse(liczba1_textbox.Text, out liczba)) {
                if (czyPierwsza(liczba))
                {
                    MessageBox.Show("To jest liczba pierwsza ");
                }
                else
                {
                    MessageBox.Show("To nie jest liczba pierwsza");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne dane");
            }
        }

        private bool czyPierwsza(int liczba)
        {
            if(liczba == 1)
            {
                return false;
            }
            for(int i = 2;i <= Math.Sqrt(liczba); i++)
            {
                if(liczba % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int liczba;
            int liczba2;
            if (int.TryParse(liczba1_textbox.Text, out liczba) && int.TryParse(liczba2_textbox.Text,out liczba2))
            {
                MessageBox.Show("Nwd liczb " + liczba + " oraz " + liczba2 + " wynosi " + nwd(liczba, liczba2));
            }
        }

        private int nwd(int a,int b)
        {
            //nie działa dla 0
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

        private String zamienZdziesietnegoNaSystem(int liczba, int system)
        {
            String wynik = "";
            while (liczba > 0)
            {
                int cyfra = liczba % system;
                wynik = cyfra + wynik; //przemyśleć
                liczba = liczba / system;
            }
            return wynik;
        }

        private int zamienNaDziesietnyZSystemu(string liczba,int system)
        {
            int wynik = 0;
            int potega = 1;
            for(int i =  liczba.Length-1;i>=0; i--)
            {
                int cyfra = (int)liczba[i] - 48;
                if (cyfra > 9)
                {
                    cyfra = cyfra - 7;
                }
                wynik = wynik + cyfra * potega;// sprawdzić czy rzutowanie string na int?????????????
                potega = potega * system;
            }
            return wynik;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string liczba = liczbaDoPrzeliczenieTextBox.Text.Trim();
            int system;
            if(int.TryParse(systemTextBox.Text,out system))
            {
                MessageBox.Show(zamienNaDziesietnyZSystemu(liczba, system).ToString());
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int liczbaPrzeliczna;
            int system;
            if(int.TryParse(liczbaDoPrzeliczenieTextBox.Text, out liczbaPrzeliczna) && int.TryParse(systemTextBox.Text,out system))
            {
                MessageBox.Show(zamienZdziesietnegoNaSystem(liczbaPrzeliczna, system));
            }
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