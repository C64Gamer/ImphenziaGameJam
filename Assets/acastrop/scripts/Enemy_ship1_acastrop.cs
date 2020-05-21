using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ship1_acastrop : MonoBehaviour
{
    private Rigidbody rb;
    public Transform[] bullets_points; //points where the bullets can spawn every time the timer_calc goes to 0 
    public GameObject bullet;// the proyectiles 

    public float speed = 2f;
    private float reload_time = 3f;
    private float timer_calc;
 
    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        timer_calc = reload_time;
        rb.velocity = transform.forward.normalized * speed;
    }


    void FixedUpdate()
    {

        if (timer_calc <= 0)
        {
            foreach (Transform bullet_point in bullets_points)
            {
             Instantiate(bullet,bullet_point.position,bullet_point.rotation);
                
            }
            timer_calc = reload_time;
        }
        else
        {
            timer_calc -= Time.deltaTime;
        }
    }
}
