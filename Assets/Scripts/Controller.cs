using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public float speed;
    public float jumpHeight;

    private Rigidbody rigidBody;
    private Vector3 startPos;
    
    // Use this for initialization
	void Start () {
        startPos = transform.position;
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.S))
        { 
            rigidBody.AddForce(new Vector3(-speed/2, 0, -speed / 2));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(new Vector3(speed / 2, 0, -speed / 2));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(new Vector3(-speed / 2, 0, speed / 2));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(new Vector3(speed / 2, 0, speed / 2));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector3(0, jumpHeight, 0));
        }
    }

    void OnBecameInvisible()
    {
        transform.position = startPos;
        rigidBody.velocity = Vector3.zero;
    }
}
