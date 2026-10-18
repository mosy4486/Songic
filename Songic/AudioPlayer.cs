using System;
using System.Collections.Generic;
using System.Text;
using NAudio.Wave;

namespace Songic
{
    public class AudioPlayer : IDisposable
    {
        private WaveOutEvent? output;
        private AudioFileReader? audio;
        private string? currentPath;

        public bool isPlaying => output?.PlaybackState == PlaybackState.Playing;
        public double CurrentTime => audio?.CurrentTime.TotalSeconds ?? 0;
        public double Duration => audio?.TotalTime.TotalSeconds ?? 0;

        public void PlayAudio(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("음악 파일이 없습니다.", path);

            if (currentPath != path || audio == null || output == null)
            {
                StopAudio();

                audio = new AudioFileReader(path);
                output = new WaveOutEvent();
                output.Init(audio);
                currentPath = path;
            }

            if (audio.Position >= audio.Length) audio.Position = 0;

            if (isPlaying) return;

            output.Play();
        }

        public void PauseAudio()
        {
            output?.Pause();
        }

        public void StopAudio()
        {
            output?.Stop();
            output?.Dispose();
            audio?.Dispose();

            output = null;
            audio = null;
            currentPath = null;
        }

        public void SetTime(double seconds)
        {
            if (audio == null) return;
            audio.CurrentTime = TimeSpan.FromSeconds(Math.Clamp(seconds, 0, Duration));
        }

        public void SetVolume(float volume)
        {
            if (audio == null) return;
            audio.Volume = Math.Clamp(volume, 0f, 1f);
        }

        public void Dispose()
        {
            StopAudio();
        }
    }
}
