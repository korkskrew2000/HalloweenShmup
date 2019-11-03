using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : MonoBehaviour
{
    public PlayerMover playerMover;
    float chargeTimer = 0f;
    public float chargeTime = 1f;
    public float newCooldown = 2f;
    public bool isCharging = false;
    public bool isCharged = false;
    Vector3 shootingOffset = new Vector3(0.35f, 0, 0);
    public GameObject chargeShotPrefab;
    bool isLaunching = false;
    float launchTimer = 0;
    public float launchTimeLimit = 0.5f;
    public float launchSpeed = 2;
    float launchMoveSpeed = 0;
    public float launchMoveSpeedMax = 2;
    public float launchMultiplier = 2;
    float oldCooldown;
    public Transform bulletsParent;
    Quaternion rotation = new Quaternion(0, 0, 0, 0);

    private void Awake()
    {
        oldCooldown = playerMover.shootingCooldown;
    }
    void ChargedShot()
    {
        chargeTimer = 0;
        isCharged = false;
        playerMover.canShoot = false;
        playerMover.shootingCooldown = newCooldown;
        isLaunching = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && playerMover.canShoot)
        {
            isCharging = true;
        }
        if (isCharging)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeTime)
            {
                isCharging = false;
                isCharged = true;
            }
        }
        if (isCharged)
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                ChargedShot();
                Instantiate(chargeShotPrefab, gameObject.transform.position, rotation, bulletsParent);
                
            }
        }
        if (!isCharged && Input.GetKeyUp(KeyCode.X))
        {
            chargeTimer = 0;
            isCharging = false;
        }
        if (!isCharged)
        {
            if (playerMover.canShoot)
            {
                playerMover.shootingCooldown = oldCooldown;
            }
        }
        if (isLaunching)
        {
            playerMover.jumping = true;
            playerMover.maxJumpingSpeed = launchSpeed;
            launchTimer += Time.deltaTime;
            launchSpeed += Time.deltaTime * launchMultiplier;
            playerMover.gameObject.transform.position += Vector3.left * launchSpeed * Time.deltaTime;
            if (launchTimer >= launchTimeLimit)
            {
                playerMover.jumping = false;
                isLaunching = false;
                launchTimer = 0;
            }
        }
    }
}
