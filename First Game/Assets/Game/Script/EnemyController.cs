using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("BulletData")]
    [SerializeField] private BulletMover bullet;
    public Transform leftBulletSpawnPoint;
    public Transform rightBulletSpawnPoint;
    public float fireRate = 1.0f;
    public bool isShootingContinous = true;

    //Movement Data
    public float speed = 1;

    private Rigidbody2D rb = null;
    private float fireRateTimer = 0.0f;

    private void Awake()//Give me the rigid body
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = Vector3.down * speed;
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (fireRateTimer > 0.0f) // 1 > 0? 
        {
            fireRateTimer -= Time.deltaTime; // 1 - 0.02
            return;
        }

        fireRateTimer = fireRate;

        var leftBulletInstance = Instantiate(bullet); //Create a copy of bullet
        leftBulletInstance.transform.position = leftBulletSpawnPoint.position;

        var rightBulletInstance = Instantiate(bullet); //Create a copy of bullet
        rightBulletInstance.transform.position = rightBulletSpawnPoint.position;

    }

}
