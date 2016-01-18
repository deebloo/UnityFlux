using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;

	public float speed;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody> ();
		speed = 10;
	}

	// update here when physics are involved
    void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
    }

	// update the score and desactivate collectables
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive (false);

			Actions.UpdateScore();
		}
	}
}