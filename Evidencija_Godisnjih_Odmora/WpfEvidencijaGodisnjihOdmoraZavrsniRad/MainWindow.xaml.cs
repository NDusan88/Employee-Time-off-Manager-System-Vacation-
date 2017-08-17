using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string odabranaSlika = "";
        ZaposleniDal ZDal = new ZaposleniDal();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Resetuj()
        {
            textBoxZaposleniId.Clear();
            textBoxIme.Clear();
            textBoxPrezime.Clear();
            textBoxRadnoMesto.Clear();
            imageZaposleni.Source = null;
        }
        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxIme.Text))
            {
                MessageBox.Show("Morate uneti ime", "Upozorenje");
                textBoxIme.Focus();
                return false;                
            }
            if (string.IsNullOrWhiteSpace(textBoxPrezime.Text))
            {
                MessageBox.Show("Morate uneti prezime", "Upozorenje");
                textBoxPrezime.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxRadnoMesto.Text))
            {
                MessageBox.Show("Morate uneti radno mesto", "Upozorenje");
                textBoxRadnoMesto.Focus();
                return false;
            }
            if (imageZaposleni.Source == null)
            {
                MessageBox.Show("Morate uneti sliku", "Upozorenje");
                return false;
            }
            
            return true;           
        }
        private void VratiZaposlene()
        {
            List<Zaposleni> lista = ZDal.vratiZaposlene();
            foreach (Zaposleni z in lista)
            {
                listBoxListaZaposlenih.ItemsSource = lista;
            }
        }
        private void DodajZaposlenog()
        {
            Zaposleni z = new Zaposleni();
            z.Ime = textBoxIme.Text.Trim();
            z.Prezime = textBoxPrezime.Text.Trim();
            z.Pozicija = textBoxRadnoMesto.Text.Trim();
            z.Slika = SlikaKonverter.KonvertujUnizBajtova(odabranaSlika);
            int rez = ZDal.DodajZaposlenog(z);
            if (rez != 0)
            {
                MessageBox.Show("Doslo je do greske");
            }
            else
            {
                VratiZaposlene();
                Resetuj();
                MessageBox.Show("Zaposleni je dodat");
            }
        }   
        private void ObrisiZaposlenog()
        {
            Zaposleni z = (Zaposleni)listBoxListaZaposlenih.SelectedItem;
            z.ZaposleniId = z.ZaposleniId;
            int rezz = ZDal.ObrisiZaposlenog(z);
            if (rezz != 0)
            {
                MessageBox.Show("Ne mozete obrisati zaposlenog koji ima zahtev", "Upozorenje");
            }
            else
            {
                VratiZaposlene();
                imageZaposleni.Source = null;
                MessageBox.Show("Zaposleni je obrisan");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VratiZaposlene();            
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija() == true)
            {
                DodajZaposlenog();
            }
        }

        private void buttonSlika_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Slike|*.jpg;*.png";
            if (ofd.ShowDialog() == true)
            {
                odabranaSlika = ofd.FileName;
                BitmapImage bmp = new BitmapImage(new Uri(odabranaSlika));
                imageZaposleni.Source = bmp;
            }
        }

        private void listBoxListaZaposlenih_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxListaZaposlenih.SelectedIndex > -1)
            {
                Zaposleni z = (Zaposleni)listBoxListaZaposlenih.SelectedItem;
                BitmapImage bmp =  SlikaKonverter.KonvertujUBitmap(z.Slika);           
                imageZaposleni.Source = bmp;
                textBoxZaposleniId.Text = z.ZaposleniId.ToString();
            }
        }

        private void buttonZahtevi_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.ShowDialog();
        }

        private void buttonResenje_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.ShowDialog();
        }

        private void buttonZavrseno_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.ShowDialog();
        }

        private void buttonUgasi_Click(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void buttonPusti_Click(object sender, RoutedEventArgs e)
        {
            Player.Source = new Uri("http://streaming.tdiradio.com:8000/tdiradio.mp3", UriKind.RelativeOrAbsolute);
            Player.Play();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li zelite da obriste zaposlenog", "Pitanje", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                ObrisiZaposlenog();
            }
        }
    }
}
