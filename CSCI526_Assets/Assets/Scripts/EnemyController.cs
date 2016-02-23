using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private int turn_around = 0;
	private Vector3 movement;


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		movement = new Vector3 (0, 0, speed);
	}
	void FixedUpdate()
	{
		if (turn_around > 30) {
			movement.z = -movement.z;
			turn_around = -30;
		} else {
			turn_around++;
			rb.AddForce (movement);
		}
	}
}
