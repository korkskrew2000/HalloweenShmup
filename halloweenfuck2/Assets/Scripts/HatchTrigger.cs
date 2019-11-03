using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchTrigger : MonoBehaviour
{
    public bool isOpen = false;
    public int ticksToOpen;
    public int ticksToClose;
    public Tickmaster tm;
    public Hatch hatchAnimation;
    public BoxCollider2D collider;
    public BoxCollider2D trigger;
    public bool instaKill = false;
    private void Update()
    {
        if (tm.ticks == ticksToOpen)
        {
            isOpen = true;
            hatchAnimation.OpenAnimation();
        }
        if (tm.ticks == ticksToClose)
        {
            isOpen = false;
            hatchAnimation.CloseAnimation();
        }
        if (isOpen)
        {
            collider.enabled = false;
        }
        else collider.enabled = true;
        if (!instaKill)
        {
            trigger.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen && instaKill)
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().PlayerHit();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOpen && instaKill)
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().PlayerHit();
        }
    }
}
