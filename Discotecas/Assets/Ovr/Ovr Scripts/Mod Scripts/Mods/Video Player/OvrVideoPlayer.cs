/**
 * OVR Unity SDK License
 *
 * Copyright 2021 OVR
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * 1. The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * 2. All copies of substantial portions of the Software may only be used in connection
 * with services provided by OVR.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using UnityEngine.Video;

namespace Ovr
{
    public enum VideoPlayerModType
    {
        EnableAudioTrack,
        SetDirectAudioMute,
        SetDirectAudioVolume,
        SetTargetAudioSource
    }

    [System.Serializable]
    public class OvrVideoPlayer : OvrMod
    {
        public VideoPlayer videoPlayer;
        public VideoPlayerModType videoPlayerModType;

        public ushort trackIndex;

        [Header("Enable Audio Track")]
        public bool value;

        [Header("Set Direct Audio Mute")]
        public bool mute;
        [Header("Set Direct Audio Volume")]
        [Range(0, 1)]
        public float volume;
        [Header("Set Target Audio Source")]
        public AudioSource source;

        public override void Doit(Collider other)
        {
            switch (videoPlayerModType)
            {
                case VideoPlayerModType.EnableAudioTrack:
                    videoPlayer.EnableAudioTrack(trackIndex, value);
                    videoPlayer.Stop();
                    videoPlayer.Play();
                    break;
                case VideoPlayerModType.SetDirectAudioMute:
                    videoPlayer.SetDirectAudioMute(trackIndex, mute);
                    videoPlayer.Stop();
                    videoPlayer.Play();
                    break;
                case VideoPlayerModType.SetDirectAudioVolume:
                    videoPlayer.SetDirectAudioVolume(trackIndex, volume);
                    videoPlayer.Stop();
                    videoPlayer.Play();
                    break;
                case VideoPlayerModType.SetTargetAudioSource:
                    videoPlayer.SetTargetAudioSource(trackIndex, source);
                    videoPlayer.Stop();
                    videoPlayer.Play();
                    break;
            }
        }
    }
}