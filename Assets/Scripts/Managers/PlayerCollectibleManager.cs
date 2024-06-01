using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibleManager : MonoBehaviour
{
   [SerializeField] public Transform collectibleParent;
   
   public PlayerState state=PlayerState.Empty;

   private void Start()
   {
     
      
   }

   public bool CanCarryMore()
   {
      return true;
   }
}
