using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Spawns : NetworkBehaviour {

    [SyncVar]
    public NetworkInstanceId playerNetID;
    private Transform myTransform;
    [SyncVar]
    public string playerUniqueID;
    public GameObject spawn;
    public GameObject spawn1;
    public GameObject spawn2;

    void Start () {
        GameObject spawner = (GameObject)Instantiate(spawn);
        if (playerUniqueID == "2")
        {
            this.transform.position = spawn1.transform.position;
        }
        else if(playerUniqueID == "3")
        {
            this.transform.position = spawn2.transform.position;
        }
	}

    public override void OnStartLocalPlayer()
    {
        playerNetID = GetComponent<NetworkIdentity>().netId;
        playerUniqueID = playerNetID.ToString();
    }
}
