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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen)
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().PlayerHit();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOpen)
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().PlayerHit();
        }
    }
}
