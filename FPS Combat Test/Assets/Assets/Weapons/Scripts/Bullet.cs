using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float damage;
    public float velocity;
    public bool playerBullet;

    private void Start()
    {
        rb.velocity = (transform.forward * velocity); 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Do hit code here

        if(other.GetComponent<Limb>()){
            other.GetComponent<Limb>().TakeDamage(damage);

            if(playerBullet){
                UIManager.instance.HitMarker();
            }
        }

        Destroy(gameObject);
    }
}
