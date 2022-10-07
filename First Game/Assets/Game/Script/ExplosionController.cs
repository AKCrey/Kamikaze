using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{

    private Animator anim = null;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void CleanUp()
    {
        Destroy(this.gameObject);
        //Destroy �r egentligen inte obtimalt. Destroy commandot s�ger till Garbage collector att sl�nga. Problemet �r att The garbage collector tar tid att radera.
        //When you dont take care of your garbage collector performance will drop
        //16 milliseconds per frame before you have less than 60fps. 
    }

    void Update()
    {
        
    }
}
