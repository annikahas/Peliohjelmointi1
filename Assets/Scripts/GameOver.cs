using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + Score.scoreNum;
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
