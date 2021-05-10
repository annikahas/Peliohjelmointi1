using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public int maxHealth = 100;
    public int currentHealth;

    public Healthbar healthBar;

    public GameOver GameOver;
    int maxPlatform = 0;

    bool alive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    private void Update()
    {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
    
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (alive)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

    }

    void FixedUpdate()
    {
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);*/

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectible")
        {
            Score.scoreNum += 100;
            Destroy(collision.gameObject);
            spawner.PickUpNum--;
        }

        if(collision.gameObject.CompareTag("HPpack"))
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
            spawner.PickUpNum--;
        }

        if (collision.tag == ("Ammopack"))
        {
            Ammo.ammoNum += 10;
            Destroy(collision.gameObject);
            spawner.PickUpNum--;
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(20);
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            GameOver.Setup(maxPlatform);
            alive = false;
            spawner.PickUpNum = 0;
            spawner.BigEnemyNum = 0;
        }
    }
}
