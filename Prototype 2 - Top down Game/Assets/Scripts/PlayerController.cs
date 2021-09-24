using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    public float turnSpeed = 15.0f;

    private float hInput;
    private float vInput;

    public float xRange = 10.5f;
    public float yRange = 4.5f;
    public GameObject projectile;
    public Transform firePoint;
    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput );
        transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
// moves and rotates player
// below is a set of borders that effect the player depending on the players coordinates
        if(transform.position.x > xRange) 
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }
        if(transform.position.x < -xRange) 
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.y > yRange) 
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);

        }
        if(transform.position.y < -yRange) 
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        // searches for a Space key press, as soon as it detects one it initiates the projetile with a position and rotation
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
