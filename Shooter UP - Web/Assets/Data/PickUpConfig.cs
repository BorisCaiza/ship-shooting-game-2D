using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
   None, Laser, Shield
}

[CreateAssetMenu(fileName = "New PickuoConfig", menuName = "Player/Pickups", order = 1)]
public class PickUpConfig : ScriptableObject
{
   
   public PickupType type;
   public int score;
   public float durationInSeconds;

}
