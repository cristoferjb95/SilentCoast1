using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // States for the enemy behavior
    public enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }

    public State currentState;

    // Variables for pathfinding
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2.0f;
    public float chaseRange = 5.0f;

    private Transform player;

    void Start()
    {
        currentState = State.Patrol;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                // Idle behavior
                break;
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Attack:
                Attack();
                break;
        }
        CheckForPlayer();
    }

    void Patrol()
    {
        // Move towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the enemy has reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void Chase()
    {
        // Move towards the player
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        // Implement attack behavior
    }

    void CheckForPlayer()
    {
        // If the player is within chase range, change state to Chase
        if (Vector3.Distance(transform.position, player.position) < chaseRange)
        {
            currentState = State.Chase;
        }
        else
        {
            currentState = State.Patrol;
        }
    }
}