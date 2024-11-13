using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : ClickableObject
{

   [SerializeField] private List<GameObject> UIObjects = new List<GameObject>();

   protected override void ClickHandler()
   {
      DisableUI();  
   }

   private void DisableUI()
   {
      if(UIObjects.Count == 0){return;}

      foreach(GameObject obj in UIObjects)
      {
         obj.SetActive(false);
      }
   }
   
    
}
