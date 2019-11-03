using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim.enabled = false;
    }
    public void OpenAnimation()
    {
        anim.enabled = true;
        anim.Play("hatch");
    }
    public void CloseAnimation()
    {
        anim.enabled = true;
        anim.Play("hatchclose");
    }

}
