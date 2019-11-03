using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float maxSpeed = 1.5f;
    public float speedMultiplier = 4;
    float speed = 0f;
    public GameObject bulletPrefab;
    Quaternion rotation = new Quaternion(0, 0, 0, 0);
    public float shootingCooldown = 0.75f;
    float timer = 0f;
    bool canShoot = true;
    public Transform bulletParent;
    public bool notOnGround = true;
    public bool jumping = false;
    public float maxJumpingSpeed = 1f;
    float jumpingSpeed = 0f;
    public float jumpMultiplier = 15;
    float fallingSpeed = 0;
    public float maxFallingSpeed = 1;
    public float fallingMultiplier = 3;
    float stoppingSpeed = 0;
    bool isMoving;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += Time.deltaTime * speedMultiplier;
            gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
            stoppingSpeed = 0.3f;
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && jumping)
        {
            stoppingSpeed = stoppingSpeed * 5;
        }
        else isMoving = false;
        if (!isMoving)
        {
            gameObject.transform.position += Vector3.right * Time.deltaTime * stoppingSpeed;
            stoppingSpeed -= Time.deltaTime;
            if (stoppingSpeed < 0.1f)
            {
                stoppingSpeed = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Instantiate(bulletPrefab, gameObject.transform.position, rotation, bulletParent);
            canShoot = false;
        }
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= shootingCooldown)
            {
                timer = 0f;
                canShoot = true;
            }
        }
        if (notOnGround && !jumping)
        {
            fallingSpeed += Time.deltaTime * fallingMultiplier;
            gameObject.transform.position += Vector3.down * Time.deltaTime * fallingSpeed;
            if (fallingSpeed >= maxFallingSpeed)
            {
                fallingSpeed = maxFallingSpeed;
            }
        }
        if (jumping)
        {
            fallingSpeed = 0;
            jumpingSpeed += Time.deltaTime * jumpMultiplier;
            notOnGround = true;
            gameObject.transform.position += Vector3.up * Time.deltaTime * jumpingSpeed;
            if (jumpingSpeed >= maxJumpingSpeed)
            {
                jumpingSpeed = maxJumpingSpeed;
            }      
        }
        if (!jumping)
        {
            jumpingSpeed = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        notOnGround = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        notOnGround = false;
        stoppingSpeed = stoppingSpeed / 5;
    }
}
