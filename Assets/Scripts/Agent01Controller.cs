using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Agent01Controller : MonoBehaviour
{
    [SerializeField] Transform playerT;
    NavMeshAgent agent;
    Animator ani;
    bool hasDone = false;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    void OffMeshLinkControll()
    {
        if (agent.isOnOffMeshLink)
        {
            OffMeshLinkData link = agent.currentOffMeshLinkData;
            if (!hasDone)
            {
                if (link.linkType == OffMeshLinkType.LinkTypeManual && link.offMeshLink.name == "OffMeshLink")
                {
                    ani.Play("Big Jump");
                    hasDone = true;
                }
                else if (link.linkType == OffMeshLinkType.LinkTypeJumpAcross)
                {
                    ani.Play("Jump Across");
                }
                else if (link.linkType == OffMeshLinkType.LinkTypeDropDown)
                {
                    ani.Play("Jumping Down");
                    hasDone = true;
                }
            }
        }
        else
        {
            hasDone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OffMeshLinkControll();

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
