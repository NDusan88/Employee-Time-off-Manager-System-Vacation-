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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        ResenjaDal RDal = new ResenjaDal();
        StatusResenjaDal SDal = new StatusResenjaDal();
        ZahtevDal ZDal = new ZahtevDal();
            
        public Window2()
        {
            InitializeComponent();
        }
        private void ListaZahteva()
        {
            List<Resenja> lista = RDal.VratiListu();
            foreach (Resenja z in lista)
            {
                listBoxZaposleni.ItemsSource = null;
                listBoxZaposleni.ItemsSource = lista;
            }
        }
        private void ListaStatusa()
        {            
            List<StatusResenja> lista = SDal.PrikaziStatus();
            foreach (StatusResenja z in lista)
            {
                comboBoxStatus.ItemsSource = lista;
            }
        }
        private void ObradiZahtev()
        {
            ObradiZahtev o = new ObradiZahtev();
            Resenja selKategorija = (Resenja)listBoxZaposleni.SelectedItem;
            StatusResenja selStatus = (StatusResenja)comboBoxStatus.SelectedItem;
            o.StatusResenjaId = selStatus.StatusResenjaId;
            o.ZahtevId = selKategorija.ZahtevId;
            o.DatumResenja = (DateTime)dtpDatumResenja.SelectedDate;
            o.Objasnjenje = textBoxObjasnjenje.Text.Trim();
            int rez = ZDal.ObradiZahtev(o);
            if (rez != 0)
            {
                MessageBox.Show("Doslo je do greske");
            }
            else
            {               
                ListaZahteva();
                listBoxZaposleni.ItemsSource = null;
                textBoxObjasnjenje.Clear();
                MessageBox.Show("Zaposleni je dodat");
            }
        }
        private bool Validacija()
        {
            if (listBoxZaposleni.SelectedIndex == -1)
            {
                MessageBox.Show("Odaberite zaposlenog", "Upozorenje");
                return false;
            }
            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Odaberite status", "Upozorenje");
                return false;
            }
            if (dtpDatumResenja.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Odaberite ispravan datum", "Upozorenje");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxObjasnjenje.Text))
            {
                MessageBox.Show("Upisite objasnjenje", "Upozorenje");
                return false;
            }
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtpDatumResenja.SelectedDate = DateTime.Now;
            ListaZahteva();
            ListaStatusa();
        }

        private void buttonZahtev_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija() == true)
            {
                ObradiZahtev();
            }
        }

        private void buttonNaza_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void listBoxZaposleni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxZaposleni.SelectedIndex > -1)
            {
                Resenja r = (Resenja)listBoxZaposleni.SelectedItem;
                textBoxIme.Text = r.Ime;
                textBoxPrezime.Text = r.Prezime;
                textBoxRadnoMesto.Text = r.Pozicija;
                textBoxVremeOd.Text = r.VremeOd.ToShortDateString();
                textBoxVremeDo.Text = r.VremeDo.ToShortDateString();
                textBoxVrsta.Text = r.Naziv;
                textBoxBrojDana.Text = r.BrojDana.ToString();
            }         
        }
    }
}
