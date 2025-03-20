using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeMaker.src.Forms
{
    public partial class ExportProgressForm: Form
    {
        string captionImagePath;
        string[] ffmpegArguments;
        public ExportProgressForm(string captionImagePath, string destination, string[] ffmpegArguments)
        {
            InitializeComponent();
            Activated += ExportGif;

            this.captionImagePath = captionImagePath;
            this.ffmpegArguments = ffmpegArguments;
            pictureBox1.Left = (ClientSize.Width - pictureBox1.Width) / 2;
            label1.Text = destination;
        }

        private async void ExportGif(object sender, EventArgs e)
        {
            // Run ffmpeg command to generate gif
            await Task.Run(() =>
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = string.Join(" ", ffmpegArguments),
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
            });

            // Cleanup
            File.Delete(captionImagePath);
            this.Close();
        }
    }
}
