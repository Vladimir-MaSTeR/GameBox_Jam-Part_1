using PurpleSlayerFish.Core.Behaviours;
using PurpleSlayerFish.Core.Services.Pools.Config;
using UnityEngine;

namespace PurpleSlayerFish.Core.Services.Pools.PoolProvider
{
    public class BehaviourPoolProvider : AbstractPoolProvider<PoolData>
    {
        protected override string PoolerConfigName => "BehaviourPoolConfig";
        protected override string RootName => "[BehaviourPoolProvider]";

        protected override AbstractBehaviour CreatePooledItem(Transform parent, PoolData data)
        {
            _tempGameObject = Object.Instantiate(_assetProvider.Get<GameObject>(data.BundleName, data.PrefabName), parent);
            return _tempGameObject.GetComponent<AbstractBehaviour>();
        }
    }
}