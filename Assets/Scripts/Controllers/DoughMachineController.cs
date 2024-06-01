using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Controllers
{
    public class DoughMachineController : MonoBehaviour, IStation
    {
        
        private PoolManager _poolManager;
        private Coroutine _doughMachineCoroutine;
        private float _spawnPosition = 0f;
        
        private void Awake()
        {
            _poolManager = PoolManager.Instance;
            Debug.Log("ObjectPooler instance obtained");
        }
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Dough Machine Triggered");
            if (!other.CompareTag("Player")) return;
            if (_doughMachineCoroutine != null) return;
            PlayerCollectibleManager player = other.GetComponent<PlayerCollectibleManager>();
            if (player != null)
            {
                _doughMachineCoroutine = StartCoroutine(GiveDoughPlayerContinuously(player));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (_doughMachineCoroutine != null)
            {
                StopCoroutine(_doughMachineCoroutine);
                _doughMachineCoroutine = null;
                _spawnPosition=0f;
            }
        }
        
        private IEnumerator GiveDoughPlayerContinuously(PlayerCollectibleManager player)
        {
            
            while (true)
            {
                if (player.state is not PlayerState.CarryingBread && player.CanCarryMore())
                {
                    player.state=PlayerState.CarryingDough;
                    GiveDougToPlayer(player);
                }
                else
                {
                    Debug.Log("Player is carrying bread or cannot carry more");
                    
                }
                yield return new WaitForSeconds(1f);
            }
        }
        
        private void GiveDougToPlayer(PlayerCollectibleManager player)
        {
            GameObject dough=_poolManager.SpawnFromPool("Dough", player.collectibleParent , new Vector3(0,_spawnPosition,0), player.collectibleParent.transform.rotation);
            _spawnPosition+= 0.03f;
            EventManager.Trigger(EventList.OnCollectiblePickUp);
        }

        public void HandlePlayerInteraction(PlayerController player)
        {
            throw new NotImplementedException();
        }

        public void ExecuteStationFunction()
        {
            throw new NotImplementedException();
        }
    }
}
