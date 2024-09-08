using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private Animator animator;
    
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
            Debug.Log("Screen Pressed");
        }

        private void OnScreenPressEnded()
        {
            Debug.Log("Screen Press Ended");
        }
    }
}
