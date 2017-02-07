using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FighterController : MonoBehaviour {
        
    //intialize variables
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float moveBuffer;

    [SerializeField]
    float angleBuffer;

    [SerializeField]
    GameObject sisterController;

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

    private float movespeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       

        {
            Vector3 move = gameObject.transform.localPosition;

            //this if statment handles forward movement
            if ((gameObject.transform.localPosition.x - offset.x) > moveBuffer && (sisterController.transform.localPosition.x - offset.x) > moveBuffer)
            {
                movespeed = moverate * ((gameObject.transform.localPosition.x + sisterController.transform.localPosition.x) - 2 * offset.x);
                ship.GetComponent<Rigidbody>().velocity = ship.transform.right * movespeed;
            }
            //this if statment handles backward movement
            else if ((gameObject.transform.localPosition.x - offset.x) < moveBuffer && (sisterController.transform.localPosition.x - offset.x) < moveBuffer)
            {
                movespeed = moverate * ((gameObject.transform.localPosition.x + sisterController.transform.localPosition.x) - 2 * offset.x);
                ship.GetComponent<Rigidbody>().velocity = ship.transform.right * movespeed;
            }
            //this if statment handles ship yaw
            else if ((gameObject.transform.localPosition.x - offset.x) != 0 && (sisterController.transform.localPosition.x - offset.x) != 0)
            {
                ship.transform.Rotate(Vector3.up, (yawrate * (gameObject.transform.localPosition.x - sisterController.transform.localPosition.x)) * Time.deltaTime);
            }

            //this block of if and if else statments handles roll I spearated the statments to deal with the cases where one rotation is poitive and the other is negative (so it doesn't rotate in this case)
            if (gameObject.transform.localRotation.x > angleBuffer && sisterController.transform.localRotation.x > angleBuffer)
            {
                ship.transform.Rotate(Vector3.right, (rollrate * (gameObject.transform.localEulerAngles.x + sisterController.transform.localEulerAngles.x)) * Time.deltaTime);
            }
            else if (gameObject.transform.localRotation.x < angleBuffer && sisterController.transform.localRotation.x < angleBuffer)
            {
                ship.transform.Rotate(Vector3.left, (negativerollrate * (gameObject.transform.localEulerAngles.x + sisterController.transform.localEulerAngles.x)) * Time.deltaTime);
            }
            //this block of if and else if statments handles pitch
            if (gameObject.transform.localRotation.z > angleBuffer && sisterController.transform.localRotation.z > angleBuffer)
            {
                ship.transform.Rotate(Vector3.forward, (pitchrate * (gameObject.transform.localEulerAngles.z + sisterController.transform.localEulerAngles.z)) * Time.deltaTime);
            }
            else if (gameObject.transform.localRotation.z < angleBuffer && sisterController.transform.localRotation.z < angleBuffer)
            {
                ship.transform.Rotate(Vector3.back, (negativepitchrate * (gameObject.transform.localEulerAngles.z + sisterController.transform.localEulerAngles.z)) * Time.deltaTime);
            }
        }
    }
}
