using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activeDistance = 50f;
    public float pathUptdateSeconds = 0.5f;

    [Header("Phypics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;


    [Header("Behavior")]
    public bool followEnabled = true;
    public bool directionLookEnabled = true;


    private Path path;
    private int currentWaypoint = 0;
    private Seeker seeker;
    private Rigidbody2D rb;
    public bool chase;

    private void Start()
    {
        
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUptdateSeconds);
        //Atribui à variável rb o valor de Rigidbody2D e a seeker o valor de Seeker e também chama a função UpdatePath constantemente
    }


    private void UpdatePath()
    {
        if(followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        // Se o caminho estiver feito começa a seguilo
    }
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
        //Se não houver erros cria o caminho p
    }

    private void FixedUpdate()
    {

        if(TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
        //Chama a função PathFollow

    }

    private void PathFollow()
    {
        if (path == null)
            return;


        if (currentWaypoint >= path.vectorPath.Count)
        {

            return;
        }
        //Evita o caminho mais longo


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        //Adiciona a força que faz o inimigo andar 

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        //Faz o inimigo andar até o proximo Waypoint

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        //Cria o proxima parte do caminho 
        if (directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(2f, 2f, 2f);
            }
            else if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(-2f, 2f, 2f);
            }
            //Vira a posição do inimigo dependendo de como ele anda
        }
    }
    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.position) < activeDistance;
    }
    //Cria a posição final do caminho
}
