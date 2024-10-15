using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            for (int i = 0; i < cam.Length; i++)
            {
                if (i == 0) cam[i].Priority = 10;
                else cam[i].Priority = 0;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            for (int i = 0; i < cam.Length; i++)
            {
                if (i == 1) cam[i].Priority = 10;
                else cam[i].Priority = 0;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            for (int i = 0; i < cam.Length; i++)
            {
                if (i == 1) cam[i].Priority = 10;
                else cam[i].Priority = 0;
            }


        }
    }
}
