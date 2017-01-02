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

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public void Mute(frmKEVINMain frm)
        {
            SendMessageW(frm.Handle, WM_APPCOMMAND, frm.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        public void DecVol(frmKEVINMain frm)
        {
            SendMessageW(frm.Handle, WM_APPCOMMAND, frm.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public void IncVol(frmKEVINMain frm)
        { 
            SendMessageW(frm.Handle, WM_APPCOMMAND, frm.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }
    }
}
