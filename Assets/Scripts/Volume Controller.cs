using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Volume volume1;
    [SerializeField] Volume volume2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            volume1.weight = 1;
            volume2.weight = 0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            volume1.weight = 0;
            volume2.weight = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            volume1.weight = Mathf.Lerp(volume1.weight, 0f, Time.deltaTime);
            volume2.weight = Mathf.Lerp(volume2.weight, 1f, Time.deltaTime);
        }
    }
}
