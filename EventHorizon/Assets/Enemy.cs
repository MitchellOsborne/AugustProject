﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float HP;
	public float maxHP;
	public float speed;
	Rigidbody rb;
	GameObject target;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			//Damage the player
		}

		if (HP <= 0) {
			Destroy (gameObject);
		}
	}
}
