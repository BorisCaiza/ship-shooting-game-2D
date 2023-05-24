using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

static class Dice 
{


  public static bool IsChanceSucess( float chance)
  {

    if (chance == 0 )
    {
      return false;
    }
    var randomValue = UnityEngine.Random.Range(0, 1f);

    return (chance >= randomValue);
  }

}
