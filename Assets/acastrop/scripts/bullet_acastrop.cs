using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_acastrop : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private Rigidbody rb;

    public void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward.normalized * speed;
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // deals damage to the player 
            Destroy(this.gameObject);
        }
    }


}
