using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject bulletPrefab;

    public float bulletspeed;

    public Transform bulletspawn;

    public float bulletlifespan;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //calls the fire command
		if(Input.GetKeyDown(KeyCode.Space) ==true)
        {
            Shoot();
        }
	}

    //method for bullet spawn
    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right*bulletspeed;

        Destroy(bullet, bulletlifespan);
    }

    
}
