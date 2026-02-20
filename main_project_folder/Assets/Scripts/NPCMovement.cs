using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<GameObject> waypoints;
    private Vector3 destination;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        waypoints = GameObject.FindGameObjectsWithTag("waypoint").ToList();
        if (waypoints.Count > 0)
            agent.destination = waypoints[0].transform.position;

        agent.destination = destination = waypoints[currentWaypointIndex].transform.position;
    }


    void Update()
    {
        if (waypoints.Count == 0) return;

        if (Vector3.Distance(transform.position, destination) < 1f)
        {
             currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            destination = waypoints[currentWaypointIndex].transform.position;
            agent.destination = destination;
        }

    }

    void Patrol()
    {

        if (waypoints.Count == 0) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                agent.destination = waypoints[currentWaypointIndex].transform.position;
            }
        }
    }
}
