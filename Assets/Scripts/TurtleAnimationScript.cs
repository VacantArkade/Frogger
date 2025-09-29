using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurtleAnimationScript : MonoBehaviour
{
    [SerializeField] TurtleControlScript turtleCTRL;
    [SerializeField] Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turtleCTRL = GetComponentInParent<TurtleControlScript>();
        anim = GetComponent<Animator>();
    }

    public void TurtleDive()
    {
        anim.SetTrigger("Dive");
    }

    public void TurtleRise()
    {
        anim.SetTrigger("Rise");
    }

    public void ColliderEnable()
    {
        turtleCTRL.killVolume.enabled = true;
    }

    public void ColliderDisable()
    {
        turtleCTRL.killVolume.enabled = false;
    }
}
