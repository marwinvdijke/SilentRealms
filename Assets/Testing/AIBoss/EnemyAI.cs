using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target; //Set up Target 

    public float speed = 200f; //Set up speed and next waypoint distance
    public float nexWaypointDistance = 3f;
    public float jump = 1000f;

    public Transform enemyGFX; //Set up enemy
    public GameObject SlimeGFX;

    Path path; //Set up path, the current waypoint and reaching of the path end
    int currentWaypoint = 0;
    bool reachedEndPath = false;

    Animator animator;
    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>(); //Getting / loading seeker and rb
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f); //Repeating updating path

        
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete); //Starting path when creating is done
        }
        
    }

    void OnPathComplete(Path p)
    {
        if (!p.error) //only doing when there is no error
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) //return if there is no path
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count) //returning when ending of path is reached
        {
            reachedEndPath = true;
            return;
        }
        else
        {
            reachedEndPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; //Calculating direction and normalize it
        Vector2 force = direction * speed * Time.deltaTime; //Calculating force

        rb.AddForce(force); //Giving rb the force

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nexWaypointDistance) //Setting new waypoint
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f) //Rotating enemy
        {
            enemyGFX.localScale = new Vector3(0.3f, 0.3f, 1f); //Looking left
        }
        else if (force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(-0.3f, 0.3f, 1f); //Looking right
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            animator = SlimeGFX.GetComponent<Animator>();
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //animator.SetBool("Jump", false);

        }

    }
}
