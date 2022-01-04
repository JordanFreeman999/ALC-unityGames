using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;

    public Transform muzzle;

    public int curAmmo;
    
    public int maxAmmo;

    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;

    public AudioClip shootSfx;
    private AudioSource audioSource;
    
    void Awake()
    {
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
            audioSource = GetComponent<AudioSource>();
        }

    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
            return true;
            }
        }

        return false;
    }
    // Start is called before the first frame update

 public void Shoot()
    {
        audioSource. PlayOneShot(shootSfx);
        lastShootTime = Time.time;
        curAmmo --;

        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        if(isPlayer)
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);
    }
    
}
