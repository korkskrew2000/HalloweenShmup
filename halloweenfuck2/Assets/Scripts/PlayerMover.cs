using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bulletPrefab;
    Quaternion rotation = new Quaternion(0, 0, 0, 0);
    public float shootingCooldown = 0.75f;
    float timer = 0f;
    bool canShoot = true;
    public Transform bulletParent;
    bool notOnGround = true;
    public bool jumping = false;
    public float jumpingSpeed = 1f;
    public float fallingSpeed = 0.5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
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
            gameObject.transform.position += Vector3.down * Time.deltaTime * fallingSpeed;
        }
        if (jumping)
        {
            notOnGround = true;
            gameObject.transform.position += Vector3.up * Time.deltaTime * jumpingSpeed;
            print("Jumping!");
        } if (!jumping) { print("ceased to jump"); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        notOnGround = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        notOnGround = false;
    }
}
