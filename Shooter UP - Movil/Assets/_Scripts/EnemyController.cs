using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{
  //[HideInInspector]
  public EnemyConfig config;
  public ShootingConfig _shootingConfig;

  [SerializeField] private SpriteRenderer spriteRendered;
  [SerializeField] private MultipleInstantiator multipleInstantiator;

  private Mover mover;

  private Shooter[] shooters;
  //private Transform target;


  private void Start()
  {
    mover = GetComponent<Mover>();
    if (mover != null)
    {
      mover.speed = config.moverSpeed;
    }

    //target = FindObjectOfType<PlayerController>().transform;

    if (config.sprite != null && spriteRendered !=null)
    {
      spriteRendered.sprite = config.sprite;
    }
    

  
    shooters = GetComponentsInChildren<Shooter>();
    if (shooters !=null && shooters.Length > 0)
    {
        foreach (var shooter in shooters)
        {
          StartCoroutine(ShootForever(shooter));
        }
    }
    
 

    
  }


  private IEnumerator ShootForever(Shooter shooter)
  {
    yield return new WaitForSeconds(shooter.ShootingConfig.shootInitialWaitTime);
    while (true)
    {
    
        shooter.DoShoot();
        yield return new WaitForSeconds(shooter.ShootingConfig.shootCadence);
      

   
    }
  }

  public void OnDie()
  {

    if (config != null && multipleInstantiator!= null && config.ShouldThorwPickup())
    {
      multipleInstantiator.InstantiateInSequence();
    }

    StopAllCoroutines();
    Debug.Log("Hey I die");
    GameController.Instance.OnDie(gameObject, config.score);
    
    

    //GameController.Instance.OnDie(gameObject);
  }

}

