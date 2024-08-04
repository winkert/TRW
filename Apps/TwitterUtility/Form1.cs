using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TRW.CommonLibraries.Html;

namespace TwitterUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal void ScrapeWebsite(string siteUrl)
        {
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(siteUrl);
            request.UserAgent = "TRW";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                }
            }

            TRW.CommonLibraries.Html.HtmlDoc doc = null;
            using (HtmlParser parser = new HtmlParser())
            {
                doc = parser.ParseHtmlDocument(html);
            }



            uxResultsRTB.Text = doc.Body.Content;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScrapeWebsite(uxUrlText.Text);
        }
    }
}
