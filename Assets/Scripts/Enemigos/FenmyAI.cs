using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FenmyAI : MonoBehaviour
{
    public Transform target;
    public float speed =300f;
    public float updateRate = 2f;
    public float range = 12f;
    private Seeker seeker;
    private Rigidbody2D rb;
    public Path path;
    private int currentWaypoint = 0;
    public bool chase;
    public ForceMode2D fmode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
       
        seeker.StartPath(transform.position, target.position, OnPathComplete);
       
        StartCoroutine(UpdatePath());
    }
    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield return false;
          
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Path assigned. Any Errors?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    
    
    void FixedUpdate()
    {

        if (target == null)
        {
            
            return;
        }

        //TODO: Always look at player

        if (path == null)
            return;
        
        
            if (currentWaypoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                    return;

                Debug.Log("End of Path.");
                pathIsEnded = true;
                return;
            }
            pathIsEnded = false;

            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= speed * Time.fixedDeltaTime;

            rb.AddForce(dir, fmode);

            float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (dist < nextWaypointDistance)
            {
                currentWaypoint++;
                return;
            }

        

        


    }

    

}
