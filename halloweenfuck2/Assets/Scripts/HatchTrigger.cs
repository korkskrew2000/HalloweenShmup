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
    public AudioClip open;
    public AudioClip close;
    public float soundDistance = 15f;
    GameObject player;
    bool closePlayOnce;
    bool openPlayOnce;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMover>().gameObject;
        openPlayOnce = true;
    }
    void Opening()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < soundDistance && openPlayOnce)
        {
            openPlayOnce = false;
            AudioSource.PlayClipAtPoint(open, transform.position);
            closePlayOnce = true;
            return;
        }
    }

    void Closing()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < soundDistance && closePlayOnce)
        {
            closePlayOnce = false;
            AudioSource.PlayClipAtPoint(close, transform.position);
            openPlayOnce = true;
            return;
        }
    }
    private void Update()
    {
        if (tm.ticks == ticksToOpen)
        {
            Opening();
            isOpen = true;
            hatchAnimation.OpenAnimation();
        }
        if (tm.ticks == ticksToClose)
        {
            Closing();
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
