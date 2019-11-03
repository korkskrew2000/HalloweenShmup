using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    float timer = 0f;
    float timer2 = 0f;
    public float jumpTimer = 0.5f;
    public GameObject player;
    bool activated = false;
    public float jumpSpeed;
    public float jumpCooldown = 3f;
    bool onCooldown = false;

    private void Update()
    {
        if (activated)
        {
            timer += Time.deltaTime;
            if (timer >= jumpTimer)
            {
                timer = 0f;
                player.GetComponent<PlayerMover>().jumping = false;
                activated = false;
            }
        }
        if (onCooldown)
            { 
        timer2 += Time.deltaTime;
            if (timer2 > jumpCooldown)
            {
                timer2 = 0;
                onCooldown = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !activated && !onCooldown)
        {
            player.GetComponent<PlayerMover>().maxJumpingSpeed = jumpSpeed;
            player.GetComponent<PlayerMover>().jumping = true;
            activated = true;
            onCooldown = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !activated && !onCooldown)
        {
            player.GetComponent<PlayerMover>().maxJumpingSpeed = jumpSpeed;
            player.GetComponent<PlayerMover>().jumping = true;
            activated = true;
            onCooldown = true;
        }
    }
}
