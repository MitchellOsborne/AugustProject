using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
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
		Vector3 tempVec = rb.position - target.transform.position;
		tempVec.Normalize ();
		rb.position -= tempVec *(speed * Time.deltaTime);
	}
}
