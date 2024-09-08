using Managers;
using UnityEngine;
using PathCreation;
#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private Animator animator;
        [SerializeField] private PathCreator pathCreator;

        private float _speed = 0f;
        private float _distanceTravelled;
    
        
        
        private void Update()
        {
            _distanceTravelled += _speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(_distanceTravelled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(_distanceTravelled);
        }
        private void OnEnable()
        {
            EventManager.Subscribe(EventList.OnScreenPress, OnScreenPress);
            EventManager.Subscribe(EventList.OnScreenPressEnded, OnScreenPressEnded);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe(EventList.OnScreenPress, OnScreenPress);
            EventManager.Unsubscribe(EventList.OnScreenPressEnded, OnScreenPressEnded);
        }

        private void OnScreenPress()
        {
            _speed = 8f;
            animator.SetBool("isWalking", true);
        }

        private void OnScreenPressEnded()
        {
            _speed = 0f;
            animator.SetBool("isWalking", false);
        }
    }
}
