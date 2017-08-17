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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        ObradjeniZahteviDal ODal = new ObradjeniZahteviDal();
        public Window3()
        {
            InitializeComponent();
        }
        private void ListaObradjenihZahteva()
        {
            List<ObradjeniZahtevi> lista = ODal.ListaObradjenihZahteva();
            foreach (ObradjeniZahtevi o in lista)
            {
                listBoxListaZaposlenih.ItemsSource = lista;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListaObradjenihZahteva();
        }

        private void listBoxListaZaposlenih_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxListaZaposlenih.SelectedIndex > -1)
            {
                ObradjeniZahtevi o = (ObradjeniZahtevi)listBoxListaZaposlenih.SelectedItem;
                textBoxZaposleniId.Text = o.ZaposleniId.ToString();
                textBoxIme.Text = o.Ime;
                textBoxPrezime.Text = o.Prezime;
                textBoxPozicija.Text = o.Pozicija;
                textBoxStatusResenja.Text = o.StatusResenja;
                textBoxObjasnjenje.Text = o.Objasnjenje;
                textBoxDatumResenja.Text = o.DatumResenja.ToShortDateString();
            }           
        }

        private void buttonNaza_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
