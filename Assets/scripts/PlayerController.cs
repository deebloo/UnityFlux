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

	void OnEnable () {
		ScoreStore.OnScoreUpdated += SpeedUp;
	}

	void OnDisable () {
		ScoreStore.OnScoreUpdated -= SpeedUp;
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

	// when the score is see if it should speed up or not
	void SpeedUp (int score) {
		if(score >= 3) {
			speed += 25;
		}
	}
}