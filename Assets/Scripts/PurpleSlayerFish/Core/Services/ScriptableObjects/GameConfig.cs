using UnityEngine;

namespace PurpleSlayerFish.Core.Services.ScriptableObjects.GameConfig
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject//, IGameConfig
    {
        [Header("General options")]
        [SerializeField] private float _option1 = 0.55f;
        public float Option1 => _option1;
        [SerializeField] private float _option2 = 0.75f;
        public float Option2 => _option2;
    }
}