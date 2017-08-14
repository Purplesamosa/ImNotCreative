using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public GameObject[] platforms;
    public Rigidbody2D playerRigidBody;
    public bool toggleLayers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { // Turn off collision possiblities
        if (playerRigidBody != null)
        {
            if (playerRigidBody.velocity.y > 0 && !toggleLayers)
            {
                for (int i = 0; i < platforms.Length; i++)
                {
                    platforms[i].layer = 10;
                }
                toggleLayers = true;
            } // Turn on collision possiblities
            else if (playerRigidBody.velocity.y < 0 && toggleLayers)
            {
                for (int i = 0; i < platforms.Length; i++)
                {
                    platforms[i].layer = 9;
                }
                toggleLayers = false;
            }
        }
	}
}