using UnityEngine;

namespace Controllers
{
    public class OvenDoughDropController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerCollectibleManager player = other.GetComponent<PlayerCollectibleManager>();
            if (other.CompareTag("Player") && player.state == PlayerState.CarryingDough)
            {
                EventManager.Trigger(EventList.PlayerInDoughDrop);
            }
        }

  
    }
}
