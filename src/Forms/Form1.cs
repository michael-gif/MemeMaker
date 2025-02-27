using MemeMaker.src;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Security;

namespace MemeMaker
{
    public partial class Form1 : Form
    {
        TenorGif selectedGif { get; set; }
        string justify = "center";
        PrivateFontCollection pfc = new PrivateFontCollection();
        Font captionFont;
        bool boldButtonEnabled = false;
        bool justifyButtonEnabled = false;
        bool exportButtonEnabled = false;

        public Form1()
        {
            InitializeComponent();
            LoadCustomFonts();
            SetColorScheme();

            fontComboBox.SelectedIndex = 0;
            captionFont = new Font(fontComboBox.SelectedText, fontSizeSlider.Value, FontStyle.Bold);
            captionText.Font = captionFont;
        }

        /// <summary>
        /// Set the back colors of all the controls on the form
        /// </summary>
        private void SetColorScheme()
        {
            this.BackColor = ColorTranslator.FromHtml("#1E1F22");
            tenorGifButton.BackColor = ColorTranslator.FromHtml("#3F4248");
            uploadImageButton.BackColor = ColorTranslator.FromHtml("#3F4248");
            panel1.BackColor = ColorTranslator.FromHtml("#2B2D31");
            fontComboBox.BackColor = ColorTranslator.FromHtml("#3F4248");
        }

        /// <summary>
        /// Custom fonts are embedded in Resources.resx
        /// They get loaded here into memory and assigned to any controls that use them
        /// </summary>
        private void LoadCustomFonts()
        {
            byte[] stratum2Data = Properties.Resources.stratum2_regular_webfont;
            int stratum2Length = Properties.Resources.stratum2_regular_webfont.Length;
            IntPtr data = Marshal.AllocCoTaskMem(stratum2Length);
            Marshal.Copy(stratum2Data, 0, data, stratum2Length);
            pfc.AddMemoryFont(data, stratum2Length);

            FontFamily stratum2 = pfc.Families[0];
            tenorGifButton.Font = new Font(stratum2, tenorGifButton.Font.Size);
            uploadImageButton.Font = new Font(stratum2, uploadImageButton.Font.Size);
            boldTextButton.Font = new Font(stratum2, boldTextButton.Font.Size, FontStyle.Bold);
            justifyTextButton.Font = new Font(stratum2, justifyTextButton.Font.Size);
            exportGifButton.Font = new Font(stratum2, exportGifButton.Font.Size);
        }

        /// <summary>
        /// Make picture and caption visible
        /// Enable caption textbox
        /// Enable font selection box, font size slider, bold and justify buttons
        /// Set the colors of the caption textbox, bold text button, justify text button and export button
        /// </summary>
        private void EnableRemainingControls()
        {
            selectedGifPictureBox.Visible = true;
            captionText.Visible = true;
            captionTextBox.Enabled = true;
            fontComboBox.Enabled = true;
            fontSizeSlider.Enabled = true;
            boldButtonEnabled = true;
            justifyButtonEnabled = true;
            exportButtonEnabled = true;

            captionTextBox.BackColor = Color.White;
            boldTextButton.BackColor = ColorTranslator.FromHtml("#3F4248");
            boldTextButton.ForeColor = Color.White;
            justifyTextButton.BackColor = ColorTranslator.FromHtml("#3F4248");
            justifyTextButton.ForeColor = Color.White;
            exportGifButton.BackColor = ColorTranslator.FromHtml("#3F4248");
            exportGifButton.ForeColor = Color.White;
        }

        public void UpdateSelectedGif(TenorGif gif)
        {
            if (gif == null) return;
            selectedGif = gif;
            selectedGifPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            selectedGifPictureBox.ImageLocation = selectedGif.fullUrl;

            int memeWidth = gif.width;
            int memeHeight = gif.height + captionText.Height;

            int gifX = (panel1.Width - memeWidth) / 2;
            int gifY = (panel1.Height - memeHeight) / 2;

            selectedGifPictureBox.Location = new(gifX, gifY + captionText.Height);
            selectedGifPictureBox.Size = new Size(gif.width, gif.height);

            captionText.Location = new(gifX, gifY);
            captionText.Size = new(gif.width, captionText.Height);

            EnableRemainingControls();
        }

