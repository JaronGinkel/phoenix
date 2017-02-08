using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBehavior : MonoBehaviour {


    public int dammage;

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        if(health != null)
        {
            health.TakeDammage(dammage);

        }
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDammage(dammage);

        }
        Destroy(gameObject);
    }

}
