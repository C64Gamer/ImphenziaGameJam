using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ship3_acastrop : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    private float charge_time = 2f;
    private float timer_calc;
    private int damage = 1;
    private GameObject player; 

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        timer_calc = charge_time;
        player = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = transform.forward * speed;
    }


    void FixedUpdate()
    {

        if (timer_calc <= 0)
        {
            calc_trayectory();  
        }
        else
        {
            timer_calc -= Time.deltaTime;
        }
    }

    private void calc_trayectory()
    {
        rb.velocity = (player.transform.position - this.gameObject.transform.position).normalized * speed;
        this.transform.LookAt(player.transform);
    }

    //deals damage to the player

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //deals damage to the player 

            Destroy(this.gameObject);
            
        }
    }
}
