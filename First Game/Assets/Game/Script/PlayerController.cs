using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Balancing")]
    public float speed = 13.0f;

    [Header("Controls")]
    public bool canMoveVertical = false;
    public bool canMoveHorizontal = false;
    public Key shootKey = Key.Space;
    public Key changeGunKey = Key.Tab;

    [Header("BulletData")]
    [SerializeField] private BulletMover bullet;
    public Transform bulletSpawnPoint;
    public float fireRate = 1.0f;
    public bool isShootingContinous = true;

    private Rigidbody2D rb = null;
    private float fireRateTimer = 0.0f;

    public string EnemyTag = "Enemy";


    private HealthController health = null;

    Gun[] guns; //Array of guns

    int powerUpGunLevel = 0;

    //GameObject shield;

    /*
    public Key moveUpKey = Key.W;
    public Key moveDownKey = Key.S;*/
    //...


    private void Awake()//Give me the rigid body
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthController>();
    }

    void Start()
    {
        /*shield = transform.Find("Shield").gameObject;
        DeactivateShield();*/

        guns = transform.GetComponentsInChildren<Gun>();//Looks for all the guns in the ship

        foreach(Gun gun in guns)
        {
            gun.isActive = true;
            if (gun.powerUpLevelRequireMent != 0)
            {
                gun.gameObject.SetActive(false);
            }
        }
    }
    
    private void Velocity(Vector2 direciton)
    {
        //Deltatime moves ONE unit per SECOND. (Time needed to execute one frame)
        //rb.position += direciton * Time.deltaTime * speed;
        //rb.MovePosition(rb.position + direciton * Time.deltaTime * speed);

        rb.velocity = direciton * speed;
    }

    private void Move()
    {
        speed = 13;

        //Storing keys from the keyboard
        var leftKey = Keyboard.current.aKey; // [Key.A]
        var rightKey = Keyboard.current.dKey;
        var upKey = Keyboard.current.wKey;
        var downKey = Keyboard.current.sKey;

        Vector2 inputDirection = Vector2.zero;

        if (canMoveHorizontal == true)
        {
            if (leftKey.isPressed)
            {
                inputDirection += Vector2.left;
            }
            if (rightKey.isPressed)
            {
                inputDirection += Vector2.right;
            }
        }
        if (canMoveVertical == true)
        {
            if (/*canMoveVertical && */upKey.isPressed)
            {
                speed -= 2;//Picking up speed is more difficult
                inputDirection += Vector2.up;
            }
            if (downKey.isPressed)
            {
                speed += 2;//Slowing down is easier
                inputDirection += Vector2.down;
            }
        }

        inputDirection.Normalize();
        Velocity(inputDirection);

        /*
        if (leftKey.isPressed && rightKey.isPressed)
        {
            speed = 0.0f;
        }

        if (leftKey.isPressed) 
        {*/
        //Debug.Log("Move left");
        //transform.position += Vector3.left;

        /*Move(Vector2.left);
        speed = 10.0f;*/
        /*
        inputDirection += Vector2.left;
        }   
        //Check if right key is pressed
        else if(rightKey.isPressed)
        {
            //Debug.Log("Move right");
            //transform.position += Vector3.left;

            /*if (leftKey.isPressed)
        {
            speed = 0.0f;
        }
        else
        {
            Move(Vector2.right);
            speed = 10.0f;
        }*/
        /*
        Move(Vector2.right);
        speed = 10.0f;
        }
        /*else if(upKey.isPressed && rightKey.isPressed)
        {
            Move(Vector2.up * Vector2.right);
        }*/
        /*else if(canMoveVertical && upKey.isPressed)
        {
            Move(Vector2.up);
            speed = 5.0f;
        }
        else if(canMoveVertical && downKey.isPressed)
        {
            Move(Vector2.down);
            speed = 5.0f;
        }
        else
        {
            Move(Vector2.zero);
        }
        


        /*if (Input.GetKey(KeyCode.D)) Old Input System
        {
            Debug.Log("New Input System");
        }*/
    }

    private void Shoot()
    {
        if(fireRateTimer > 0.0f) // 1 > 0? 
        {
            fireRateTimer -= Time.deltaTime; // 1 - 0.02
            return;
        }

        var key = Keyboard.current[this.shootKey];
        bool isPressed = false;
        if (isShootingContinous == true)
        {
            isPressed = key.isPressed;
        }
        else
        {
            isPressed = key.wasPressedThisFrame;
        }
        if(key.isPressed)//wasPressedThisFrame to shoot once per press
        {
            fireRateTimer = fireRate;

            foreach(Gun gun in guns)
            {
                if (gun.gameObject.activeSelf)
                {
                    gun.Shoot();
                }
            }
            //var bulletInstance = Instantiate(bullet); //Create a copy of bullet
            //bulletInstance.transform.position = bulletSpawnPoint.position;

            //bullet.gameObject.SetActive(true);
            //this.tranform == playerr position
            //bulletSpawnPoint.position == this.tranformn.position 
            //bullet.transform.parent = null;
        }
    }

    private void Update()
    {
        Move();

        Shoot();

    }

    void AddGuns()
    {
        powerUpGunLevel++;
        foreach(Gun gun in guns)
        {
            if(gun.powerUpLevelRequireMent == powerUpGunLevel)
            {
                gun.gameObject.SetActive(true);
            }
        }
    }

    /*
    private void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        return shield.activeSelf;
    }

    public void BeforeActivateShield()
    {
        ActivateShield();
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUp powerUp = collision.GetComponent<PowerUp>();
        if (powerUp)
        {
            if (powerUp.addGuns)
            {
                AddGuns();
            }
            Destroy(powerUp.gameObject);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(EnemyTag))
        {
            /*if (HasShield())
            {
                DeactivateShield();
            }
            else
            {
                Destroy(gameObject);*/
            health.RecieveDamage(health.GetCurrentHealth());
                //Goodbye player
            //}
        }

    

    }


}
