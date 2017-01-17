using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KEVIN
{
    //Music player class
    public class MusicPlayer
    {
        //Public variables of the strings used to execute the winmm.dll commands
        public string openString;
        public string playString;
        public string pauseString;
        public string stopString;
        //Import winmm.dll which is used to play audio files
        [DllImport("winmm.dll")]
        //Variable/Command used to tell winmm.dll what to do
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        public void Open(string file)
        {
            //Open the song that is specified (file)
            openString = "open \"" + file + "\" type MPEGVideo alias CurrentlyPlaying";
            mciSendString(openString, null, 0, 0);
        }

        public void Play()
        {
            //Play song that has just been opened
            playString = "play CurrentlyPlaying";
            mciSendString(playString, null, 0, 0);
        }

        public void Pause()
        {
            //Pause the song currently playing
            pauseString = "stop CurrentlyPlaying";
            mciSendString(pauseString, null, 0, 0);
        }

        public void Stop()
        {
            //Stop the song currently playing
            stopString = "stop CurrentlyPlaying";
            mciSendString(stopString, null, 0, 0);

            stopString = "close CurrentlyPlaying";
            mciSendString(stopString, null, 0, 0);
        }

        //Private constants for changing volumem
        private const int volumeMute = 0x80000;
        private const int volumeUp = 0xA0000;
        private const int volumeDown = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        //Importing user32.dll to control volume
        [DllImport("user32.dll")]
        //Variable used to send volume control signals
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        //Mute function
        public void Mute(frmKEVINMain frm)
        {
            SendMessageW(frm.Handle, WM_APPCOMMAND, frm.Handle,
                (IntPtr)volumeMute);
        }

        //Decrease volume function
        public void DecVol(frmKEVINMain frm)
        {
            SendMessageW(frm.Handle, WM_APPCOMMAND, frm.Handle,
                (IntPtr)volumeDown);
        }
        
        //Increase volume function
        public void IncVol(frmKEVINMain frm)
        { 
            SendMessageW(frm.Handle, WM_APPCOMMAND, frm.Handle,
                (IntPtr)volumeUp);
        }
    }
}
