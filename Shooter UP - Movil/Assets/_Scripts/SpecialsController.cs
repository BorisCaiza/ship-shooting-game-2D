using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsController : MonoBehaviour
{
   [SerializeField] private GameObject laser;
   
   private Coroutine laserCouritine;
   
   
   
   public void UnlockSpecial(PickUpConfig config)
   {
      Debug.LogFormat("UnlockSpecial pickup type {0}", config.type);

      switch (config.type)
      {
         case PickupType.Laser:
           
            
            laser.SetActive(true);
            break;
         
      }
   }


   private IEnumerator DisableAfterSeconds(GameObject objectToDisable, float time)
   {
      yield return new WaitForSeconds(time);
      objectToDisable.SetActive(false);
}


}
