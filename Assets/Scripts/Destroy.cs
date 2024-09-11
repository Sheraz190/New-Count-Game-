using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreCount = 0;


    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameObject.transform.position.y < -3||gameManager.isgameActive==false)
        {
            Destroy(gameObject);
            gameManager.live--;
          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isgameActive)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameManager.UpdatePlayerScore();
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Ground"))
            {
                gameManager.DecPlayerLife();
                Destroy(gameObject);
            }
        }
        
    }
}