        private string[] WrapText(string text, Font font, int maxWidth)
        {
            string[] words = text.Split(' ');
            List<string> lines = new List<string>();
            string currentLine = "";

            foreach (string word in words)
            {
                string testLine = string.IsNullOrEmpty(currentLine) ? word : currentLine + " " + word;
                Size textSize = TextRenderer.MeasureText(testLine, font);

                if (textSize.Width > maxWidth)
                {
                    lines.Add(currentLine);  // Add the previous line
                    currentLine = word;       // Start a new line with the current word
                }
                else
                {
                    currentLine = testLine;  // Keep adding words to the current line
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
            {
                lines.Add(currentLine);  // Add the last line
            }

            return lines.ToArray();
        }

        private void UpdateCaptionFont(bool isBold)
        {
            string selectedFont = (string)fontComboBox.Items[fontComboBox.SelectedIndex];
            FontStyle fontStyle = isBold ? FontStyle.Bold : FontStyle.Regular;
            captionFont = new Font(selectedFont, fontSizeSlider.Value, fontStyle);
            captionText.Font = captionFont;
        }

        /// <summary>
        /// Saves caption to png file for use in export later on
        /// </summary>
        /// <returns></returns>
        private string SaveCaption()
        {
            string outputPath = Path.Combine(Path.GetTempPath(), "caption.png");
            using (Bitmap bitmap = new Bitmap(selectedGif.width, captionText.Height))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(captionText.BackColor);
                using (Brush textBrush = new SolidBrush(captionText.ForeColor))
                {
                    string[] lines = WrapText(captionText.Text, captionFont, selectedGif.width);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        int textX = 0;
                        SizeF textSize = g.MeasureString(lines[i], captionFont);
                        switch (justify)
                        {
                            case "left":
                                textX = 0;
                                break;
                            case "center":
                                textX = (selectedGif.width - (int)textSize.Width) / 2;
                                break;
                            case "right":
                                textX = selectedGif.width - (int)textSize.Width;
                                break;
                        }
                        if (textX < 0) textX = 0;
                        g.DrawString(lines[i], captionFont, textBrush, new PointF(textX, 5 + i * (captionFont.Height)));
                    }
                }
                bitmap.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
            }
            return outputPath;
        }

        private void tenorGifButton_Click(object sender, EventArgs e)
        {
            TenorGifSearchForm tenorGifSearchForm = new TenorGifSearchForm(this);
            tenorGifSearchForm.ShowDialog();
        }

        private void captionTextBox_TextChanged(object sender, EventArgs e)
        {
            int lineCount = WrapText(captionTextBox.Text, captionFont, selectedGif.width).Length;
            captionText.Text = captionTextBox.Text;
            captionText.Size = new(selectedGif.width, 10 + captionFont.Height * lineCount);
            UpdateSelectedGif(selectedGif);
        }

        private void justifyTextButton_Click(object sender, EventArgs e)
        {
            if (!justifyButtonEnabled) return;

            if (justify == "left")
            {
                justify = "center";
                justifyTextButton.Text = "Justify: Center";
                captionText.TextAlign = ContentAlignment.MiddleCenter;
            }
            else if (justify == "center")
            {
                justify = "right";
                justifyTextButton.Text = "Justify: Right";
                captionText.TextAlign = ContentAlignment.MiddleRight;
            }
            else if (justify == "right")
            {
                justify = "left";
                justifyTextButton.Text = "Justify: Left";
                captionText.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void fontSizeSlider_Scroll(object sender, EventArgs e)
        {
            UpdateCaptionFont(captionFont.Bold);
            int lineCount = WrapText(captionTextBox.Text, captionFont, selectedGif.width).Length;
            captionText.Size = new(selectedGif.width, 10 + captionFont.Height * lineCount);
            UpdateSelectedGif(selectedGif);
        }

        private void boldTextButton_Click(object sender, EventArgs e)
        {
            if (!boldButtonEnabled) return;

            boldTextButton.Font = new Font(DefaultFont, boldTextButton.Font.Bold ? FontStyle.Regular : FontStyle.Bold);
            bool isBold = boldTextButton.Font.Bold;
            UpdateCaptionFont(isBold);
            UpdateSelectedGif(selectedGif);
        }

        private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCaptionFont(boldTextButton.Font.Bold);
            if (!string.IsNullOrEmpty(captionTextBox.Text))
            {
                int lineCount = WrapText(captionTextBox.Text, captionFont, selectedGif.width).Length;
                captionText.Text = captionTextBox.Text;
                captionText.Size = new(selectedGif.width, 10 + captionFont.Height * lineCount);
            }
            UpdateSelectedGif(selectedGif);
        }

        private void exportGifButton_Click(object sender, EventArgs e)
        {
            if (!exportButtonEnabled) return;

            // Obtain save file path
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Gif Image|*.gif";
            saveFileDialog1.Title = "Export GIF";
            saveFileDialog1.ShowDialog();
            if (string.IsNullOrEmpty(saveFileDialog1.FileName)) return;

            // Create caption image and ffmpeg command
            string captionImagePath = SaveCaption();
            string outputPath = saveFileDialog1.FileName;
            string[] arguments = {
                $"-i \"{captionImagePath}\"",
                $"-i \"{selectedGif.fullUrl}\"",
                "-filter_complex \"[0:v][1:v]vstack=inputs=2,split[a][b];[a]palettegen[p];[b][p]paletteuse=dither=sierra2_4a\"",
                $"-y \"{outputPath}\""
            };

            // Run ffmpeg command to generate gif
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = string.Join(" ", arguments),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                process.WaitForExit();
            }

            // Cleanup
            File.Delete(captionImagePath);
            MessageBox.Show("Exported gif to: " + outputPath, "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            UpdateSelectedGif(selectedGif);
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a gif",
                Filter = "Gifs (*.gif)|*.gif",
                Title = "Upload gif"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var uploadedGifPath = openFileDialog1.FileName;
                using (Image img = Image.FromFile(uploadedGifPath))
                {
                    TenorGif uploadedGif = new(null, uploadedGifPath, 0, 0, img.Width, img.Height);
                    selectedGif = uploadedGif;
                }
            }

            UpdateSelectedGif(selectedGif);
        }
    }
}
