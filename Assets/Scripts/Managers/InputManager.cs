using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : MonoBehaviour
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
            _playerInputs.GamePlay.HoldAction.started += ctx => OnHoldActionStarted(ctx);
            _playerInputs.GamePlay.HoldAction.performed += ctx => OnHoldActionPerformed(ctx);
            _playerInputs.GamePlay.HoldAction.canceled += ctx => OnHoldActionCanceled(ctx);
        }

        private void OnHoldActionCanceled(InputAction.CallbackContext ctx)
        {
           // Debug.Log("Hold Action Canceled "+ctx);
            EventManager.Trigger(EventList.OnScreenRelease);
            
        }

        private void OnHoldActionPerformed(InputAction.CallbackContext ctx)
        {
         //   Debug.Log("Hold Action Performed " + ctx);
            EventManager.Trigger(EventList.OnScreenHold);
        }

        private void OnHoldActionStarted( InputAction.CallbackContext context)
        {
          //  Debug.Log("Hold Action Started " + context);
           
        }
    }
}
