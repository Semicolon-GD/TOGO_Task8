using System;
using UnityEngine;
using PathCreation;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private float speed = 5f;


        private float _distanceTravelled;
        private float _playerSpeed=0;
        
        
        #region Event Subscriptions
        private void OnEnable()
        {
            EventManager.Subscribe(EventList.OnScreenHold, () => _playerSpeed = speed);
            EventManager.Subscribe(EventList.OnScreenRelease, () => _playerSpeed = 0);
        }
    
        private void OnDisable()
        {
            EventManager.Unsubscribe(EventList.OnScreenHold, () => _playerSpeed = speed);
            EventManager.Unsubscribe(EventList.OnScreenRelease, () => _playerSpeed = 0);
        }
        
        #endregion


        private void Update()
        {
            _distanceTravelled += _playerSpeed * Time.deltaTime;
            transform.position=pathCreator.path.GetPointAtDistance(_distanceTravelled);
            transform.rotation=pathCreator.path.GetRotationAtDistance(_distanceTravelled);
        }

      
    }
}
