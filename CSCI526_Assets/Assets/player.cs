using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	float horizontalPlayerSpeed = 1f;
	bool touchWall = false;

	void Update(){
		// keep moving forward
		transform.Translate (Vector3.forward * 1f * Time.deltaTime);

		// stop at walls
		if (!touchWall)
			transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * horizontalPlayerSpeed * Time.deltaTime);
		else {
			transform.Translate (Vector3.right * Time.deltaTime * 2);
			touchWall = false;
		}

	}

	void OnTriggerEnter(Collider other) {
		//		Destroy(other.gameObject);
		if (other.gameObject.CompareTag("Wall"))
		{
			touchWall = true;
		}

	}

	int getHorizontalPosition(float n){
		if (n < 0)
			return -1;
		if (n > 0)
			return 1;
		return 0;
	}
}
