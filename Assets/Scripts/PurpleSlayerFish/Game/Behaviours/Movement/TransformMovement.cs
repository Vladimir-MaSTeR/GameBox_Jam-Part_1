using UnityEngine;

namespace PurpleSlayerFish.Game.Behaviours.Movement
{
    public class TransformMovement : AbstractMovement
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed = 40f;
        
        public override void Movement(Vector3 direction)
        {
            _transform.position += direction * Time.deltaTime * _speed;
        }
    }
}