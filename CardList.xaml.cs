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
using System.Data;

namespace PFGA_Cards
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CardList : UserControl
    {
        public delegate void CardListEventHandler(object sender, CardListEventArgs args);
        public event CardListEventHandler OnButtonClick;

        private DataTable CardData { get; set; }      

        public CardList(DataTable cardData)
        {
            CardData = cardData;
            InitializeComponent();
            DataView dataView = new DataView(CardData);
            Cards.ItemsSource = dataView;
            rowCount.Text = string.Format("{0} Cards", dataView.Count);
        }

        private void Init(object sender, EventArgs e)
        {
            
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            CardListEventArgs retvals = new CardListEventArgs(true);
            if (sender == btnCancel)
            {
                retvals.IsOK = false;
            }
            if (OnButtonClick != null)
                OnButtonClick(this, retvals);
        }

        
        

        
    }

    public class CardListEventArgs : EventArgs
    {
        private bool _IsOK;

        public CardListEventArgs(bool result)
        {
            _IsOK = result;
        }

        public bool IsOK
        {
            get { return _IsOK; }
            set { _IsOK = value; }
        }
    }
}
