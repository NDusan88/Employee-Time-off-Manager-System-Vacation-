using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfEvidencijaGodisnjihOdmoraZavrsniRad
{
    class SlikaKonverter
    {
        public static BitmapImage KonvertujUBitmap(byte[] NizBin)
        {
            //Prosledjuje se z.slika 
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = (new MemoryStream(NizBin));
            bmp.EndInit();
            return bmp;
        }
        public static byte[] KonvertujUnizBajtova(string putanjaSlike = null, BitmapImage bmp = null)
        {
            //putanja         
            JpegBitmapEncoder enc = new JpegBitmapEncoder();
            if (putanjaSlike != null)
                enc.Frames.Add(BitmapFrame.Create(new Uri(putanjaSlike)));
            if (bmp != null)
                enc.Frames.Add(BitmapFrame.Create((bmp)));



            using (MemoryStream ms = new MemoryStream())
            {
                enc.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
