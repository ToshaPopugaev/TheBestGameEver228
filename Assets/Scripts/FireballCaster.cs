using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{  
    public FireballScript fireballPrefab;
    
    public Transform fireballSourceTransform;

    public float damage = 10;
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
         var fireball = Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);

         fireball.damage = damage;
        }
    }
}
