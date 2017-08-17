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

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ZaposleniDal ZDal = new ZaposleniDal();
        VrstaOdsustvaDal VDal = new VrstaOdsustvaDal();
        ZahtevDal ZaDal = new ZahtevDal();
        public Window1()
        {
            InitializeComponent();
        }
        private void Resetuj()
        {
            comboBoxListaZaposlenih.SelectedIndex = -1;
            comboBoxVrstaZahteva.SelectedIndex = -1;
            textBoxBrojDana.Clear();
            dtp1.SelectedDate = DateTime.Today;
            dtp2.SelectedDate = DateTime.Today.AddDays(1);
            imageZaposleni.Source = null;
        }
        private void VratiZaposlene()
        {
            List<Zaposleni> lista = ZDal.vratiZaposlene();
            foreach (Zaposleni z in lista)
            {
                comboBoxListaZaposlenih.ItemsSource = lista;
            }
        }
        private void VratiVrste()
        {
            List<VrstaZahteva> lista = VDal.PrikaziVrstu();
            foreach (VrstaZahteva vr in lista)
            {
                comboBoxVrstaZahteva.ItemsSource = lista;
            }
        }
        private bool Validacija()
        {
            int broj;

            if (comboBoxListaZaposlenih.SelectedIndex == -1)
            {
                MessageBox.Show("Morate odabrati zaposlenog", "Upozorenje");
                return false;
            }
            if (comboBoxVrstaZahteva.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati vrstu", "Upozorenje");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxBrojDana.Text))
            {
                MessageBox.Show("Morate odabrati broj dana", "Upozorenje");
                return false;
            }
            if (!int.TryParse(textBoxBrojDana.Text, out broj))
            {
                if (broj > 30)
                {
                    MessageBox.Show("Mora biti broj manji od 31", "Upozorenje");
                    return false;
                }
                MessageBox.Show("Mora biti broj", "Upozorenje");
                return false;
            }
           
            if (dtp1.SelectedDate < DateTime.Today || dtp2.SelectedDate < DateTime.Today || dtp1.SelectedDate > dtp2.SelectedDate)
            {
                MessageBox.Show("Morate odabrati validan datum", "Upozorenje");
                return false;
            }
            
            return true;
        }
        private Zahtev NadjiKategoriju(int id)
        {
            foreach (Zahtev k in comboBoxListaZaposlenih.Items) { if (k.ZaposleniId == id) { return k; } }

            return null;
        }
        private void PosaljiZahtev()
        {
            Zahtev z = new Zahtev();
            Zaposleni selKategorija = (Zaposleni)comboBoxListaZaposlenih.SelectedItem;
            VrstaZahteva selKategorijaVr = (VrstaZahteva)comboBoxVrstaZahteva.SelectedItem;
            z.BrojDana = int.Parse(textBoxBrojDana.Text.Trim());
            z.VremeOd = (DateTime)dtp1.SelectedDate;
            z.VremeDo = (DateTime)dtp2.SelectedDate;           
            z.VrstaOdsustvaId = selKategorijaVr.VrstaOdsustvaId;
            z.ZaposleniId = selKategorija.ZaposleniId;

            int rez = ZaDal.PosaljiZahtev(z);
            if (rez != 0)
            {
                MessageBox.Show("Doslo je do greske");
            }
            else
            {
                Resetuj();
                MessageBox.Show("Zaposleni je dodat");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtp1.SelectedDate = DateTime.Today;
            dtp2.SelectedDate = DateTime.Today.AddDays(1);
            VratiZaposlene();
            VratiVrste();
        }

        private void buttonPosalji_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija() == true)
            {
                PosaljiZahtev();
            }
        }

        private void buttonNazad_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void comboBoxListaZaposlenih_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxListaZaposlenih.SelectedIndex > -1)
            {
                Zaposleni z = (Zaposleni)comboBoxListaZaposlenih.SelectedItem;
                BitmapImage bmp = SlikaKonverter.KonvertujUBitmap(z.Slika);
                imageZaposleni.Source = bmp;
            }
        }
       
    }
}
     
           
    
