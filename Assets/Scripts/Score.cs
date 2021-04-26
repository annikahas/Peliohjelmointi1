using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //public Text scoreText;
    public static int scoreNum;
    Text score;

    void Start()
    {
        scoreNum = 0;
        //scoreText.text = "Score: " + scoreNum;
        score = GetComponent<Text>();
    }

 /*   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectible")
        {
            scoreNum += 100;
            //scoreText.text = "Score: " + scoreNum;
            Destroy(collision.gameObject);
        }
    }*/

    private void Update()
    {
        score.text = "Score: " + scoreNum;
    }
}
