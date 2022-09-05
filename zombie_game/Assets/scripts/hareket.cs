using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class hareket : MonoBehaviour
{
    public static hareket instance;

    public float hiz = 20.0f;

    Animator anim;

    public float can, yemekk;
 
    public Slider canbari;
    public GameObject Canvas;

    float toplananyemek = 0;
    public TextMeshProUGUI yemekpuani;
    bool topla;

    AudioSource audioSource;
    public AudioClip toplama;
    public AudioClip olmesesi;
    public AudioClip hasarsesi;
    public AudioClip yemeksesi;

    public Slider yemekbari;
    float zaman, zaman1;
    public float cooldown, cooldown1;

    public TextMeshProUGUI dusmanpuan;
    public float sayi=0;
    
     bool pause, pause2,pause3;
    public GameObject panel,panel1,panel2,panel3;
    
    
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
     

         
    }
    private void LateUpdate()
    {
        
    }
    void Update()
    {

        yemekyeme();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * hiz);
            anim.SetBool("walk", true);
            
        }
        else
        {
            anim.SetBool("walk", false);

        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * hiz);
            anim.SetBool("walkback", true);

        }
        else
            anim.SetBool("walkback", false);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pause == true)
            {
                pause = false;
                panel.SetActive(false);
            }
            else
            {
                pause = true;
                panel.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
            panel1.SetActive(true);
            
            
        }
        if(panel1 == true)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                pause = false;
                SceneManager.LoadScene("Giris");
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                pause = false;
                panel1.SetActive(false);
            }
        }
            if (pause == true)
        {
            Time.timeScale = 0f;
            
            AudioListener.volume = 0;
        }
        else if (pause == false)
        {
            Time.timeScale = 1f;
            
            AudioListener.volume = 1;
        }



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            hiz = 45.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            hiz = 30.0f;
        }
        if (pause2==true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Giris");
                
            }
        }
        if (pause3 == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Giris");
                
            }
        }
        if(pause2 == true)
        {
            panel2.SetActive(true);
        }
        if (pause3 == true)
        {
            panel3.SetActive(true);
        }

        canbari.value = can;
        yemekbari.value = yemekk;

        if (Time.time > zaman)
        {
            if (yemekk > 0)
            {
                zaman = Time.time + cooldown;
                YemekAzalma(10);
            }
            else
            {
                zaman = Time.time + cooldown;
                GetDamage(20);
                if(can==0)
                {
                    audioSource.PlayOneShot(olmesesi, 0.7F);

                }
            }
           

        }
      
       
        if (can <= 0)
        {
            
            anim.SetBool("dead", true);
            StartCoroutine(oldun());
            hiz = 0f;
            StartCoroutine(dead());
            
            
            


        }
       

        if (topla == true)
        {
            audioSource.PlayOneShot(toplama, 0.7F);
            toplananyemek = toplananyemek + 1f;
            yemekpuani.text = "X" + toplananyemek;
            topla = false;
        }
        if (yemekk > 100)
        {
            yemekk = 100;
        }
        if (yemekk < 0)
        {
            yemekk = 0;
        }
        if (can > 100)
        {
            can = 100;
        }
        if (can < 0)
        {
            can = 0;
        }
       if(toplananyemek==50)
        {
            Time.timeScale = 0f;
            AudioListener.volume = 0;
            panel3.SetActive(true);
        }


        dusmanpuan.text = "X" + sayi;

      
    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "zombi")

        {
            GetDamage(20);
            
            if (can > 0)
            {
                audioSource.PlayOneShot(hasarsesi, 0.7F);
            }
            else if (can ==0)
            {
                audioSource.PlayOneShot(olmesesi, 0.7F);
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tuzak")
        {
            GetDamage(100);
            audioSource.PlayOneShot(olmesesi, 0.7F);
        }
        if (other.gameObject.tag == "yemek" && topla == false)
        {
            topla = true;

        }
    }
    public void GetDamage(float amount)
    {
        can -= amount;
    }
    public void GetHeal(float amount)
    {
        can += amount;
    }
    public void YemekAzalma(float deger)
    {
        yemekk -= deger;
    }
    public void YemekArtma(float deger)
    {
        yemekk += deger;
    }

    IEnumerator dead()
    {
        yield return new WaitForSeconds(4f);       
        Time.timeScale = 0f;
        panel2.SetActive(true);
    }
   

    IEnumerator oldun()
    {
        yield return new WaitForSeconds(2f);
        
        Canvas.SetActive(true);

    }
    void yemekyeme()
    {

        if (Input.GetKey(KeyCode.E))
        {
            
            if (Time.time > zaman1)
            {
                if (toplananyemek > 0)
                {
                    zaman1 = Time.time + cooldown1;
                    YemekArtma(50);
                    GetHeal(20);
                    toplananyemek = toplananyemek - 1f;
                    yemekpuani.text = "X" + toplananyemek;
                    audioSource.PlayOneShot(yemeksesi, 0.7F);
                }
            }
        }


    }
}
