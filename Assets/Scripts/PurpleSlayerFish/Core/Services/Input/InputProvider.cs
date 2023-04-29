﻿using System;

namespace PurpleSlayerFish.Core.Services.Input
{
    public class InputProvider : IInputProvider<InputData>
    {
        public InputProvider()
        {
            Data = new InputData();
        }

        public InputData Data { get; }
    }

    public class InputData
    {
        public float VerticalAxis;
        public float HorizontalAxis;
        public Action OnSpace;
        public Action OnEscape;
    }
}