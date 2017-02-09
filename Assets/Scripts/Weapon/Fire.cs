using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fire : NetworkBehaviour {

    public GameObject bulletPrefab;

    public float bulletspeed;

    public GameObject fighter;

    public Transform bulletspawn;

    public float bulletlifespan;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //calls the fire command
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                CmdShoot();
            }
        }
	}

    //method for bullet spawn
    [Command]
    void CmdShoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * bulletspeed + fighter.GetComponent<Rigidbody>().velocity;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, bulletlifespan);
    }

    
}
