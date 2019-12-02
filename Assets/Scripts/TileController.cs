using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    GameObject _player;
    Generator _generator;

    PlayerController player;
    public float countScore;
    bool checkDest = false;

    public AudioSource PassTile;

    Color[] standColor = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.white };

    void Start()
    {
        GameObject tile = this.gameObject;
        Renderer cr = tile.GetComponent<Renderer>();
        cr.material.SetColor("_Color", standColor[4]);
        checkDest = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        _generator = GameObject.Find("GenerateTile").GetComponent<Generator>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        PassTile = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.localPosition.x-1f < _player.transform.position.x && checkDest != true)
        {
            GameObject tile = this.gameObject;
            Renderer cr = tile.GetComponent<Renderer>();
            cr.material.SetColor("_Color", standColor[0]);

            DestroyTile();
            _generator.GenerateTiles();
            Debug.Log("Destroy and Generate Tile");
            countScore++;
            player.CountScore();
            
            //Sound
            PassTile.Play(0);


        }
        //else
       // {
        //    Debug.Log("Missing Player...........");
       // }
    }

    public float CountScores()
    {
        return countScore;
    }

    void DestroyTile()
    {
        Destroy(this.gameObject, 2f);
        checkDest = true;
    }
}
