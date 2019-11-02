using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    float timer = 0f;
    bool hasHit = false;
    public float bulletTimer = 5f;
    public bool goingLeft = false;
    public bool shotByPlayer;
    void Update()
    {
        if (goingLeft)
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else
        gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
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
        Destroy(gameObject);
    }
}
