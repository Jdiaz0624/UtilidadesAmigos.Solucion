using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;

namespace UtilidadesAmigos.Logica.Comunes
{
    public class VozVeronica
    {
        public static void Hablar(object Texto)
        {
            try {
                //SpeechSynthesizer veronica = new SpeechSynthesizer();
                //veronica.SetOutputToDefaultAudioDevice();
                //veronica.SelectVoice("Microsoft Sabina Desktop");
                //veronica.Speak(Texto.ToString());
            }
            catch {
                //SpeechSynthesizer veronica = new SpeechSynthesizer();
                //veronica.SetOutputToDefaultAudioDevice();
                //veronica.SelectVoice("Microsoft Hilda Desktop");
                //veronica.Speak(Texto.ToString());
            }
            
        }
    }
}
