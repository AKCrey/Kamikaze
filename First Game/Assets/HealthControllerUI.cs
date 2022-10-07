using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//To be able to use Text, since it's under UI

public class HealthControllerUI : MonoBehaviour
{
    public HealthController healthController;

    private Text healthUIText;


    void Awake()
    {
        healthUIText = GetComponent<Text>();
    }

    void Update()
    {
        //healthUIText.text = healthController.GetCurrentHealth().ToString(); //Converting string to int
        healthUIText.text = $"x{healthController.GetCurrentHealth()}"; //A new way I learned to add text...with the dollar symbol?"
    }
}
