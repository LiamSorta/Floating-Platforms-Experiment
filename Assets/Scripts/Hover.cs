using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {

    private bool flip = false;
    private float hoverVal = 0;
    private float hoverFloatSpeed = 0.0001f;
    private float hoverMax = 0.002f;

    private Rigidbody rigidBody;
    private Vector3 startPos;
    private Quaternion startRot;

    // Use this for initialization
    void Start() {
        startRot = transform.rotation;
        startPos = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        hoverMax = Random.Range(0.001f, 0.003f);
        hoverFloatSpeed = Random.Range(0.00008f, 0.00015f);
    }

    // Update is called once per frame
    void Update()
    {
        if (hoverVal >= hoverMax)
            flip = true;
        if (hoverVal <= -hoverMax)
            flip = false;

        if (flip)
            hoverVal -= hoverFloatSpeed;
        else
            hoverVal += hoverFloatSpeed;

        transform.position = new Vector3(transform.position.x, transform.position.y + hoverVal, transform.position.z);


        if (Random.Range(1, 1000) == 1)
            StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        for(int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-0.015f, 0.015f), transform.position.z);
        }
        
        rigidBody.isKinematic = false;
    }

    void OnBecameInvisible()
    {
        rigidBody.isKinematic = true;
        transform.position = startPos;
        transform.rotation = startRot;

    }
}
