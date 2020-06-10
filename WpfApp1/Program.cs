namespace WpfApp1
{
    public class Program
    {
        [System.STAThreadAttribute()]
        public static void Main()
        {
            using (var a = new App1.App())
            {
                App app = new App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }

}
