using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;



namespace Print_PDF_Demo
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //forPrint.PageHeight = InchToPoint(paperSizeA4.Height); // paperSizeA4.Height: integer value
                //forPrint.PageWidth = forPrint.ColumnWidth = InchToPoint(paperSizeA4.Width); // paperSizeA4.Width: integer value
                forPrint.PagePadding = new Thickness(40);
                DocumentPaginator docPaginator = ((IDocumentPaginatorSource)forPrint).DocumentPaginator;
                docPaginator.ComputePageCount();


                this.IsEnabled = false;
                PrintDialog My_printDialog = new PrintDialog();      
                if (My_printDialog.ShowDialog() == true)
                {
                    My_printDialog.PrintDocument(docPaginator, "My PDF print");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
