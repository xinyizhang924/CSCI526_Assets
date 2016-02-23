using UnityEngine;
using System.Collections;

public class EnemyController3 : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private Vector3 movement;
	private int count = 0;
	private System.Random random = new System.Random();


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		movement = new Vector3 (speed, 0, speed);
	}
	void FixedUpdate()
	{
		rb.AddForce (movement);
		count++;
		if (count > 20) {
			int x = random.Next (-20, 20);
			int z = random.Next (-20, 20);
			movement.x = x;
			movement.z = z;
			count = 0;
		}
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
