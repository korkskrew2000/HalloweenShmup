using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isShooting;
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
    Vector3 origPoint;
    bool reached = false;
    float distance;
    public float movingSpeed = 1f;
    GameObject player;
    public LayerMask wallsMask;
    bool seeingPlayer;
    Vector3 toPlayer;
    public bool isPumpkin;

    private void Start()
    {
        origPoint = transform.position;
        movingSpeed = movingSpeed * Time.deltaTime;
        player = FindObjectOfType<PlayerMover>().gameObject;
    }
    //void SeeingPlayer()
    //{
    //    var direction = player.transform.position - transform.position;
    //    if (Physics.Raycast(transform.position, direction, Vector3.Distance(transform.position, player.transform.position), wallsMask))
    //    {
    //        seeingPlayer = false;
    //    }
    //    else seeingPlayer = true;
    //    Debug.DrawLine(transform.position, player.transform.position, Color.red);

    //}
    private void Update()
    {
        toPlayer = player.transform.position - transform.position;
        bulletPrefab.GetComponent<Bullet>().direction = toPlayer;
        //SeeingPlayer();
        if (isUsingGravity)
        {
            if (notOnGround && !jumping)
            {
                gameObject.transform.position += Vector3.down * Time.deltaTime * fallingSpeed;
            }
        }
        if (isShooting && canShoot)
        {
            Instantiate(bulletPrefab, transform.position, rotation, parent.transform);
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") && !isPumpkin)
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
