using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    private float speed = 15.0f;
  
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        if (gameManager.isgameActive)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }

        if(transform.position.x>15)
        {
            transform.position = currentPos;
        }


        if (transform.position.x < -15)
        {
            transform.position = currentPos;
        }
    }
}
