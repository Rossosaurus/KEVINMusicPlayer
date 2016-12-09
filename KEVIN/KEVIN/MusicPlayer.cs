using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KEVIN
{
    public class MusicPlayer
    {
        public string openString;
        public string playString;
        public string pauseString;
        public string stopString;
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        public void Open(string file)
        {
            openString = "open \"" + file + "\" type MPEGVideo alias CurrentlyPlaying";
            mciSendString(openString, null, 0, 0);
        }

        public void Play()
        {
            playString = "play CurrentlyPlaying";
            mciSendString(playString, null, 0, 0);
        }

        public void Pause()
        {
            pauseString = "stop CurrentlyPlaying";
            mciSendString(pauseString, null, 0, 0);
        }

        public void Stop()
        {
            stopString = "stop CurrentlyPlaying";
            mciSendString(stopString, null, 0, 0);

            stopString = "close CurrentlyPlaying";
            mciSendString(stopString, null, 0, 0);
        }
        public void Repeat(int timeLeft)
        {
            playString += " REPEAT";
            System.Threading.Thread.Sleep(timeLeft * 1000);
            mciSendString(playString, null, 0, 0);
        }
    }
}
