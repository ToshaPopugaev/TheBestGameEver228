using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public float value = 100;

   public PlayerProgress playerProgress;

   public bool IsAlive()
   {
     return value > 0;
   }

   public void DealDamage(float damage)
   {
          playerProgress.AddExperience(damage);
		  value -= damage;
		  if (value <= 0)
		  {
				Destroy(gameObject);
		  }
   }

   private void Start()
   {
		  playerProgress = FindObjectOfType<PlayerProgress>();
   }
}
