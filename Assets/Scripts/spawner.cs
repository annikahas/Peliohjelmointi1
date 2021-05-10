using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject Enemy, Pickup, HPPack, Ammo, BigEnemy;
    public float spawnrateEnemy = 2f;
    public float spawnratePickup = 10f;
    public float spawnrateBigEnemy = 20f;
    float nextSpawnEnemy = 0f;
    float nextSpawnPickup = 0f;
    float nextSpawnBigEnemy = 0f;

    float randX, randY;
    Vector2 whereToSpawn;

    /*public float spawnCollision;
    public Collider2D[] colliders;
    public float radius;
    int whatToSpawn;
     */

    public static int BigEnemyNum;
    public static int PickUpNum;

    private void Update()
    {
        //randomized spawn
        /*if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);
            Debug.Log(whatToSpawn);

            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(Pickup, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(HPPack, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Ammo, transform.position, Quaternion.identity);
                    break;
            }

            nextSpawn = Time.time + spawnrate;
        }*/


        //bool canSpawnHere = false;
        //int safetyNet = 0;
        Vector3 spawnPos = new Vector3(0, 0,0);

        if(Time.time > nextSpawnEnemy)
        {
            nextSpawnEnemy = Time.time + spawnrateEnemy;

            randX = Random.Range(-24f, 24f);
            randY = Random.Range(11, -12);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Enemy, whereToSpawn, Quaternion.identity);
            /*whereToSpawn = new Vector2(randX, randY);
            canSpawnHere = PreventSpawnOverLap(whereToSpawn);*/

            /* tried to avoid spawning on top of walls
             * while (!canSpawnHere) 
            {
                randX = Random.Range(-24f, 24f);
                randY = Random.Range(11, -12);
                whereToSpawn = new Vector2(randX, randY);
                canSpawnHere = PreventSpawnOverLap(spawnPos);

                if(canSpawnHere)
                {
                    break;
                }
                safetyNet++;

                if(safetyNet > 50)
                {
                    break;
                    Debug.Log("Too many attempts");
                }
            }
            Instantiate(Enemy, whereToSpawn, Quaternion.identity);*/
        }

        if(Time.time > nextSpawnPickup)
        {
            if(PickUpNum < 10)
            {
                nextSpawnPickup = Time.time + spawnratePickup;

                randX = Random.Range(-24f, 24f);
                randY = Random.Range(11, -12);
                whereToSpawn = new Vector2(randX, randY);
                Instantiate(Pickup, whereToSpawn, Quaternion.identity);
                PickUpNum++;

                randX = Random.Range(-24f, 24f);
                randY = Random.Range(11, -12);
                whereToSpawn = new Vector2(randX, randY);
                Instantiate(HPPack, whereToSpawn, Quaternion.identity);
                PickUpNum++;

                randX = Random.Range(-24f, 24f);
                randY = Random.Range(11, -12);
                whereToSpawn = new Vector2(randX, randY);
                Instantiate(Ammo, whereToSpawn, Quaternion.identity);
                PickUpNum++;
            }

        }

        if(Time.time > nextSpawnBigEnemy)
        {
            if(BigEnemyNum < 1)
            {
                nextSpawnBigEnemy = Time.time + spawnrateBigEnemy;

                randX = Random.Range(1f, 23f);
                randY = Random.Range(11, -11);
                whereToSpawn = new Vector2(randX, randY);
                Instantiate(BigEnemy, whereToSpawn, Quaternion.identity);
                BigEnemyNum++;
            }

        }


    }

    /* tried to avoid spawning on top of walls
    bool PreventSpawnOverLap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for(int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if(spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if(spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            } 
        }
        return true;
    }*/
}
