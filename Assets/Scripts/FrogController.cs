using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

public class FrogController : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] float moveTime = 0.15f;
    [SerializeField] bool canMove;
    [SerializeField] private bool isDead;
    [SerializeField] private bool onRiver;
    [SerializeField] private bool onPlatform;

    private Vector3 gameBorder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = true;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            PlayerUpdate();
        }
    }

    void PlayerUpdate()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerMove(Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                PlayerMove(Vector2.down);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                PlayerMove(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                PlayerMove(Vector2.right);
            }
        }
    }

    void PlayerMove(Vector2 _direction)
    {
        canMove = false;
        anim.SetTrigger("Hop");
        Vector2 _destination = transform.position + (Vector3)_direction;

        Collider2D platform = Physics2D.OverlapBox(_destination, Vector2.zero, 0, LayerMask.GetMask("Platform"));
        Collider2D barrier = Physics2D.OverlapBox(_destination, Vector2.zero, 0, LayerMask.GetMask("Barrier"));

        //if(barrier != null) return;

        if (platform != null)
        {
            transform.SetParent(platform.transform);
            onPlatform = true;
        }
        else
        {
            transform.SetParent(null);
            onPlatform = false;
        }

            StartCoroutine(LerpMove(_destination));
        //transform.position += (Vector3)_direction;
    }

    IEnumerator LerpMove(Vector2 _destination)
    {
        Vector2 startPos = transform.position;
        float elapsedTime = 0f;
        float duration = 0.1f;

        while (elapsedTime < duration)
        {
            float _time = elapsedTime / duration;
            transform.position = Vector2.Lerp(startPos, _destination, _time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = _destination;
        yield return new WaitForSeconds(moveTime);
        if (onRiver)
        {
            if (!onPlatform)
            {
                StartCoroutine(FrogDeath());
            }
        }
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
            StartCoroutine(FrogDeath());
        if (other.gameObject.tag == "River")
            onRiver = true;

        if (other.gameObject.tag == "Kill")
            StartCoroutine(FrogDeath());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "River")
            onRiver = false;
    }

    public void KillPlayer()
    {
        StartCoroutine(FrogDeath());
    }

    IEnumerator FrogDeath()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.lifeCounter--;
        GameManager.Instance.SpawnFrog();
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        gameBorder = transform.position;
        gameBorder.x = Mathf.Clamp(gameBorder.x, -4, 4);
        gameBorder.y = Mathf.Clamp(gameBorder.y, -6, 9);
        transform.position = gameBorder;
    }
}
