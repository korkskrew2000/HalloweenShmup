using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    float timer = 0f;
    public float jumpTimer = 0.5f;
    public GameObject player;
    bool activated = false;
    public float jumpSpeed;

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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !activated)
        {
            player.GetComponent<PlayerMover>().jumpingSpeed = jumpSpeed;
            player.GetComponent<PlayerMover>().jumping = true;
            activated = true;
        }
    }

}
