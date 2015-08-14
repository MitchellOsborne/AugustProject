﻿using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {
	public float ShipSpeed = 100;
	public float MaxVelocity;
	public float RotateSpeed = 20.0f;
	public float maxBoosterEnergy = 400;
	public ParticleSystem boosterPS;
	public ParticleSystem thrusterPS;
	float boosterEnergy = 0;
	bool notBoosting = true;
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
			notBoosting = false;
		}

		if(Angle.x != 0 || Angle.y != 0)
		{
					Angle.x *= -1;
					float tempAngle = Mathf.Atan2 (Angle.x, Angle.y) * Mathf.Rad2Deg;
					Vector3 tempVec = new Vector3(0,0,tempAngle);
					//Debug.Log (tf.rotation.eulerAngles);
			float rot = RotateSpeed - rb.velocity.magnitude;
			if(!notBoosting)
			{
				rot = RotateSpeed = 0;
			}
			if(rot < 0)
			{
				rot *= -1;
			}
			Debug.Log(rot);
			
					Quaternion nyuk = Quaternion.Slerp (tf.rotation,Quaternion.Euler(tempVec), rot*Time.deltaTime);
			
					Debug.Log (nyuk);
					tf.rotation = (nyuk);

			if (notBoosting) {
				rb.AddForce (tf.up * (ShipSpeed * Time.deltaTime));
				rb.drag = 0.2f;
			} else {
				if(rb.velocity.magnitude < 10)
				{
				rb.drag = 0;
				}else{
					rb.drag = 0.2f;
				}
				thrusterPS.Stop();
				boosterEnergy += 100*Time.deltaTime;
			}
		}
		Debug.Log (tf.rotation.eulerAngles);

		if (Input.GetAxis("Brake") == 0 && notBoosting == false) {
			//rb.velocity = Vector3.zero;
			rb.AddForce (tf.up * (ShipSpeed * Time.deltaTime) * boosterEnergy);
			notBoosting = true;
			boosterEnergy = 0;
			boosterPS.Emit(1000);
			thrusterPS.Play();
		}


		Debug.Log (boosterEnergy);

	}




}
