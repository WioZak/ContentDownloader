using System;
using System.Collections.Generic;
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
using System.Xml;

namespace ContentDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DownloadButton.Click += DownloadButton_Click;
               
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            //MyLabel.Content = "Hello!";
            //MyLabel.Content = downloadedText;
            MyTextBox.Clear();
            MyTextBox.AppendText(downloadedText);
            
        }

        public static string ReadTextFromUrl(string url)
        {
            // WebClient is still convenient
            // Assume UTF8, but detect BOM - could also honor response charset I suppose
            using (var client = new System.Net.WebClient())
            using (var stream = client.OpenRead(url))
            using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
            {
                return textReader.ReadToEnd();
            }
        }

        string downloadedText = ReadTextFromUrl(@"https://akrzemi1.wordpress.com/feed/");

        XmlDocument.LoadXml(downloadedText);
        
    }
}
