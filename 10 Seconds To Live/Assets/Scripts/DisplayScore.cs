using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] Text scoreText;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            if(gameManager.score == gameManager.totalItems)
            {
                scoreText.text = "You got " + gameManager.score.ToString() + " out of " + gameManager.totalItems.ToString() + " total items. \n\nCongratulations!";
            }
            else if(gameManager.score == 0)
            {
                scoreText.text = "You got " + gameManager.score.ToString() + " out of " + gameManager.totalItems.ToString() + " total items. \n\nBetter luck next time!";
            }
            else
            {
                scoreText.text = "You got " + gameManager.score.ToString() + " out of " + gameManager.totalItems.ToString() + " total items. \n\nGood job!";
            }
        }
        else
        {
            scoreText.text = gameManager.score.ToString();
        }
    }
}
