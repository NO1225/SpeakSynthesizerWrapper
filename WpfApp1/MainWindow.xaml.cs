using Classes;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MediaPlayer mediaPlayer = new MediaPlayer();

        private SpeechSynthesizer speechSynthesizer;// = new SpeechSynthesizer();

        //private WindowsXamlHost windowsXamlHost = new WindowsXamlHost();



        public MainWindow()
        {
            //windowsXamlHost.InitialTypeName = "ClassLibrary1.MyUserControl1";

            InitializeComponent();

            //var a = new App1.UWPControl();

            //a.Speak("Hello");
            //speechSynthesizer.SpeakComplete = SpeakCompleted;

            //var a = speechSynthesizer.GetInstalledVoices().ToList();

            //speechSynthesizer.SelectVoice(a[2].DisplayName);

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            //if (openFileDialog.ShowDialog() == true)
            //    mediaPlayer.Open(new Uri(openFileDialog.FileName));

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                lblStatus.Content = "No file selected...";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            speechSynthesizer.SpeakAsync("Hello wordl Hello wordl Hello wordl Hello wordl Hello wordl Hello wordl Hello wordl");
            //mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            speechSynthesizer.SpeakAsyncCancelAll();

        }

        private void SpeakCompleted(CompletionReason reason)
        {
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            speechSynthesizer.SpeakAsync("Done");
            mediaPlayer.Stop();
        }

        private void WindowsXamlHost_ChildChanged(object sender, EventArgs e)
        {
            // Hook up x:Bind source.
            global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost windowsXamlHost =
                sender as global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost;
            global::App1.SpeakerWithSMTC userControl =
                windowsXamlHost.GetUwpInternalObject() as global::App1.SpeakerWithSMTC;

            if (userControl != null)
            {
                speechSynthesizer = new SpeechSynthesizer(userControl);
            }
        }
    }
}
