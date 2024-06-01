using UnityEngine;

namespace Controllers
{
    public class OvenBreadPickupController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") )
            {
                PlayerCollectibleManager player = other.GetComponent<PlayerCollectibleManager>();
                if (player.state is PlayerState.CarryingBread or PlayerState.Empty)
                {
                    EventManager.Trigger(EventList.PlayerInBreadPickup);
                }
           
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.Trigger(EventList.PlayerLeftBreadPickup);
            }
        }
    }
}
