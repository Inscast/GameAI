using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ShootController : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void OnShoot (Vector3 target, float angle)
    {
        body.velocity = BallisticVelocityByAngle(transform.position, target, angle);
    }

    Vector3 BallisticVelocityByAngle(Vector3 source, Vector3 destination,float angle)
    {
        Vector3 dir = destination - source; //목표방향
        dir.y = 0; //지평면
        float xz =dir.magnitude; //지평며상 거리
        float a = angle * Mathf.Deg2Rad; //라디안으로 변경
        dir.y = xz * Mathf.Tan(a); //높이
        //속도량 계산
        float velocity = Mathf.Sqrt(Mathf.Abs(xz) * Physics.gravity.magnitude / Mathf.Sin(2f * a));
        return velocity * dir.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 pos = transform.position + transform.up * 2f;
        GameObject g = Instantiate(particlePrefab, pos, transform.rotation);
        Destroy(g, 2f);
        Destroy(gameObject);
    }





}
