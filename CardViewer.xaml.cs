using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Data;
using System.Windows.Xps;
using System.Printing;
using System.IO;
using System.Drawing;

namespace PFGA_Cards
{
    /// <summary>
    /// Interaction logic for CardViewer.xaml
    /// </summary>
    public partial class CardViewer : UserControl
    {
        private DataTable CardData { get; set; }

        public CardViewer(DataTable cardData)
        {
            CardData = cardData;
            InitializeComponent();   
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CardPage page = new CardPage();
            this.documentViewer1.Document = page.CreateFrontPage(CardData);
            this.documentViewer1.FitToWidth();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            // get a print dialog, defaulted to default printer and default printer's preferences.
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            printDialog.PrintTicket = printDialog.PrintQueue.DefaultPrintTicket;
            printDialog.UserPageRangeEnabled = true;
            printDialog.CurrentPageEnabled = true;
            printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;

            if (printDialog.ShowDialog() == true)
            {
                // set the print ticket for the document sequence and write it to the printer.
                //docSeq.PrintTicket = printDialog.PrintTicket;
                DocumentPaginator paginator = this.documentViewer1.Document.DocumentPaginator;

                if (printDialog.PageRangeSelection == PageRangeSelection.UserPages)
                {
                    paginator = new PageRangeDocumentPaginator(
                                     this.documentViewer1.Document.DocumentPaginator,
                                     printDialog.PageRange);
                }
                else if (printDialog.PageRangeSelection == PageRangeSelection.CurrentPage)
                {
                    PageRange range = new PageRange(this.documentViewer1.MasterPageNumber);
                    paginator = new PageRangeDocumentPaginator(this.documentViewer1.Document.DocumentPaginator, range);
                }
                printDialog.PrintDocument(paginator, "PFGA Membership Cards");
            }
        }

        private void CardFront_Checked(object sender, RoutedEventArgs e)
        {
            CardPage page = new CardPage();
            this.documentViewer1.Document = page.CreateFrontPage(CardData);
            this.documentViewer1.FitToWidth();
        }

        private void CardBack_Checked(object sender, RoutedEventArgs e)
        {
            CardPage page = new CardPage();
            this.documentViewer1.Document = page.CreateCardBack();
            this.documentViewer1.FitToWidth();
        }

        private void CardBoth_Checked(object sender, RoutedEventArgs e)
        {
            CardPage page = new CardPage();
            this.documentViewer1.Document = page.CreateTwoSided(CardData);
            this.documentViewer1.FitToWidth();
        }

       
    }
}
