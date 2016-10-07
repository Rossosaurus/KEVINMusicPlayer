using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KEVIN
{
    class MusicPlayer
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        public void Open(string file)
        {
            string command = "open \"" + file + "\" type MPEGVideo alias CurrentlyPlaying";
            mciSendString(command, null, 0, 0);
        }

        public void Play()
        {
            string command = "play CurrentlyPlaying";
            mciSendString(command, null, 0, 0);


        }

        public void Pause()
        {
            string command = "stop CurrentlyPlaying";
            mciSendString(command, null, 0, 0);
        }

        public void Stop()
        {
            string command = "stop CurrentlyPlaying";
            mciSendString(command, null, 0, 0);

            command = "close CurrentlyPlaying";
            mciSendString(command, null, 0, 0);
        }
    }
}
