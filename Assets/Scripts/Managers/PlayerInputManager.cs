using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInputs _playerInputs;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
        }
    
        private void OnEnable()
        {
            _playerInputs.Enable();
        }
    
        private void OnDisable()
        {
            _playerInputs.Disable();
        }

        private void Start()
        {
            _playerInputs.TouchScreen.Press.performed += ctx => OnPress(ctx);
            _playerInputs.TouchScreen.Press.canceled += ctx => EndPress(ctx);
        }

        private void EndPress(InputAction.CallbackContext context)
        {
            EventManager.Trigger(EventList.OnScreenPress);
        }

        private void OnPress(InputAction.CallbackContext context)
        {
            EventManager.Trigger(EventList.OnScreenPressEnded);
        }
   
    }
}
