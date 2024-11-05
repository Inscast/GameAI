using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Agent01Controller : MonoBehaviour
{
    [SerializeField] Transform playerT;
    [SerializeField] LayerMask layer;
    NavMeshAgent agent;
    Animator ani;
    bool hasDone = false;
    RaycastHit hit;


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
      //  transform.Rotate(0f, 120f * Time.deltaTime, 0f);
        ani.SetFloat("Speed", agent.velocity.magnitude);
        // GotIt();
    }

    public void GotIt_2()
    {
        agent.destination = playerT.position;
    }
  //  void GotIt()
   // {
   //     float distance = 10f;
  //      Vector3 start = transform.position + new Vector3(0, 1f, 0);
  //      if (Physics.Raycast(start, transform.forward, out hit, distance, layer))
  //      {
  //          Debug.DrawRay(start, transform.forward * hit.distance, Color.yellow, 2f);
            // playerT.gameObject.GetComponent<Animator>().SetBool("Jump", true);
   //     }
   //     else
     //   {
    //        Debug.DrawRay(start, transform.forward * distance, Color.red);
    //    }
   // }
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
