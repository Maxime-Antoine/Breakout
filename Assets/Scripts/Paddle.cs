using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float paddleSpeed = 1f;
    public float leftMvtLimit = -10f;
    public float rightMvtLimit = 10f;

    private float Y_POS = -9.5f;
    private float Z_POS = 0;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);
	

	// Update is called once per frame
	void Update ()
    {
        float xPos = transform.position.x - (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, leftMvtLimit, rightMvtLimit), Y_POS, Z_POS);
        transform.position = playerPos;
	}
}
