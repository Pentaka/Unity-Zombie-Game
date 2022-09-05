using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombispawn : MonoBehaviour
{
    public GameObject spawnzombi;
    public GameObject spawnyemek;
     int xPos;
     int zPos;
     int maxdusman;
     int maxyemek;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(zombi());
        StartCoroutine(yemek());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator zombi()
    {
        while (maxdusman < 500)
        {
            xPos = Random.Range(175, -135);
            zPos = Random.Range(175, -175);
            Instantiate(spawnzombi, new Vector3(xPos, -12.8f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            maxdusman += 1;
        }
    }
    IEnumerator yemek()
    {
        while (maxyemek < 200)
        {
            xPos = Random.Range(175, -135);
            zPos = Random.Range(175, -175);
            Instantiate(spawnyemek, new Vector3(xPos, -12.8f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(15f);
            maxyemek += 1;
        }
    }
}
