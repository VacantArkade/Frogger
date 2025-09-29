using UnityEngine;
using System;
using System.Collections;

public class LilyPadScript : MonoBehaviour
{
    public GameObject frogImage;
    public bool isOccupied;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frogImage.SetActive(false);
        isOccupied = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isOccupied)
            {
                isOccupied = true;
                frogImage.SetActive (true);
                GameManager.Instance.lilypadCounter--;
                GameManager.Instance.SpawnFrog();
                Destroy(other.gameObject);
            }
            else
            {
                FrogController controller = other.gameObject.GetComponent<FrogController>();
                controller.KillPlayer();
            }
        }
    }
}
