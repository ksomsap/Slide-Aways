using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    TileController _tilecontroller;

    private float sy = 0f;
    public static bool startGame = true;
    public float speedPlayer = 5f;
    bool gameOver = false;

    Rigidbody2D rb;

    public GameObject ScoreScreen;
    public GameObject GameOverScreen;
    public Text score;


    private int increedSpeed = 0;

    //Time
    public Text TimeText;
    public float n;

    //Touch and move
    private float pointA=0;
    private float pointB=0;


    // public TileController sn;  
    // Use this for initialization
    void Start ()
    {
        QualitySettings.vSyncCount = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
        n = 20;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Application.targetFrameRate = 2;
        // Movement from touch screen;
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pointB = Input.mousePosition.y;
            if(pointA == pointB)
            {
                print("Not Move it's equal");
            }
            else if ((pointA < pointB+ 10) && gameOver != true)
            {
                print("UP");
                sy += 3f;
                if (sy >= 3f)
                    sy = 3f;
                startGame = false;
            }
            else if ((pointA > pointB- 10) && gameOver != true)
            {
                print("DOWN");
                sy -= 3f;
                if (sy <= -3f)
                    sy = -3f;
                startGame = false;
            }
            else
            {
                print("Not Move");
            }
        }

        // Movement from button 'W' up and 'S' down
       /* if (Input.GetKeyDown(KeyCode.W) && gameOver != true)
        {
            sy += 3f;
            if (sy >= 3f)
                sy = 3f;
            startGame = false;
        }
        if(Input.GetKeyDown(KeyCode.S) && gameOver != true)
        {
            sy -= 3f;
            if (sy <= -3f)
                sy = -3f;
            startGame = false;
        }*/

        // Check start once player movement
        if(!startGame)
        {
            transform.position = new Vector3(transform.position.x, sy, 0f);
            Vector3 newPos = new Vector3(transform.position.x+speedPlayer, sy, 0f);
            transform.position = Vector3.Lerp(transform.position, newPos, 0.01f); 
            
            //TimeText.text = (int.Parse(TimeText.text) + 0.1f).ToString();
            //increedSpeed = int.Parse(TimeText.text);
            //print(increedSpeed);
            n -= Time.deltaTime;
            TimeText.text = Mathf.Round(n).ToString();
            if(n <= 0)
            {
                n = 20;
                speedPlayer += 2;
            }
        }      
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Death();
    }

    void Death()
    {
        GameOverScreen.SetActive(true);
        print("Player Died.................");
        speedPlayer = 0;
        gameOver = true;
        startGame = true;
    }

    public void CountScore()
    {
        ScoreScreen.SetActive(true);
        score.text = (int.Parse(score.text) + 1).ToString();
    }    
    /*IEnumerator FallTile(GameObject col)
    {
        yield return new WaitForSeconds(0.5f);
        col.AddComponent<Rigidbody2D>();
    }*/
}
