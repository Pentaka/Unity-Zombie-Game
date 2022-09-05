using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class thirdpersonkamera : MonoBehaviour
{

    // Start is called before the first frame update

    public float Donushizi;
    public Transform target, Player;
    float mouseX, mouseY;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        KameraKontrol();
    }

    void KameraKontrol()
    {
        mouseX += Input.GetAxis("Mouse X") * Donushizi;
        mouseY += Input.GetAxis("Mouse Y") * Donushizi;

        mouseY = Mathf.Clamp(mouseY, -15, 30);

        transform.LookAt(target);

        if (Input.GetKey(KeyCode.RightShift))
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

    }
    
}
