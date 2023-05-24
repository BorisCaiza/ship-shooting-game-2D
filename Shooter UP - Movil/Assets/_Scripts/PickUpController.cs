using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
   public PickUpConfig config;
  public void OnPickedUp()
  {
    GameController.Instance.OnPickedUp(this);
  }
}
