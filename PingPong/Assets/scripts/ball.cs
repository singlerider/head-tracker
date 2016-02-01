using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ball : MonoBehaviour {
    private new AudioSource audio;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(-5, 0, -1);
        rb.AddForce(movement, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            

        }
       // if (collision.relativeVelocity.magnitude > 2)
       audio.Play();

    }
}
