using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXcontroller : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(!audioSource.isPlaying)
        {
            Destroy(this.gameObject);
        }

        /*
        List<int> list = new List<int>();
        list.Add(0);
        list.Add(1);    
        list.Add(2);    
        list.Add(3);    
        list.Add(4);    
        /*
        for(int i = 0; i < 10; i++)
        {

        }

        foreach (int i in list)
        {

        }
        */
    }
}
