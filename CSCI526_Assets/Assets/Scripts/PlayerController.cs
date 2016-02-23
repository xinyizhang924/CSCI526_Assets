using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	public float minSwipeDistY;
	public float minSwipeDistX;
	public float tiltSpeed;

	private Vector2 startPos;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//		rb.AddForce (movement * speed);

		// keep moving forward

		transform.Translate (Vector3.forward * speed * Time.deltaTime);

		// press keyboard to turn left and right

		if (Input.GetKeyDown(KeyCode.RightArrow))
			transform.Rotate(0, 90, 0, Space.World);
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			transform.Rotate(0, -90, 0, Space.World);

		// mobile device swipe to turn left and right

		if (Input.touchCount > 0) {

			Touch touch = Input.touches [0];

			switch (touch.phase) {

			case TouchPhase.Began:

				startPos = touch.position;

				break;

			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				float swipeDistHorizontal = (new Vector3 (0, touch.position.x, 0) - new Vector3 (0, startPos.x, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) {
					float swipeValueVertical = Mathf.Sign (touch.position.y - startPos.y);
					if (swipeValueVertical > 0) {
//						transform.Translate (Vector3.forward * speed * Time.deltaTime);
//						flag = 3;
					} 
					else if (swipeValueVertical < 0) {
//						transform.Translate (Vector3.back * speed * Time.deltaTime);
//						flag = 4;
					}
				}
				else if (swipeDistHorizontal > minSwipeDistX) {
					float swipeValueHorizontal = Mathf.Sign (touch.position.x - startPos.x);
					if (swipeValueHorizontal > 0) {
						transform.Rotate(0, 90, 0, Space.World);
//						transform.Translate (Vector3.right * speed * Time.deltaTime);
//						flag = 1;
					} 
					else if (swipeValueHorizontal < 0) {
						transform.Rotate(0, -90, 0, Space.World);
//						transform.Translate (Vector3.left * speed * Time.deltaTime);
//						flag = 2;
					}
				}
				break;
			}
		}

		//tilt
		Vector3 tiltVec = new Vector3(Input.acceleration.x, 0, 0);
		transform.Translate(tiltVec * tiltSpeed * Time.deltaTime);

		// gyro

//		transform.Translate (Vector3.forward * tiltSpeed * Time.deltaTime);
//		Vector3 pos = transform.position;
//		pos.y = Vector3.Dot(Input.gyro.gravity, Vector3.up) * tiltSpeed;
//		transform.position = pos;

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Enermies"))
		{
			rb.gameObject.SetActive (false);
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
		}
	}
}
