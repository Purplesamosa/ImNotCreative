using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rigidBody2D;
    public int Health = 100;
    public float speed;
    public float jumpDefault;
    public Transform checkpoint;
    public float jumpPower;
    public bool isTouchingGround;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.anyKey)
        {
#region X-Axis Control
            if(Input.GetKey(KeyCode.A))
            {
                //-1
                rigidBody2D.velocity = new Vector2(-1, rigidBody2D.velocity.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //1
                rigidBody2D.velocity = new Vector2(1, rigidBody2D.velocity.y);
            }
            else
            {
                rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                //velocity*speed
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x * speed, rigidBody2D.velocity.y); 
            }
            #endregion

#region Y-Axis Control
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(isTouchingGround == true)
                {
                    rigidBody2D.AddForce(new Vector2(0, jumpPower));
                    isTouchingGround = false;
                }
            }
        }
        if (rigidBody2D.velocity.y > jumpDefault)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpDefault);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire"))
        {
            Health -= 25;
            Debug.Log(Health);
            if (Health <= 0)
            {
                DestroyObject(gameObject);
            }
        }
        else if(other.CompareTag("Medic"))
        {
            Health += 25;
            Debug.Log(Health);
        }
        else if(other.CompareTag("Void"))
        {
            rigidBody2D.transform.position = checkpoint.position;
        }
        else if(other.CompareTag("CheckPoint"))
        {
            checkpoint = other.transform;
        }
    }
}
