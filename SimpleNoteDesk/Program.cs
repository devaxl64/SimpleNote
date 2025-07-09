using SimpleNoteClass;

namespace SimpleNoteDesk
{
    internal static class Program
    {
        //public static User LoggedUser { get; set; } = new User();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.


        ApplicationConfiguration.Initialize();
            FrmMain frmmain = new FrmMain();
            Application.Run(frmmain);
        }
    }
}