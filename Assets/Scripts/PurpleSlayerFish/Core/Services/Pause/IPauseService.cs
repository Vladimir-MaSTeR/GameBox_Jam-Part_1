﻿namespace PurpleSlayerFish.Core.Services.PauseService
{
    public interface IPauseService
    {
        bool IsPaused { get; set; }

        void SetPause(bool value);
    }
}