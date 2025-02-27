namespace MemeMaker.src
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Directory.SetCurrentDirectory(exeDirectory);
            dotenv.net.DotEnv.Load();
            TenorGifSearchForm.tenorApiKey = Environment.GetEnvironmentVariable("TENOR_API_KEY");
            if (TenorGifSearchForm.tenorApiKey == "api_key_here" || TenorGifSearchForm.tenorApiKey == null)
            {
                MessageBox.Show("Error, TENOR_API_KEY not found in .env file!", "Tenor API error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}