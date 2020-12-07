using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        CountItems();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.IncrementScore();
        Destroy(gameObject);
    }

    private void CountItems()
    {
        if(tag == "item")
        {
            gameManager.CountItems();
        }
    }
}
