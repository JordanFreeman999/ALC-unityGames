using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && gameManager.hasKey)
        {
            print("Door unlocked");
            gameManager.isDoorLocked = false;
        }
        else
        {
            print("Door locked, go grab the key and come back");
        }
    }

}
