using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour

{
    public GameObject hat;
    // Start is called before the first frame update



    // Update is called once per frame
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

   
            
            hat.SetActive(true);
            Destroy(gameObject);
        }
    }
}
