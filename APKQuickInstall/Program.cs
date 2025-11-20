namespace APKQuickInstall
{
    internal static class Program
    {
        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
           public static string AppDataPath { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Create application data directory
            AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);
            //Directory.CreateDirectory(AppDataPath);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetColorMode(SystemColorMode.System);
            Application.Run(new MainForm());
        }
    }
}