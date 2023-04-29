using UnityEngine;

namespace PurpleSlayerFish.Core.Services.Pools.Config
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BehaviourPoolConfig", fileName = "BehaviourPoolConfig")]
    public class BehaviourPoolConfig : AbstractPoolConfig<PoolData>
    {
        [SerializeField] private PoolData[] _poolData;
        public override PoolData[] GetData => _poolData;
    }
}