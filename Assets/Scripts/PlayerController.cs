using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject cannonPrefab;
    [SerializeField] float fireAngle = 45f;
    
    void Start()
    {
        
    }

    void FireCannon()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 pos = transform.position + transform.forward * 0.5f + transform.up * 2.0f;
            GameObject g=Instantiate(cannonPrefab, pos, transform.rotation);
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            if (zombies.Length > 0 )
            {
                int index = UnityEngine.Random.Range(0, zombies.Length);
                transform.rotation = Quaternion.LookRotation(zombies[index].transform.position - transform.position);
                g.GetComponent<ShootController>().OnShoot(zombies[index].transform.position, fireAngle);
            }
        }
    }

    void Update()
    {
        FireCannon();
    }
}
