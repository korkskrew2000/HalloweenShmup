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
    Vector3 shootingOffset = new Vector3(0.45f, 0.045f, 0);
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
    bool wasMoving = false;
    float stoppingTime = 1.6f;
    bool playSFXonce = true;
    bool playLoopOnce = true;
    public AudioSource audioS;
    public AudioSource audioLoop;
    public AudioClip shootSFX;

    private void Awake()
    {
        oldCooldown = playerMover.shootingCooldown;
    }
    void Charging()
    {
        if (playSFXonce)
        {
                audioS.Play();
        }
        playSFXonce = false;
        return;
    }
    void ChargedShot()
    {
        playSFXonce = true;
        stoppingTime = 1.6f;
        chargeTimer = 0;
        isCharged = false;
        playerMover.canShoot = false;
        playerMover.shootingCooldown = newCooldown;
        isLaunching = true;
        return;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && playerMover.canShoot)
        {
            isCharging = true;

        }
        if (isCharging)
        {
            Charging();
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeTime)
            {
                isCharging = false;
                isCharged = true;
            }
        }
        if (isCharged)
        {
            if (playLoopOnce)
            {
                audioLoop.Play();
                playLoopOnce = false;
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                ChargedShot();
                Instantiate(chargeShotPrefab, gameObject.transform.position, rotation, bulletsParent);
                audioLoop.Stop();
                AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position);
                playLoopOnce = true;
            }
        }
        if (!isCharged && Input.GetKeyUp(KeyCode.X))
        {
            audioS.Stop();
            playSFXonce = true;
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
            wasMoving = true;
        }
        if (!isLaunching && wasMoving)
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime * stoppingTime;
            stoppingTime -= Time.deltaTime * 1.3f;
            if (stoppingTime < 0.1f)
            {
                stoppingTime = 0;
            }
        }
    }
}
