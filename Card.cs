using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Media.Imaging;

namespace PFGA_Cards
{
    public class Card
    {
        int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string Archery { get; set; }
        public string Handgun { get; set; }
        public string Smallbore { get; set; }
        public string Rifle { get; set; }
        public string Action { get; set; }
        public string Expires { get; set; }
        public BitmapImage Picture { get; set; }
    }
}
