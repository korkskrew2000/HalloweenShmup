using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    float timer = 0f;
    public float bulletTimer = 5f;
    public bool goingLeft = false;
    public bool shotByPlayer;
    public Vector3 direction;
    public bool isCharged = false;
    void Update()
    {
        gameObject.transform.position += direction * Time.deltaTime * speed;
        timer += Time.deltaTime;
        if (timer >= bulletTimer)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !shotByPlayer)
        {
            FindObjectOfType<GameManager>().PlayerHit();
        }
        if (isCharged)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                Destroy(gameObject);
            }
        }
    }
}
