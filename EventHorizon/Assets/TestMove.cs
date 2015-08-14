using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {
	public float ShipSpeed = 100;
	public float MaxVelocity;
	public float RotateSpeed = 10.0f;
	float brakeEnergy = 0;
	bool notBraking = true;
	Vector3 Angle;
	Rigidbody rb;
	Transform tf;
	// Use this for initialization
	void Start () {
		tf = gameObject.transform;
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		Angle.x = Input.GetAxis ("Horizontal");
		Angle.y = Input.GetAxis ("Vertical");
		Angle.z = 0;
		//Debug.Log (Angle);
		Debug.Log (Quaternion.Euler(Angle));
		if (Input.GetAxis ("Brake") != 0) {
			notBraking = false;
		}

		if (Angle.x != 0 || Angle.y != 0) {
			Angle.x *= -1;
			float tempAngle = Mathf.Atan2 (Angle.x, Angle.y) * Mathf.Rad2Deg;
			Vector3 tempVec = new Vector3 (0, 0, tempAngle);
			//Debug.Log (tf.rotation.eulerAngles);
			Quaternion nyuk = Quaternion.Slerp (tf.rotation, Quaternion.Euler (tempVec), 5 * Time.deltaTime);
			Debug.Log (nyuk);
			tf.rotation = (nyuk);
		
			Debug.Log (tf.rotation.eulerAngles);
			if (notBraking) {
				rb.AddForce (tf.up * (ShipSpeed * Time.deltaTime));
			} else {
				brakeEnergy += 100 * Time.deltaTime;
			}
			if (Input.GetAxis ("Brake") == 0 && notBraking == false) {
				//rb.velocity = Vector3.zero;
				rb.AddForce (tf.up * (ShipSpeed * Time.deltaTime) * brakeEnergy);
				notBraking = true;
				brakeEnergy = 0;

			}
		}

		Debug.Log (rb.velocity);

	}




}
