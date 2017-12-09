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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PFGA_Cards
{
    /// <summary>
    /// Interaction logic for CardLayout.xaml
    /// </summary>
    public partial class CardLayout : UserControl
    {
        public CardLayout()
        {
            
        }
        public CardLayout(Card card)
        {
            InitializeComponent();

            this.ExpiryDate.Text = card.Expires;
            this.FirstName.Text = card.FirstName;
            this.LastName.Text = card.LastName;
            this.CardNumber.Text = card.CardNumber;
            this.Handgun.Text = card.Handgun;
            this.Action.Text = card.Action;
            this.Smallbore.Text = card.Smallbore;
            this.Rifle.Text = card.Rifle;
            this.Archery.Text = card.Archery;
            this.CardPicture.Source = card.Picture;

        }
    }
}
