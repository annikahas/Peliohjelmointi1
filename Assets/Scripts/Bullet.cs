using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var BigEnemy = collision.collider.GetComponent<BigEnemy>();
        if(BigEnemy)
        {
            BigEnemy.TakeHit(1);
        }
        Destroy(gameObject);


    }
}
