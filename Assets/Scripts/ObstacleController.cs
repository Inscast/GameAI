using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField]
    private float moveRange = 5f;

    [SerializeField]
    private float moveMaxDelay = 1f, moveCurdelay = 1f;

    [SerializeField]
    private float speed = 4f;

    private float movingDistance = 0f;

    bool isMove = true;


    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            movingDistance += speed * Time.deltaTime;

                if (Mathf.Abs(movingDistance) > moveRange)
                {
                    isMove = false;
                    transform.Rotate(new Vector3(0, 180, 0));
                }
        }

        else
        {
            moveCurdelay -= Time.deltaTime;
            if (moveCurdelay <= 0)
            {

                movingDistance = 0;
                moveCurdelay = moveMaxDelay;
                isMove = true;  
            }


        }


    }
}
