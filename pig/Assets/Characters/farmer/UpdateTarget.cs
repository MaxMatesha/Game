using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class UpdateTarget : MonoBehaviour
{
    public Transform target;
    public GameObject pig;
    public NavigationEnemy NavigationEnemy;
    IAstarAI ai;
    // Start is called before the first frame update

    void OnEnable()
    {
        ai = GetComponent<IAstarAI>();

        if (ai != null) ai.onSearchPath += Update;
    }

    void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }
    void Start()
    {
        NavigationEnemy = gameObject.GetComponent<NavigationEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == pig.name)
        {
            ai.destination = target.position;
        }
    }
}
