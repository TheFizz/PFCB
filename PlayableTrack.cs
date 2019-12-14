namespace PFCB
{
    public class PlayableTrack
    {
        public string trackCommand { get; set; }
        public string trackPath { get; set; }
        public string trackName { get; set; }

        public void Play(int vol)
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = trackPath;
            wplayer.settings.volume = vol;
            wplayer.controls.play();
        }
    }
}
