using System;
using PurpleSlayerFish.Core.Behaviours;
using PurpleSlayerFish.Core.Services.Input;
using PurpleSlayerFish.Game.Behaviours.Movement;
using UnityEngine;
using Zenject;

namespace PurpleSlayerFish.Game.Behaviours
{
    public class PlayerBehaviour : AbstractBehaviour
    {
        [SerializeField] private AbstractMovement _movement;

        [Inject] private IInputProvider<InputData> _inputProvider;

        private void Update()
        {
            _movement.Movement(new Vector3(_inputProvider.Data.HorizontalAxis,_inputProvider.Data.VerticalAxis, transform.position.z).normalized);
        }
    }
}