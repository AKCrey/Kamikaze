using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounterUI : MonoBehaviour
{
   
    public int maxKilledUnits;
    
    public int counter;

    private Image icon;

    private PlayerController playerController = null;

    public void CountUp()
    {
        counter = counter + 1;
    }

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        float fraction = (float)counter / maxKilledUnits;
        icon.fillAmount = fraction;
    }

    /*public void GetShield()
    {
        if (counter == maxKilledUnits)
        {
            PlayerController.BeforeActivateShield();
        }
    }*/
}
