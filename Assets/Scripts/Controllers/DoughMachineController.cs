using System;
using Interfaces;
using UnityEngine;

namespace Controllers
{
    public class DoughMachineController : MonoBehaviour, IStation
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log("Dough Machine Triggered");
            if (!other.CompareTag("Player")) return;
            HandlePlayerInteraction(other.GetComponent<PlayerController>());
        }

        public void HandlePlayerInteraction(PlayerController player)
        {
            Debug.Log("Dough Machine Interaction");
        }

        public void ExecuteStationFunction()
        {
            throw new System.NotImplementedException();
        }
    }
}
