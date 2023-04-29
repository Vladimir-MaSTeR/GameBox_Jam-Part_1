using UnityEngine;

namespace PurpleSlayerFish.Game.Behaviours.Movement
{
    public abstract class AbstractMovement : MonoBehaviour
    {
        public abstract void Movement(Vector3 direction);
    }
}