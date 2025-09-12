using UnityEngine;
using System;
using System.Collections;

public class FrogController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerUpdate();
    }

    void PlayerUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerMove(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerMove(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerMove(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerMove(Vector2.right);
        }
    }

    void PlayerMove(Vector2 _direction)
    {
        transform.position += (Vector3)_direction;
    }
}
