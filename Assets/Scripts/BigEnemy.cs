using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float hitpoints;
    public float maxhp = 5;

    public Transform player;
    public float enemyDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    void Start()
    {
        waitTime = startWaitTime;

        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        hitpoints = maxhp;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > enemyDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

            if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if(waitTime <= 0)
                {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
                }
                else
                {
                waitTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            transform.position = this.transform.position;

            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        if(hitpoints <= 0)
        {
            Destroy(gameObject);
            Score.scoreNum += 500;
            spawner.BigEnemyNum--;
        }
    }
}
