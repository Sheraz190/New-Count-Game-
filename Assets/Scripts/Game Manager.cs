using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button restart;
    public List<GameObject> heart = new List<GameObject>();
    public GameObject[] Prefabtospawn;
    public TextMeshProUGUI Score;
    private Destroy destroy;
    public bool isgameActive;
    float spawnInterval = 1.5f;
    float spawnTime = 2.0f;
    public GameObject gameOver;
    public GameObject Scoretext;
    public int live = 3;
    public int ScoreCount = 0;
   // public TextMeshProUGUI liveText;
   // public GameObject liveObject;
    // Start is called before the first frame update
    void Start()
    {
        SetDataForFreshGame();
    }
    void SetDataForFreshGame()
    {
        isgameActive = true;
        live = 3;
        ScoreCount = 0;
        UpdateLifeImages();
        destroy = GameObject.Find("Red ball").GetComponent<Destroy>();
        InvokeRepeating("SpawnObjects", spawnInterval, spawnTime);
      
    }

    void SpawnObjects()
    {
        if (isgameActive)
        {
            float posX = Random.Range(-13, 13);
            Vector3 spawnPos = new Vector3(posX, 35, 8);
            int randomIndex = Random.Range(0, Prefabtospawn.Length);
            GameObject randomPrefab = Prefabtospawn[randomIndex];
            Instantiate(randomPrefab, spawnPos, Quaternion.identity);
        }
        
    }

    public void RestartButton()
    {
       
    
        live = 3;
        UpdateLifeImages();
        
        isgameActive = true;
        
        restart.gameObject.SetActive(false);

        gameOver.gameObject.SetActive(false);
        Scoretext.gameObject.SetActive(true);
    
    }


    // Update is called once per frame
    void Update()
    {


        //if (isgameActive)

        //{
        //    //liveText.text = "Remaining Lives are: " + live;
        //    Score.text = "Score: " + ScoreCount;
        //}

        //else
        //{
            //gameOver.gameObject.SetActive(true);
            //Scoretext.gameObject.SetActive(false);
            //liveObject.gameObject.SetActive(false);
        //}


        //if (live ==0)
        //{
        //    isgameActive = false;
        //}
    }
    public void UpdatePlayerScore()
    {
        if (isgameActive)
        {
            ScoreCount++;
            Score.text = "Score: " + ScoreCount;
        }
    }
    public void SetDataOnGameFalse()
    {
        isgameActive = false;
        restart.gameObject.SetActive(true);

        gameOver.gameObject.SetActive(true);
        Scoretext.gameObject.SetActive(false);
        ScoreCount = 0;
        Score.text = "Score: " + ScoreCount;
    }
    public void DecPlayerLife()
    {
        live--;
        UpdateLifeImages();
        if(live <= 0)
        {
            SetDataOnGameFalse();
        }
    }
    void UpdateLifeImages()
    {
        DisableAllHearts();
        for (int i = 0; i < live; i++)
        {
            heart[i].SetActive(true);
        }
    }
    void DisableAllHearts()
    {
        for (int i = 0; i < heart.Count; i++)
        {
            heart[i].SetActive(false);
        }
    }
}
