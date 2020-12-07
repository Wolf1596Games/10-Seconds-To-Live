using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int totalItems;
    [SerializeField] int score;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void CountItems()
    {
        totalItems++;
    }

    public void IncrementScore()
    {
        score++;
    }
}
