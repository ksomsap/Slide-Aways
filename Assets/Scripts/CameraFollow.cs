using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private bool checkStart;
    private Transform playerTransform;

    public float offset = 7f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }

    void Update()
    {
        // Should not be below from ### this's check game start value when player movement.
        checkStart = PlayerController.startGame;
        Debug.Log("CHECK GAME START :: " + checkStart);
        //###

        if(!checkStart)
        {
            CameraMove();
        }
    }

    void CameraMove()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;

        temp.x += offset;
        transform.position = temp;
    }
}
