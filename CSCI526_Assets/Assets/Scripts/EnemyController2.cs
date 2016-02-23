using UnityEngine;
using System.Collections;

public class EnemyController2 : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private Vector3 movement;


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		movement = new Vector3 (speed, 0, speed);
	}
	void FixedUpdate()
	{
		rb.AddForce (movement);
	}
	void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag ("WallsAndBlocks")) {
			return;
		}
		//var otherPosition = other.gameObject.transform.position;
		var otherPosition = collision.contacts[0].point;
		var playerPosition = gameObject.transform.position;
		if (System.Math.Abs (otherPosition.x - playerPosition.x) > System.Math.Abs (otherPosition.z - playerPosition.z)) {
			movement.x = -movement.x;
		} else
			movement.z = -movement.z;
	}
}
