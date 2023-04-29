using PurpleSlayerFish.Core.Services.EffectsManager;
using PurpleSlayerFish.Core.Services.ScriptableObjects.GameConfig;
using PurpleSlayerFish.Core.Ui.Container;
using UnityEngine;
using Zenject;

namespace PurpleSlayerFish.Game.Behaviours
{
    public class TestBehaviour : MonoBehaviour
    {
        [Inject] private GameConfig _gameConfig;
        [Inject] private IUiContainer _uiContainer;
        [Inject] private EffectsManager _effectsManager;

        private void Awake()
        {
        }

        private void Start()
        {
        }
        
        private void Update()
        {
        }

        private void LateUpdate()
        {
        }
    }
}