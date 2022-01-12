using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PickupType
   {
       Health,

       Ammo,

       Blizzard
   }

public class Pickup : MonoBehaviour
{
   public PickupType type;
    public int value;

    [Header ("Bobbing Animation")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private Vector3 startPos;
    private bool bobbingUp;
    public AudioClip pickupSfx;
    public GameObject hat;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }



    // Update is called once per frame
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

   
            
            hat.SetActive(true);
            Destroy(gameObject);
        }
    }
    void Update()
    {

    }
}
