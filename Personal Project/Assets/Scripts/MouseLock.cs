using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.RightShift)) 
       {
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;

       }
        if(Input.GetKeyDown("1")){
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;
       }
    }
}
