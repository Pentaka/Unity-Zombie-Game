using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{

    public Transform mermii, nokta, silah;
    Transform klon,klonefekt;
    float guntimer;
    public float guncooldown;
    public Transform atesefekt;

    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
   
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            

            if(Time.time > guntimer)
            {
                guntimer = Time.time + guncooldown;
                klon = Instantiate(mermii, nokta.position, silah.rotation);
                klon.GetComponent<Rigidbody>().AddForce(klon.forward * 8000f);
                klonefekt = Instantiate(atesefekt, nokta.position , Quaternion.identity);
                klonefekt.transform.parent = nokta.transform;              
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       
        
    }

}
