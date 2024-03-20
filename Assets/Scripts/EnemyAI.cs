using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
   public List<Transform> patrolPoints;
  
   private NavMeshAgent _navMeshAgent;

   private bool _isPlayerNoticed;

   public PlayerController player;

   public float viewAngle;

   private void Start()
   {
      InitComponentLinks();
      PickNewPatrolPoint();
   }

   private void InitComponentLinks()
   {
        _navMeshAgent = GetComponent<NavMeshAgent>();
   }

   private void Update() 
  {
  NoticePlayerUptade();
  PatrolUptade();
  }

  private void NoticePlayerUptade()
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
      
        ChaseUptade();
     }
   }
   }

     private void PatrolUptade()
   {
       if (! _isPlayerNoticed)
       {
         if (_navMeshAgent.remainingDistance == 0)
         {
             PickNewPatrolPoint();
         }
       }
   }

   private void PickNewPatrolPoint()
   {  
      _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
   }
    
   private void ChaseUptade()
   {
    if (_isPlayerNoticed)
    {
        _navMeshAgent.destination = player.transform.position;
    }
   }
  }
  
  