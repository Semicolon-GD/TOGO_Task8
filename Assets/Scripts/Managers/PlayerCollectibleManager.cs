using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibleManager : MonoBehaviour
{
   [SerializeField] public Transform collectibleParent;
   [SerializeField] private float maxCollectibleCount=5;
   
   public PlayerState state=PlayerState.Empty;
   
   private int _collectibleCount=0;

   private void OnEnable()
   {
      EventManager.Subscribe(EventList.OnCollectiblePickUp, IncreaseCollectibleCount);
   }

   private void IncreaseCollectibleCount()
   {
      _collectibleCount++;
      CanCarryMore();
   }

   private void Start()
   {
     
      
   }

   public bool CanCarryMore()
   {
      return !(_collectibleCount < maxCollectibleCount);
   }
}
