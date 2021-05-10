using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreNum;
    Text score;

    void Start()
    {
        scoreNum = 0;
        score = GetComponent<Text>();
    }

    private void Update()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        score.text = "Score: " + scoreNum;
    }
}
