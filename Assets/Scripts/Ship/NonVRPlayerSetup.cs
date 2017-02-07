using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class NonVRPlayerSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {

        if (isLocalPlayer)
        {
            Camera.main.transform.position = this.transform.position - this.transform.right * 10 + this.transform.up * 3;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
        }
	}
	
}
