using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionDo : MonoBehaviour
{
    [SerializeField] protected UnityEvent alwaysAction;

    protected GameObject collisionee;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        collisionee = other.gameObject;
       // Debug.LogFormat("Saving Collisone {0}", collisionee);
        alwaysAction.Invoke();
    }



    public virtual void DestroyCollisione()
    {
       // Debug.LogFormat("Saving Collisone {0}", collisionee);
        if (collisionee != null)
        {
            Destroy(collisionee);
        }
    }
}
