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
    public bool canShoot = true;
    Vector3 shootingOffset = new Vector3(0.35f, 0, 0);
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
    public float minY = 0;
    public GameObject minYsensor;
    public ChargeShot chargeShot;
    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            speed = 0;
        }
        if (Input.GetKey(KeyCode.Z))
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
        if (Input.GetKeyUp(KeyCode.Z) && jumping)
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
            anim.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.X) && canShoot && !chargeShot.isCharged)
        {
            Instantiate(bulletPrefab, gameObject.transform.position + shootingOffset, rotation, bulletParent);
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
        if (minYsensor.transform.position.y < minY)
        {
            gameObject.transform.position += Vector3.up * Time.deltaTime * maxSpeed;
        }
        if (isMoving)
        {
            anim.enabled = true;
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
