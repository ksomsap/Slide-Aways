using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    GameObject _player;
    // Use this for initialization
    void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
	}
}
