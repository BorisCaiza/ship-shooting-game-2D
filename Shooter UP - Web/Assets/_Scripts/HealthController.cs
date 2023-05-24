using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{

    public int health;

    [SerializeField] private UnityEvent onZeroHealthActions;

   

    public void OnDamage(int damageAmpunt)
    {
        health -= damageAmpunt;
    Debug.LogFormat("On Damage, current health is {0}", health );
        if (health <=0)
        {
            OnZeroHealth();
        }
    }

    public void OnZeroHealth()
    {
        Debug.LogFormat("Oh! I'm, dead! {0}", gameObject.name);
        if (onZeroHealthActions != null)
        {
            onZeroHealthActions.Invoke();
        }
    }
    
    public void SetHealth(int value)
    {
        health = value;
    }
}
