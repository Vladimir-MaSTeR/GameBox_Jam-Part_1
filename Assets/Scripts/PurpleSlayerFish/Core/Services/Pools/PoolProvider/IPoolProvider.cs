using PurpleSlayerFish.Core.Behaviours;
using PurpleSlayerFish.Core.Services.Pools.Config;
using UnityEngine;
using UnityEngine.Pool;

namespace PurpleSlayerFish.Core.Services.Pools.PoolProvider
{
    public interface IPoolProvider<T> where T : PoolData
    {
        void Install();
        AbstractBehaviour Get(string poolKey);
        void Release(string poolKey, AbstractBehaviour view);
    }
    
    public class TransformPool
    {
        public Transform Transform { get; }
        public IObjectPool<AbstractBehaviour> ObjectPool { get; }

        public TransformPool(Transform transform, IObjectPool<AbstractBehaviour> objectPool)
        {
            Transform = transform;
            ObjectPool = objectPool;
        }
    }
}