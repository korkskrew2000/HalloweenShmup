using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius;
    GameManager gm;
    public AudioClip explosion;
    public CircleCollider2D trigger;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        trigger.radius = explosionRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet") || collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                gm.PlayerHit();
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        trigger.enabled = true;
        AudioSource.PlayClipAtPoint(explosion, Camera.main.transform.position);
        Destroy(gameObject, 0.1f);
    }
}
