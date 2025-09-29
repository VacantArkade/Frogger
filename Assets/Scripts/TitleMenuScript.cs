using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuScript : MonoBehaviour
{
    public string loadThisScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(loadThisScene);
    }
}
