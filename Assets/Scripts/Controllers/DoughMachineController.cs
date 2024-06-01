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
        private Vector3 _spawnPosition;
        
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
            if (_doughMachineCoroutine == null)
            {
                PlayerCollectibleManager player = other.GetComponent<PlayerCollectibleManager>();
                if (player != null)
                {
                    
                    _spawnPosition=player.collectibleParent.position+Vector3.up*2f;
                    _doughMachineCoroutine = StartCoroutine(GiveDoughPlayerContinuously(player));
                }
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (_doughMachineCoroutine != null)
            {
                StopCoroutine(_doughMachineCoroutine);
                _doughMachineCoroutine = null;
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
                yield return new WaitForSeconds(1f);
            }
        }
        
        private void GiveDougToPlayer(PlayerCollectibleManager player)
        {
            Debug.Log(_spawnPosition);
            GameObject dough=_poolManager.SpawnFromPool("Dough", player.collectibleParent , player.collectibleParent.position, player.collectibleParent.transform.rotation);
            _spawnPosition+=Vector3.up*2f;
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
