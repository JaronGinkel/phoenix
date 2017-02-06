using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class nonVRFighterController : NetworkBehaviour {


    [SerializeField]
    GameObject ship;

    [SerializeField]
    float moverate;

    [SerializeField]
    float yawrate;

    [SerializeField]
    float rollrate;

    [SerializeField]
    float pitchrate;

    //wierd bug where when values are negative it rotates really fast, not sure why, but this was my fix
    [SerializeField]
    float negativerollrate;

    [SerializeField]
    float negativepitchrate;
   
	// Update is called once per frame
	void Update () {

        if(!isLocalPlayer)
        {
            return;
        }
        //this if statment handles forward movement
        if (Input.GetKey(KeyCode.W) == true)
        {
            ship.GetComponent<Rigidbody>().velocity = ship.transform.right * moverate;
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            ship.GetComponent<Rigidbody>().velocity = ship.transform.right* -moverate;
        }
        if (Input.GetKey(KeyCode.A) == true)
        {        
            ship.transform.Rotate(Vector3.up, (yawrate * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            ship.transform.Rotate(Vector3.up, (-yawrate * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Q) == true)
        {
            ship.transform.Rotate(Vector3.right, (rollrate * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.E) == true)
        {
            ship.transform.Rotate(Vector3.right, (-rollrate * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.CapsLock) == true)
        {
            ship.transform.Rotate(Vector3.forward, (pitchrate * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.F) == true)
        {
            ship.transform.Rotate(Vector3.forward, (-pitchrate * Time.deltaTime));
        }
    }
}
