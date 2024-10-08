using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent01Controller : MonoBehaviour
{
    [SerializeField] Transform playerT;
    NavMeshAgent agent;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = playerT.position;
        ani.SetFloat("Speed", agent.velocity.magnitude);
    }
    private void OnDrawGizmos()
    {
        if (agent == null)
            return;
        Gizmos.color = Color.red;
        for (int i = 1; i < agent.path.corners.Length; i++)
        {
            Gizmos.DrawSphere(agent.path.corners[i], 0.2f);
        }
    }


}
