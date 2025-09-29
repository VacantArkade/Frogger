using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCycle : MonoBehaviour
{
    [Header("Motion")]
    public float moveSpeed = 2f;
    public Vector2 moveDirection = Vector2.right;

    [Header("Wrapping")]
    public int objSize = 1;
    [SerializeField] private Vector2 leftEdge;
    [SerializeField] private Vector2 rightEdge;

    private void Start()
    {
        Vector3 left3 = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));
        Vector3 right3 = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f));
        leftEdge = new Vector2(left3.x, left3.y);
        rightEdge = new Vector2(right3.x, right3.y);
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (moveDirection.x > 0f)
        {
            if (transform.position.x - objSize > rightEdge.x)
            {
                Vector3 p = transform.position;
                p.x = leftEdge.x - objSize;
                transform.position = p;
            }
        }

        else if (moveDirection.x < 0f)
        {
            if (transform.position.x + objSize < leftEdge.x)
            {
                Vector3 p = transform.position;
                p.x = rightEdge.x + objSize;
                transform.position = p;
            }
        }
    }
}
