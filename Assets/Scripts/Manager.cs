using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject[] agentPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawning", 3f, 5f);   
    }

    void Spawning()
    {
        NavMeshHit hit;
        Vector3 pos = new Vector3(0f, 0f, UnityEngine.Random.Range(25f, 50f));
        NavMesh.SamplePosition(transform.position + pos,out hit, 20f, NavMesh.AllAreas);
        if (agentPrefab.Length > 0)
        {
            int index = UnityEngine.Random.Range(0, agentPrefab.Length);
            Instantiate(agentPrefab[index], hit.position, Quaternion.identity);
        }

    }

    void Update()
    {
        
    }
}
