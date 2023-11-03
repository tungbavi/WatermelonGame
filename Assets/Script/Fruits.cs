using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruits : MonoBehaviour
{
   
    private string inthespawnPos = "y";
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.y < Spawn.pointPos.y)
        {
            inthespawnPos = "n";
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }
  
    // Update is called once per frame
    void Update()
    {
       
       
        if(inthespawnPos == "y")
        {
            GetComponent<Transform>().position = Spawn.pointPos;
        }
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
           // GetComponent<Rigidbody2D>().gravityScale = 0;
            if (GetComponent<Rigidbody2D>().gravityScale == 0)
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
                inthespawnPos = "n";
                //Spawn.spawned = "n";
                count = 0;
              
            }
          
        
        }

        Debug.Log(count);
        //Debug.Log(hasCollided);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 

        if (collision.gameObject.tag != "colliderr")
           
        {
           

            if (GetComponent<Rigidbody2D>().gravityScale == 1)
            {
                count++;
                if (count == 1)
                {
                    //hasCollided = true;
                    GetComponent<Rigidbody2D>().gravityScale = 2;
                    Spawn.spawned = "n";

                }
            }
            if (collision.gameObject.tag == gameObject.tag)
            {
                if (Spawn.whichFruit < 9)
                {
                    Spawn.spawnPos = transform.position;
                    Spawn.newFruit = "y";
                    Spawn.whichFruit = int.Parse(gameObject.tag);
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                

            }

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("checkline") && GetComponent<Rigidbody2D>().gravityScale == 2)
        { 
            Spawn.instance.Line.active = true;
        }
        if (collision.CompareTag("line") && GetComponent<Rigidbody2D>().gravityScale == 2)
        {
            Time.timeScale = 0;
            Spawn.instance.btnPlay.gameObject.SetActive(true);
            Spawn.instance.btnExit.gameObject.SetActive(true);
            Spawn.instance.gameover.gameObject.SetActive(true);
            ClearFruitsByTag("0");
            ClearFruitsByTag("1");
            ClearFruitsByTag("2");
            ClearFruitsByTag("3");
            ClearFruitsByTag("4");
            ClearFruitsByTag("5");
            ClearFruitsByTag("6");
            ClearFruitsByTag("7");
            ClearFruitsByTag("8");

        }
        

    }
    private void ClearFruitsByTag(string tag)
    {
        GameObject[] fruits = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject fruit in fruits)
        {
            Destroy(fruit);
        }
    }

}
