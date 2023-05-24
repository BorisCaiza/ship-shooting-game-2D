using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Rotator : MonoBehaviour
{
   public Vector3 rotationAxis;
   public float rotationSpeed;

   public void Update()
   {
      transform.Rotate(rotationAxis* (rotationSpeed * Time.deltaTime));
   }
}
