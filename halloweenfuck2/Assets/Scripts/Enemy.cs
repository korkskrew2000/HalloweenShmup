using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isShootingLeft;
    public bool isUsingGravity;
    bool notOnGround = true;
    public bool jumping = false;
    public float fallingSpeed = 0.5f;
    public GameObject bulletPrefab;
    Quaternion rotation = new Quaternion(0, 0, 0, 0);
    public GameObject parent;
    float timer = 0f;
    public float shootingCooldown = 2f;
    bool canShoot = true;
    public bool isMoving;
    public GameObject toObject;
    public Vector3 origPoint;
    bool reached = false;
    float distance;
    public float movingSpeed = 1f;

    private void Start()
    {
        origPoint = transform.position;
        movingSpeed = movingSpeed * Time.deltaTime;
    }
    private void Update()
    {
        if (isUsingGravity)
        {
            if (notOnGround && !jumping)
            {
                gameObject.transform.position += Vector3.down * Time.deltaTime * fallingSpeed;
            }
        }
        if (isShootingLeft && canShoot)
        {
            Instantiate(bulletPrefab, gameObject.transform.position, rotation, parent.transform);
            canShoot = false;
        }
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= shootingCooldown)
            {
                timer = 0;
                canShoot = true;
            }
        }
        if (isMoving)
        {
            if (!reached)
            {
                distance = Vector3.Distance(transform.position, toObject.transform.position);
                if (distance > 0.1f)
                {
                    move(transform.position, toObject.transform.position);
                }
                else
                {
                    reached = true;
                }
            }
            else
            {
                distance = Vector3.Distance(transform.position, origPoint);
                if (distance > 0.1f)
                {
                    move(transform.position, origPoint);
                }
                else
                {
                    reached = false;
                }
            }
        }
    }
    void move(Vector3 pos, Vector3 towards)
    {
        transform.position = Vector3.MoveTowards(pos, towards, movingSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default")) { notOnGround = false; }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            FindObjectOfType<GameManager>().PlayerHit();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            notOnGround = true;
        }
    }
}
