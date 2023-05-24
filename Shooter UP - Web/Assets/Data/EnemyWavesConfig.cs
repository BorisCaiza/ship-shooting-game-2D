using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName ="Enemies/Wave Config", order = 0)]
public class EnemyWavesConfig : ScriptableObject
{
    [System.Serializable]
    public class EachEnemyConfig {
        public EnemyController enemyPrefab;
        public Vector3 spwanReferencePosition;
        public bool useSpecificPosition;
        public EnemyConfig config;
    }
    public List<EachEnemyConfig> enemies;
    public float cadence;
}
