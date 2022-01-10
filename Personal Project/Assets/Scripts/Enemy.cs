using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;

    public int maxHP;
    public int scoreToGive;

    [Header ("Movement")]
    public float moveSpeed, attackRange, yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }
    void UpdatePath()
    {
        //Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();

        //points to follow
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();

    }

    void ChaseTarget()
    {
        if(path.Count == 0)
        return;
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);
        if(transform.position == path[0] + new Vector3(0, yPathOffset,0))
            path.RemoveAt(0);
    } 
    void Update()
    {
        Vector3 dir =(target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;

        float dist = Vector3.Distance(transform.position, target.transform.position);

        if (dist <= attackRange)
        {
            if(weapon.CanShoot())
            weapon.Shoot();
        }
        else {
            ChaseTarget();
        }
    }
  public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Die();
    }
    void Die()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.back * 10, ForceMode.Impulse);
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }
    // Update is called once per frame
   
}
