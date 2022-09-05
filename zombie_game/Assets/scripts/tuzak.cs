using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuzak : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
            
     StartCoroutine(tuzakk());
        
    }

    IEnumerator tuzakk()
    {
        anim.SetBool("acilma", true);
        yield return new WaitForSeconds(10f);
        anim.SetBool("kapanma", true);

    }
}
