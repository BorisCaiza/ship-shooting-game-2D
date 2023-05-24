using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour
{
 [SerializeField] private Slider fill;

 private void Start()
 {
     OnPowerChanged(GameController.Instance.Player.GetCurrentPowerLevel(),
         GameController.Instance.Player.GetMaxPowerLevel());
  GameController.Instance.Player.OnPowerChanged += OnPowerChanged;
 }


 public void OnPowerChanged(int current, int total)
 {
     fill.value = (float) current / (float) total;
 }


 private void onDestroy()
 {
     if (GameController.Instance != null && GameController.Instance.Player!= null)
     {
         GameController.Instance.Player.OnPowerChanged -= OnPowerChanged;
     }
 }


}
