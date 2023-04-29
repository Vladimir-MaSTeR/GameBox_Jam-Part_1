using Cinemachine;
using PurpleSlayerFish.Core.Global;
using PurpleSlayerFish.Core.Services.AssetProvider;
using PurpleSlayerFish.Core.Services.EffectsManager;
using PurpleSlayerFish.Core.Services.Input;
using PurpleSlayerFish.Core.Services.PauseService;
using PurpleSlayerFish.Core.Services.Pools.Config;
using PurpleSlayerFish.Core.Services.Pools.PoolProvider;
using PurpleSlayerFish.Core.Services.ScenePoints;
using PurpleSlayerFish.Core.Ui.AudioManager;
using PurpleSlayerFish.Core.Ui.Windows.GameWindow;
using PurpleSlayerFish.Game.Behaviours;
using Zenject;

namespace PurpleSlayerFish.Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [Inject] private IAssetProvider _assetProvider;
        [Inject] private IInputProvider<InputData> _inputProvider;
        [Inject] private IPauseService _pauseService;
        [Inject] private CinemachineVirtualCamera _virtualCamera;
        [Inject] private IPoolProvider<PoolData> _poolProvider;
        [Inject] private EffectsManager _effectsManager;
        [Inject] private AudioManager _audioManager;
        [Inject] private SignalBus _signalBus;
        [Inject] private ScenePoints _scenePoints;

        public override void InstallBindings()
        {
            var player = _assetProvider.Instantiate<PlayerBehaviour>(GameGlobal.PREFABS_BUNDLE);
            _virtualCamera.Follow = player.transform;
            player.transform.position = _scenePoints.Points.Get("PLAYER_START").position;
            
            _inputProvider.Data.OnEscape += () => _pauseService.SetPause(!_pauseService.IsPaused);
            
            // test
            _inputProvider.Data.OnSpace += () => _poolProvider.Get("BombBehaviour").transform.position = player.transform.position;
            _inputProvider.Data.OnSpace += () => _effectsManager.CastExplosion(player.transform.position);
            _inputProvider.Data.OnSpace += () => _audioManager.PlayCloseSound();
            _inputProvider.Data.OnSpace += () => _audioManager.PlayTransitionAudio();
            _signalBus.Fire(new ScoreSubscription{Score = 100});
        }
    }
}