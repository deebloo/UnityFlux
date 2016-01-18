using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float x = 15;
	public float y = 30;
	public float z = 45;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime);
	}
}