using UnityEngine;

public class Ball : MonoBehaviour {

    public float initialVelocity = 600f;

    private Rigidbody rigidbody;
    private bool ballInPlay = false;

	// Use this for initialization
	void Awake ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1") && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            rigidbody.isKinematic = false;
            rigidbody.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
        }
	}
}
