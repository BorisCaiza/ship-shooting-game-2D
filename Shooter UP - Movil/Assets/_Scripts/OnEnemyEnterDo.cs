using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyEnterDo : OnCollisionDo
{
    
    [SerializeField] private UnityEvent unignoredActions;
    [SerializeField] private List<String> tagsToIgnore;
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        alwaysAction.Invoke();
        foreach (var ignoreTag in tagsToIgnore)
        {
            if (collision.tag == ignoreTag)
            {
                return;
            }
        }
        unignoredActions.Invoke();
    }
    
   
    
    
    public override  void DestroyCollisione()
    {
       Debug.LogFormat("Enemy shoudnt do anything against collisionee. Ignoring.");
    }
}
