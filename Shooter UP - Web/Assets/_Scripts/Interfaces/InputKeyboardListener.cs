using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardListener : MonoBehaviour, IInputeabñe
{
    
 


   public void ShootPressed()
    {
        InputProvider.TriggerOnHasShoot();
    }

   public void GetDirection(Vector3 direction)
   {
      InputProvider.TriggerDirection(direction);
   }




   private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootPressed();
        }
        
        GetDirection(new Vector3(Input.GetAxis("Horizontal")  , Input.GetAxis("Vertical")));
    
    }
}
