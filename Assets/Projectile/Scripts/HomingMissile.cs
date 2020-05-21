using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [Header("Config")]
    public Transform RocketTarget;
    public Rigidbody rb;

    public float turnSpeed = 1f;
    public float rocketSpeed = 10f;

    private Transform rocketLocalT;
    private float randomPos;

    // Start is called before the first frame update
    void Start()
    {
        if (!RocketTarget)
            Debug.Log("no target");

        rocketLocalT = GetComponent<Transform>();
        turnSpeed = Random.Range(1f, 5f);
        rocketSpeed = Random.Range(10f, 40f);
        randomPos = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rb)
            return;

        rb.velocity = rocketLocalT.forward * rocketSpeed;
        var rocketTargetRot = Quaternion.LookRotation((RocketTarget.position + (new Vector3(1,0,0) * randomPos) ) - rocketLocalT.position);
        rb.MoveRotation(Quaternion.RotateTowards(rocketLocalT.rotation, rocketTargetRot, turnSpeed));
    }
}
