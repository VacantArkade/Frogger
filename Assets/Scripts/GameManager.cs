using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab;
    public Transform startPoint;

    public int lifeCounter = 3;
    public int lilypadCounter = 5;
    public TMP_Text lifeText;
    public TMP_Text lilypadText;

    //Manage screens
    public GameObject winScreen;
    public GameObject loseScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            startPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
        }

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    private void Update()
    {
        lifeText.text = lifeCounter.ToString();
        lilypadText.text = lilypadCounter.ToString();
    }

    public void SpawnFrog()
    {
        if(lifeCounter > 0 && lilypadCounter > 0) 
            Instantiate(playerPrefab, startPoint.position, startPoint.rotation);
        else
        {
            if(lifeCounter <= 0) loseScreen.SetActive(true);
            else if(lilypadCounter <= 0) winScreen.SetActive(true);
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(0);
    }
}
