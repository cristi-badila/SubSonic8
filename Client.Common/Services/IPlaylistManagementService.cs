﻿namespace Client.Common.Services
{
    using System.ComponentModel;

    using Caliburn.Micro;

    using Client.Common.EventAggregatorMessages;
    using Client.Common.Models;

    public interface IPlaylistManagementService : IHandle<JumpToNextMessage>,
                                                  IHandle<JumpToPreviousMessage>,
                                                  IHandle<PlayNextMessage>,
                                                  IHandle<AddItemsMessage>,
                                                  IHandle<ToggleShuffleMessage>,
                                                  IHandle<RemoveItemsMessage>,
                                                  IHandle<PlayPauseMessage>,
                                                  IHandle<PlayItemAtIndexMessage>,
                                                  IHandle<StopMessage>,
                                                  IHandle<PauseMessage>,
                                                  IHandle<PlayMessage>,
                                                  IHandle<ToggleRepeatMessage>,
                                                  INotifyPropertyChanged
    {
        #region Public Properties

        PlaylistItem CurrentItem { get; }

        bool HasElements { get; }

        bool IsPlaying { get; }

        PlaylistItemCollection Items { get; }

        bool ShuffleOn { get; }

        #endregion

        #region Public Methods and Operators

        void Clear();

        void LoadPlaylist(PlaylistItemCollection playlistItemCollection);

        string GetStateAsString();

        #endregion

        void SetStateFromString(string stateString);
    }
}