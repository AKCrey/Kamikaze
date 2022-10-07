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
        //Destroy är egentligen inte obtimalt. Destroy commandot säger till Garbage collector att slänga. Problemet är att The garbage collector tar tid att radera.
        //When you dont take care of your garbage collector performance will drop
        //16 milliseconds per frame before you have less than 60fps. 
    }

    void Update()
    {
        
    }
}
