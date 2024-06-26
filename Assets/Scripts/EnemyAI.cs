﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
   public List<Transform> patrolPoints;
  
   private NavMeshAgent _navMeshAgent;

   private PlayerHealth _playerHealth;

   private bool _isPlayerNoticed;

   public PlayerController player;

   public float viewAngle;

   public float damage = 30;

   public EnemyHealth _enemyHealth;

   public bool IsAlive()
   {
     return _enemyHealth.IsAlive();
   }

   private void Start()
   {
      InitComponentLinks();
      PickNewPatrolPoint();
   }

   private void InitComponentLinks()
   {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _playerHealth = player.GetComponent<PlayerHealth>();

        _enemyHealth = GetComponent<EnemyHealth>();
   }

   private void Update() 
  {
  NoticePlayerUpdate();
  PatrolUpdate();
  AttackUpdate();
  ChaseUpdate();
  }

  private void AttackUpdate()
  {
    if (_isPlayerNoticed)
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.DealDamage(damage * Time.deltaTime);
        }
    }
  }

  private void NoticePlayerUpdate()
  {
   {
     var direction = player.transform.position - transform.position;

     _isPlayerNoticed = false;

     if(Vector3.Angle(transform.forward, direction) < viewAngle)
     {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, direction, out hit))
         {
            
           if(hit.collider.gameObject == player.gameObject)
           {
            _isPlayerNoticed = true;
           }
         }
      
        ChaseUpdate();
     }
   }
   }

     private void PatrolUpdate()
   {
       if (! _isPlayerNoticed)
       {
         if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
         {
             PickNewPatrolPoint();
         }
       }
   }

   private void PickNewPatrolPoint()
   {  
      _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
   }
    
   private void ChaseUpdate()
   {
    if (_isPlayerNoticed)
    {
        _navMeshAgent.destination = player.transform.position;
    }
   }
  }