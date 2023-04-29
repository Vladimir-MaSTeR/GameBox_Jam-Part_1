﻿using System;
using System.Threading.Tasks;
using Object = UnityEngine.Object;

namespace PurpleSlayerFish.Core.Ui.Windows
{
    public abstract class AbstractController<T> : AbstractController where T : AbstractWindow
    {
        protected T _window;

        public override bool IsShown => _window.Canvas != null && _window.Canvas.enabled;
        
        public override void Initialize(AbstractWindow window)
        {
            _window = (T) window;
            _window.Canvas.enabled = false;
            AfterInitialize();
        }

        public override async void Show()
        {
            _window.Canvas.enabled = true;
            await DynamicShow();
        }

        public override async void Hide()
        {
            await DynamicHide();
            if (_window.Canvas == null)
                return;
            _window.Canvas.enabled = false;
        }

        public override void SetInteractable(bool value) => _window.CanvasGroup.interactable = value;
        protected virtual async Task DynamicShow() {}
        protected virtual async Task DynamicHide() => await Task.Delay(0);

        public override void Dispose()
        {
            if (_window != null)
                Object.Destroy(_window.gameObject);
            _window = null;
        }
    }

    public abstract class AbstractController : IDisposable
    {
        public abstract void Initialize(AbstractWindow window);
        public abstract void Show();
        public abstract void Hide();
        public abstract void SetInteractable(bool value);
        public abstract bool IsShown { get; }

        protected virtual void AfterInitialize()
        {
        }

        public abstract void Dispose();
    }
}