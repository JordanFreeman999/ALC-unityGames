using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;

    [Header ("Movement")]
    public float moveSpeed, attackRange, yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
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
        transform.position = Vector3.MoveToward(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed + Time.deltaTime);
        if(transform.position == path[0] + new Vector3(0, yPathOffset,0))
            path.RemoveAt(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
