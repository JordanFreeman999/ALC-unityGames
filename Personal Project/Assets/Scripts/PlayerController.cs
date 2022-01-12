using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHP;
    //Movement

    //components

    private Weapon weapon;
    // Start is called before the first frame update
    void Awake()
    {
    

        weapon = GetComponent<Weapon>();
        
    }
    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButton("e"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }

    }
   
    public void TakeDamage(int damage)
    {
        // These 2 mean the same thing.
        curHP -= damage; // Shorthand Notation
        curHP = curHP - damage; // Longhand Notation

        if(curHP <= 0)
            Die();
    }
    void Die()
    {
        print("Get good kid, dogwater, free, no earnings");
    }
    public void GiveHealth( int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
    }
    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);

    }
}
