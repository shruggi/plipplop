﻿/*
 * Copyright 2008 Matthias Sessler
 * 
 * This file is part of LibMpc.net.
 *
 * LibMpc.net is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 2.1 of the License, or
 * (at your option) any later version.
 *
 * LibMpc.net is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with LibMpc.net.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Text;

namespace Libmpc
{
  /// <summary>
  /// The possible states of the MPD.
  /// </summary>
  public enum MpdState
  {
    /// <summary>
    /// The state of the MPD could not be translated into this enumeration.
    /// </summary>
    Unknown,

    /// <summary>
    /// The MPD is playing a track.
    /// </summary>
    Play,

    /// <summary>
    /// The MPD is not playing a track.
    /// </summary>
    Stop,

    /// <summary>
    /// The playback of the MPD is currently paused.
    /// </summary>
    Pause
  }

  /// <summary>
  /// The MpdStatus class contains all values describing the current status of the MPD.
  /// </summary>
  public class MpdStatus
  {
    private readonly int audioBits;
    private readonly int audioChannels;
    private readonly int audioSampleRate;
    private readonly int bitrate;
    private readonly string error;
    private readonly int playlist;
    private readonly int playlistLength;
    private readonly bool random;
    private readonly bool repeat;
    private readonly int song;
    private readonly int songId;
    private readonly MpdState state;
    private readonly int timeElapsed;
    private readonly int timeTotal;
    private readonly int updatingDb;
    private readonly int volume;
    private readonly int xFade;

    /// <summary>
    /// Creates a new MpdStatus object.
    /// </summary>
    /// <param name="volume">The current volume of the output.</param>
    /// <param name="repeat">If the playlist is repeated after finish.</param>
    /// <param name="random">If the playlist is played in random order.</param>
    /// <param name="playlist">The version number of the playlist.</param>
    /// <param name="playlistLength">The length of the playlist.</param>
    /// <param name="xFade">The number of seconds crossfaded between song changes.</param>
    /// <param name="state">The state of the MPD.</param>
    /// <param name="song">The index of the currently played song in the playlist.</param>
    /// <param name="songId">The id of the song currently played.</param>
    /// <param name="timeElapsed">The number of seconds already played of the current song.</param>
    /// <param name="timeTotal">The length of the current song in seconds.</param>
    /// <param name="bitrate">The bitrate of the current song.</param>
    /// <param name="audioSampleRate">The audio sample rate of the current song.</param>
    /// <param name="audioBits">The audio bits of the current song.</param>
    /// <param name="audioChannels">The number of audio channels of the current song.</param>
    /// <param name="updatingDb">The number of the update on the MPD database currently running.</param>
    /// <param name="error">An error message, if there is an error.</param>
    public MpdStatus(
      int volume,
      bool repeat,
      bool random,
      int playlist,
      int playlistLength,
      int xFade,
      MpdState state,
      int song,
      int songId,
      int timeElapsed,
      int timeTotal,
      int bitrate,
      int audioSampleRate,
      int audioBits,
      int audioChannels,
      int updatingDb,
      string error
      )
    {
      this.volume = volume;
      this.repeat = repeat;
      this.random = random;
      this.playlist = playlist;
      this.playlistLength = playlistLength;
      this.xFade = xFade;
      this.state = state;
      this.song = song;
      this.songId = songId;
      this.timeElapsed = timeElapsed;
      this.timeTotal = timeTotal;
      this.bitrate = bitrate;
      this.audioSampleRate = audioSampleRate;
      this.audioBits = audioBits;
      this.audioChannels = audioChannels;
      this.updatingDb = updatingDb;
      this.error = error;
    }

    /// <summary>
    /// The current volume of the output.
    /// </summary>
    public int Volume
    {
      get { return volume; }
    }

    /// <summary>
    /// If the playlist is repeated after finish.
    /// </summary>
    public bool Repeat
    {
      get { return repeat; }
    }

    /// <summary>
    /// If the playlist is played in random order.
    /// </summary>
    public bool Random
    {
      get { return random; }
    }

    /// <summary>
    /// The version number of the playlist.
    /// </summary>
    public int Playlist
    {
      get { return playlist; }
    }

    /// <summary>
    /// The length of the playlist.
    /// </summary>
    public int PlaylistLength
    {
      get { return playlistLength; }
    }

    /// <summary>
    /// The number of seconds crossfaded between song changes.
    /// </summary>
    public int XFade
    {
      get { return xFade; }
    }

    /// <summary>
    /// The state of the MPD.
    /// </summary>
    public MpdState State
    {
      get { return state; }
    }

    /// <summary>
    /// The index of the currently played song in the playlist.
    /// </summary>
    public int Song
    {
      get { return song; }
    }

    /// <summary>
    /// The id of the song currently played.
    /// </summary>
    public int SongId
    {
      get { return songId; }
    }

    /// <summary>
    /// The number of seconds already played of the current song.
    /// </summary>
    public int TimeElapsed
    {
      get { return timeElapsed; }
    }

    /// <summary>
    /// The length of the current song in seconds.
    /// </summary>
    public int TimeTotal
    {
      get { return timeTotal; }
    }

    /// <summary>
    /// The bitrate of the current song.
    /// </summary>
    public int Bitrate
    {
      get { return bitrate; }
    }

    /// <summary>
    /// The audio sample rate of the current song.
    /// </summary>
    public int AudioSampleRate
    {
      get { return audioSampleRate; }
    }

    /// <summary>
    /// The audio bits of the current song.
    /// </summary>
    public int AudioBits
    {
      get { return audioBits; }
    }

    /// <summary>
    /// The number of audio channels of the current song.
    /// </summary>
    public int AudioChannels
    {
      get { return audioChannels; }
    }

    /// <summary>
    /// The number of the update on the MPD database currently running.
    /// </summary>
    public int UpdatingDb
    {
      get { return updatingDb; }
    }

    /// <summary>
    /// An error message, if there is an error.
    /// </summary>
    public string Error
    {
      get { return error; }
    }

    /// <summary>
    /// Returns a string representation of the object maily for debugging purpuses.
    /// </summary>
    /// <returns>A string representation of the object.</returns>
    public override string ToString()
    {
      var builder = new StringBuilder();

      appendInt(builder, "volume", volume);
      appendBool(builder, "repeat", repeat);
      appendBool(builder, "random", random);
      appendInt(builder, "playlist", playlist);
      appendInt(builder, "playlistlength", playlistLength);
      appendInt(builder, "xfade", xFade);
      switch (state)
      {
        case MpdState.Play:
          builder.AppendLine("state: play");
          break;
        case MpdState.Pause:
          builder.AppendLine("state: pause");
          break;
        case MpdState.Stop:
          builder.AppendLine("state: stop");
          break;
      }
      appendInt(builder, "song", song);
      appendInt(builder, "songid", songId);
      if ((timeElapsed >= 0) || (timeTotal >= 0))
      {
        builder.Append("time: ");
        builder.Append(timeElapsed);
        builder.Append(":");
        builder.Append(timeTotal);
        builder.AppendLine();
      }
      appendInt(builder, "bitrate", bitrate);
      if ((audioSampleRate >= 0) || (audioBits >= 0) || (audioChannels >= 0))
      {
        builder.Append("audio: ");
        builder.Append(audioSampleRate);
        builder.Append(":");
        builder.Append(audioBits);
        builder.Append(":");
        builder.Append(audioChannels);
        builder.AppendLine();
      }
      appendInt(builder, "updating_db", updatingDb);
      if (error != null)
      {
        builder.Append("error: ");
        builder.AppendLine(error);
      }

      return builder.ToString();
    }

    private static void appendInt(StringBuilder builder, string name, int value)
    {
      if (value < 0)
        return;

      builder.Append(name);
      builder.Append(": ");
      builder.Append(value);
      builder.AppendLine();
    }

    private static void appendBool(StringBuilder builder, string name, bool value)
    {
      builder.Append(name);
      builder.Append(": ");
      builder.Append(value ? '1' : '0');
      builder.AppendLine();
    }
  }
}