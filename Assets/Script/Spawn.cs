using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    public GameObject point;
    public Transform[] fruitObj;
    public static string spawned = "n";
    public static Vector2 pointPos = new Vector2(-.31f, 4.29f);
    public static Vector2 spawnPos;
    public static string newFruit = "n";
    public static int whichFruit = 0;
    public GameObject checkLine;
    public GameObject Line;
    public int score = 0;
    public Text textScore;
    public Button btnPlay;
    public Text gameover;
    public Button btnExit;
    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<Spawn>();

        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {

        btnPlay.gameObject.SetActive(false);
        btnExit.gameObject.SetActive(false);
        Line.active = false;
        gameover.gameObject.SetActive(false);
        spawnFruits();
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnFruits();
        replaceFruits();
        textScore.text = "SCORE: " + score;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = touch.position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                pointPos = point.transform.position;
                pointPos.x = worldPosition.x;
                point.transform.position = pointPos;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            pointPos = point.transform.position;
            pointPos.x = worldPosition.x;
            point.transform.position = pointPos;
        }

    }
    public void spawnFruits()
    {
        if (spawned == "n")
        {
            spawned = "y";
            StartCoroutine(spawnTimer());

        }
    }
    public void replaceFruits()
    {
        if (newFruit == "y")
        {
            newFruit = "n";
            if(whichFruit < 9)
            {
                Instantiate(fruitObj[whichFruit + 1], spawnPos, fruitObj[0].rotation);
                score += (whichFruit + 1);
            }
            else
            {
                score += (whichFruit+1);
            }
           
            //fruitObj[whichFruit + 1].gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;

        }
    }
    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(fruitObj[Random.Range(0, 4)], new Vector2(-.31f, 4.29f), fruitObj[0].rotation);
    }
    public void playAgain()
    {
        score = 0;
        gameover.gameObject.SetActive(false);
        Line.active = false;
        btnExit.gameObject.SetActive(false);
        Time.timeScale = 1;
        btnPlay.gameObject.SetActive(false);
       
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
