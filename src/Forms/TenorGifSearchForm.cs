using MemeMaker.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeMaker
{
    public partial class TenorGifSearchForm : Form
    {
        public static string tenorApiKey;
        Form1 parent;
        public TenorGifSearchForm(Form1 parent)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#1E1F22");
            gifSearchTextBoxPanel.BackColor = ColorTranslator.FromHtml("#3F4248");
            gifSearchBox.BackColor = ColorTranslator.FromHtml("#3F4248");
            gifSearchBox.ForeColor = Color.White;
            gifSearchBox.KeyUp += async (s, e) => { if (e.KeyCode == Keys.Enter) await SearchGifs(gifSearchBox.Text); };
            this.parent = parent;
        }

        private async Task SearchGifs(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return;

            string url = $"https://tenor.googleapis.com/v2/search?q={query}&key={tenorApiKey}&client_key=my_test_app&limit=20";
            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var jsonDoc = JsonDocument.Parse(response);
            var gifs = new List<TenorGif>();

            foreach (var result in jsonDoc.RootElement.GetProperty("results").EnumerateArray())
            {
                JsonElement mediaFormats = result.GetProperty("media_formats");
                JsonElement tinyGif = mediaFormats.GetProperty("tinygif");
                JsonElement gif = mediaFormats.GetProperty("gif");
                string tinyUrl = tinyGif.GetProperty("url").ToString();
                string fullUrl = gif.GetProperty("url").ToString();
                List<int> gifDimensionsTiny = tinyGif.GetProperty("dims").Deserialize<List<int>>();
                List<int> gifDimensionsFull = gif.GetProperty("dims").Deserialize<List<int>>();
                gifs.Add(new(tinyUrl, fullUrl, gifDimensionsTiny[0], gifDimensionsTiny[1], gifDimensionsFull[0], gifDimensionsFull[1]));
            }

            UpdateGifDisplay(gifs);
        }

        private void UpdateGifDisplay(List<TenorGif> gifs)
        {
            gifFlowLayoutPanel.Controls.Clear(); // Clear previous results

            foreach (var gif in gifs)
            {
                float ratio = (float)gif.heightTiny / (float)gif.widthTiny;
                PictureBox picBox = new PictureBox
                {
                    Size = new Size(gif.widthTiny, (int)(gif.widthTiny * ratio)),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = gif.tinyUrl
                };
                picBox.Click += (s, e) => {
                    parent.UpdateSelectedGif(gif);
                    Close();
                };
                gifFlowLayoutPanel.Controls.Add(picBox);
            }
        }
    }
}
