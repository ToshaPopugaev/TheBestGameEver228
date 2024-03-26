using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<Transform> _spawnerPoints;

     public List<Transform> patrolPoints;

     public EnemyAI enemyPrefab;

     public int enemiesMaxCount = 5;

     public PlayerController player;

     public float IncreaseEnemiesCountDelay = 30;

     public float delay = 3;

     private float _timeLastSpawned;

     public List<EnemyAI> _enemies;


     private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());

        _enemies = new List<EnemyAI>();

        Invoke("IncreaseEnemiesMaxCount", IncreaseEnemiesCountDelay);
    }

    private void IncreaseEnemiesMaxCount()
    {
      enemiesMaxCount++;
      Invoke("IncreaseEnemiesMaxCount", IncreaseEnemiesCountDelay);
    }

    private void Update()
    {
         CheckForDeadEnemies();

         CreateEnemy();
     }

     private void CheckForDeadEnemies()
     {
       for (var i = 0; i < _enemies.Count; i++)
         {
           if (_enemies[i].IsAlive()) continue;

           _enemies.RemoveAt(i);

           i--;
         }
     }

    private void CreateEnemy()
    {
        if (_enemies.Count >= enemiesMaxCount) return;

        if (Time.time - _timeLastSpawned < delay) return;

        var enemy = Instantiate(enemyPrefab);
        
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;

        enemy.player = player;

        enemy.patrolPoints = patrolPoints;

        _enemies.Add(enemy);

        _timeLastSpawned = Time.time;
    }
}
