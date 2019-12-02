using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController2 : MonoBehaviour
{

    GameObject _player;
    Generator _generator;

    PlayerController player;
    bool checkDest = false;

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
        }
       // else
       // {
       //     Debug.Log("Missing Player...........");
       // }
    }

    void DestroyTile()
    {
        Destroy(this.gameObject, 2f);
        checkDest = true;
    }
}
