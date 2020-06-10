using Classes;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SpeechSynthesizer
    {
        //private WindowsXamlHost windowsXamlHost;

        private App1.SpeakerWithSMTC speaker;

        public double Rate
        {
            get { 
                return speaker.Rate; 
            }
            set { 
                speaker.Rate = value; 
            }
        }

        public double Pitch
        {
            get
            {
                return speaker.Pitch;
            }
            set
            {
                speaker.Pitch = value;
            }
        }


        public Action<int, int> SpeakProgress {  
            set
            {
                speaker.SpeakProgress = value;
            }
        }

        public Action<CompletionReason> SpeakComplete {
            set 
            {
                speaker.SpeakComplete = value;
            } 
        }

        public Action PlayPressed { 
            set 
            {
                speaker.PlayPressed = value;
            }
        }
        public Action PausePressed
        { 
            set 
            {
                speaker.PausePressed = value;
            }
        }
        public Action NextPressed
        { 
            set 
            {
                speaker.NextPressed = value;
            }
        }
        public Action PreviousPressed
        { 
            set 
            {
                speaker.PreviousPressed = value;
            }
        }

        public SpeechSynthesizer(global::App1.SpeakerWithSMTC speaker)
        {
            this.speaker = speaker;

            //windowsXamlHost = new WindowsXamlHost();

            //var a = windowsXamlHost.Parent;

            //using(new WindowsXamlHost())
            //{
            //    speaker = new App1.SpeakerWithSMTC();

            //}
            // windowsXamlHost.InitialTypeName = typeof(App1.SpeakerWithSMTC).FullName;


        }

        public async Task SpeakAsync(string text)
        {
            await speaker.SpeakAsync(text);
        }

        public IEnumerable<InstalledVoice> GetInstalledVoices()
        {
            return speaker.GetInstalledVoices();

        }

        public bool SelectVoice(string voiceName)
        {
            var voice = speaker.GetInstalledVoices().FirstOrDefault(v => v.DisplayName == voiceName);

            if(voice != null)
            {
                return speaker.SelectVoice(voice);                
            }
            return false;
        }

        public InstalledVoice GetSelectedVoice()
        {
            return speaker.GetSelectedVoice();
        }

        public async Task SpeakAsyncCancelAll()
        {
            await speaker.SpeakAsyncCancelAll();
        }

        public void UpdateSystemMediaTrasportControls(
            string title,
            string chapter,
            string coverPath = "",
            Classes.MediaPlaybackStatus mediaPlaybackStatus = Classes.MediaPlaybackStatus.Playing,
            bool isPLayEnabled = true,
            bool isNextEnabled = true,
            bool isPreviousEnabled = true,
            bool isPauseEnabled = true
            )
        {
            speaker.UpdateSystemMediaTrasportControls(
                title,
                chapter,
                coverPath,
                mediaPlaybackStatus,
                isPLayEnabled,
                isNextEnabled,
                isPreviousEnabled,
                isPauseEnabled);
        }
        
    }

    
}
