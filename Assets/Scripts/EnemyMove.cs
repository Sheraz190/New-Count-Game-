using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameObject.transform.position.y < -3||gameManager.isgameActive==false)
        {
            Destroy(gameObject);

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.DecPlayerLife();

            Destroy(gameObject);
        


        }

    }


}
