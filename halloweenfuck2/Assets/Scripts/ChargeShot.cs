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
    public GameObject chargeShotPrefab;
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
        playerMover.canShoot = false;
        playerMover.shootingCooldown = newCooldown;
        if (playerMover.canShoot)
        {
            playerMover.shootingCooldown = oldCooldown;
        }
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
    }
}
