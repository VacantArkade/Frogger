using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurtleControlScript : MonoBehaviour
{
    public TurtleAnimationScript[] turtles;
    public Collider2D killVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        killVolume.enabled = false;
        StartCoroutine(TurtleDiveSeq());
    }

    IEnumerator TurtleDiveSeq()
    {
        float timer = Random.Range(5f, 8f);

        yield return new WaitForSeconds(timer);
        foreach(TurtleAnimationScript turtle in turtles)
        {
            turtle.TurtleDive();
        }
        yield return new WaitForSeconds(2.75f);

        foreach (TurtleAnimationScript turtle in turtles)
        {
            turtle.TurtleRise();
        }
        yield return new WaitForSeconds(2.75f);

        StartCoroutine(TurtleDiveSeq());
    }
}
