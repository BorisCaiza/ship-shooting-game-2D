using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnerController : MonoBehaviour
{
    [SerializeField] private List<EnemyWavesConfig> wavesConfig;
    [SerializeField] private Quaternion spawnRotation;
    [SerializeField] private float initialWaitTime;
    [SerializeField] private float cadenceBetweenWaves;

    
    
    private void Start()
    {
        GameController.Instance.OnEnemyDie += OnEnemyDie;
       StartCoroutine( EnemySpawnerCoroutine());
    }

    public void OnDestroy()
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.OnEnemyDie -= OnEnemyDie;
        }
    }

    public void OnEnemyDie(GameObject corpose)
    {
        Debug.LogFormat("Spawner COntroller, I have detected on of my luttle spawns have Die :c   name = {0}", corpose.name);
    }

    private IEnumerator EnemySpawnerCoroutine()
    {
        yield return new WaitForSeconds(initialWaitTime);
        foreach (var wave in wavesConfig)
        {
            
            foreach (var enemy in wave.enemies)
            {
                Vector3 enemyPosition = Vector3.zero;
                if (enemy.useSpecificPosition)
                {
                    enemyPosition = enemy.spwanReferencePosition;
                }
                else
                {
                    enemyPosition = new Vector3(Random.Range(-enemy.spwanReferencePosition.x, enemy.spwanReferencePosition.x)
                        , enemy.spwanReferencePosition.y, enemy.spwanReferencePosition.z);
                }
            
                SpawnEnemey(enemy.enemyPrefab,enemy.config,enemyPosition, spawnRotation);
                yield return new WaitForSeconds(wave.cadence);
            }
            yield return new WaitForSeconds(cadenceBetweenWaves);
        }

 
    }

    public void SpawnEnemey(EnemyController enemyPrefab, EnemyConfig config,  Vector3 enemyPosition, Quaternion rotation)
    {
       var enemyInstance =  Instantiate(enemyPrefab, enemyPosition, rotation);
       enemyInstance.config = config;


    }
}
