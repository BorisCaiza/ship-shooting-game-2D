using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInstantiator : MonoBehaviour
{
   [SerializeField] private List<Instantiator> instantiators;
   [SerializeField] private float delay;

   public int InstantiatorCount
   {
      get { return instantiators.Count;  }
   }

   public void InstantiateInSequence()
   {
      StartCoroutine(InstantiatorSequence());
   }

   public void InstantiateByIndex(int index)
   {
      if (index < 0 || index >= instantiators.Count )
      {
            Debug.LogErrorFormat("Cant Instiate with index {0}. Indicate an index between 0 and {1}", index, instantiators.Count);

            var instantiator = instantiators[index];
            instantiator.DoInstantiate();
            
      }
   }

   private IEnumerator InstantiatorSequence()
   {
      foreach (var instantiator in instantiators)
      {
         instantiator.DoInstantiate();
         yield return new WaitForSeconds(delay);
      }
   }

}
