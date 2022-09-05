using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class dusman : MonoBehaviour
{
    
    Animator anim;

    NavMeshAgent agent;

    private Transform Target;

    public float mesafe;

    public float can;

    float maxcan = 100;
    float mincan = 0;

    public Slider canbari;

    Transform kan,zombi,kansicrama;
    public Transform kanefekt;

    

    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Target = GameObject.Find("Player").transform;
        zombi = GameObject.Find("kan").transform;
        


    }

    // Update is called once per frame
   public void Update()
    {
        anim.SetBool("walk", true);

        mesafe = Vector3.Distance(transform.position, Target.position);

        agent.destination = Target.transform.position;

        if (can == 0)
        {
            Destroy(agent);
            canbari.gameObject.SetActive(false);
            anim.SetBool("dead", true);
            Destroy(this.gameObject,3f);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            hareket.instance.sayi ++;
            

        }
        else 
        {
            
            if (mesafe <=1000 && mesafe >3)
            {

                anim.SetBool("attack", false);
                agent.enabled = true;
           
            }
             else if (mesafe < 3)
             {
            
            anim.SetBool("attack", true);
            agent.enabled = false;
             }



            
            
           
        }
        canbari.value = can;


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mermi")
        {
            StartCoroutine(kann());
            GetDamage(20);
        }
        if (other.gameObject.tag == "tuzak")
        {
            StartCoroutine(kann());
            Debug.Log("1");
            GetDamage(100);
        }

    }
     
    public void GetDamage(float amount)
    {
        can -= amount;
    }
    
    IEnumerator kann()
    {
        yield return new WaitForSeconds(0f);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);
        kan = Instantiate(kanefekt, pos, Quaternion.identity);
        
        

    }
}
