using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int startingHealthpoints = 3;
    public string lethalBulletTag = "ENTER LETHAL BULLET TAG HERE";
    public AudioSource deathSoundPrefab;
    public ExplosionController explosionPrefab;
    public bool isPlayerHealthController = false;
    public UnityEvent onDeathEvent;//UnityEvent is a list of methods inside of Unity! Reverse method sort off

    private int currentHealthPoints = 0;

    private KillCounterUI killCounterUI = null;

    //GameObject shield;

    //KillCounterUI killCounter = new KillCounterUI();
    

    public int GetCurrentHealth()
    {
        return currentHealthPoints;
    }


    private void Start()
    {
        /*shield = transform.Find("Shield").gameObject;
        DeactivateShield();*/

        currentHealthPoints = startingHealthpoints;

        killCounterUI = FindObjectOfType<KillCounterUI>();//Looking for everything, same as GetRootGameObjects with a foreach loop
    }

    public void RecieveDamage(int reduceHealthBy)
    {
        if (currentHealthPoints > 0)
        {
            currentHealthPoints -= reduceHealthBy;
        }
        if (currentHealthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //We die here

        onDeathEvent.Invoke();//Call every function that is in the list

        if (!isPlayerHealthController /* == false */)
        {
            killCounterUI.CountUp();
        }

        /*int counter = KillCounterUI.counter;
        int maxKilledUnits = KillCounterUI.maxKilledUnits;
        
        if (isPlayerHealthController == true)
        {
            if (counter == maxKilledUnits)
            {
                ActivateShield();
            }
        }*/

        Destroy(this.gameObject);


        var explosionInstance = Instantiate(explosionPrefab);
        explosionInstance.transform.position = transform.position;

        var deathSoundInstance = Instantiate(deathSoundPrefab);
        deathSoundInstance.transform.position = transform.position;
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
    }*/

    private void OnTriggerEnter2D(Collider2D other) //other == what we collide with
    {
        const int DAMAGE_POINTS = 1;

        if(other.CompareTag(lethalBulletTag))
        {

            RecieveDamage(DAMAGE_POINTS);
            
        }

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.GetComponent<BulletMover>() != null) //
        {

        }

        if(collision.gameObject.CompareTag(playerBulletTag))
        {
            Debug.Log("Enemy got hit");
        }
    }*/
}
