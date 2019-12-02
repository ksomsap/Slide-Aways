using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject TilePrefabUp;
    public GameObject TilePrefabDown;
    public GameObject TilePrefabCen1;
    public GameObject TilePrefabCen2;
    private float xPos = 0f;

    public float point;
    // Use this for initialization
    void Start ()
    {
        for(int i=0; i<5; i++)
        {
            GenerateTiles();
        }        
	}

    public void GenerateTiles()
    {
        int random = Random.Range(0, 7);
        if(random <= 2)
        {
            GenerateTilesUp();
        }
        else if(random >= 3 && random <= 5)
        {
            GenerateTilesDown();
        }
        else
        {
            GenerateTilesCen();
        }
        xPos += 5;
    }

    void GenerateTilesUp()
    {
        Instantiate(TilePrefabUp, new Vector3(xPos, -6.86f, 0f), TilePrefabUp.transform.rotation);
    }
    void GenerateTilesDown()
    {
        Instantiate(TilePrefabDown, new Vector3(xPos, 6.8f, 0f), TilePrefabDown.transform.rotation);
    }
    void GenerateTilesCen()
    {
        Instantiate(TilePrefabCen1, new Vector3(xPos, 8.29f, 0f), TilePrefabCen1.transform.rotation);
        Instantiate(TilePrefabCen2, new Vector3(xPos, -8.29f, 0f), TilePrefabCen2.transform.rotation);
    }
}
