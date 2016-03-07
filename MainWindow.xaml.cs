using System.IO;
using System.Text;
using System.Windows;
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
            string downloadedText = ReadTextFromUrl(@"https://akrzemi1.wordpress.com/feed/");
            XmlDocument xmlText = new XmlDocument();
            xmlText.LoadXml(downloadedText);
            XmlNode root = xmlText.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("/rss/channel/item/title");

            MyTextBox.Clear();

            for (int i = 0; i < 5; i++)
            {
                MyTextBox.AppendText(nodeList[i].InnerText + "\n");
            } 
        }

        public static string ReadTextFromUrl(string url)
        {
            using (var client = new System.Net.WebClient())
            using (var stream = client.OpenRead(url))
            using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
            {
                return textReader.ReadToEnd();
            }
        }
    }
}
