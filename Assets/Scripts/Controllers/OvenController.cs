using System;
using Interfaces;
using UnityEngine;

namespace Controllers
{
    public class OvenController : MonoBehaviour ,IStation
    {
        private void OnEnable()
        {
            /*EventManager.Subscribe(EventList.PlayerInBreadPickup, GivePlayerBread);
            EventManager.Subscribe(EventList.PlayerLeftBreadPickup, StopGivingBread);
            EventManager.Subscribe(EventList.PlayerInDoughDrop,TakeDoughFromPlayer);*/
            
        }

        private void OnDisable()
        {
            /*EventManager.Unsubscribe(EventList.PlayerInBreadPickup, GivePlayerBread);
            EventManager.Unsubscribe(EventList.PlayerLeftBreadPickup, StopGivingBread);
            EventManager.Unsubscribe(EventList.PlayerInDoughDrop,TakeDoughFromPlayer);*/
        }

        public void HandlePlayerInteraction(PlayerController player)
        {
            throw new System.NotImplementedException();
        }

        public void ExecuteStationFunction()
        {
            throw new System.NotImplementedException();
        }
    }
}
