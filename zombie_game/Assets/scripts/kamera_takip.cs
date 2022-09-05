using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_takip : MonoBehaviour
{ 
    public Transform Hedef;
    public Transform kamera;
    public Vector3 a;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        a = kamera.position - Hedef.position;
    }

    private void LateUpdate()
    {
        transform.position = Hedef.transform.position + a;



    }
}