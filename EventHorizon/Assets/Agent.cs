using UnityEngine;
using System.Collections.Generic;

public class Agent : MonoBehaviour {
	public float Health;
	public float Movespeed;
	public float Team;
	public Rigidbody rb;
	public Vector3 Force;
	List<IBehaviour> BhList;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		BhList = new List<IBehaviour> ();
		BhList.Add (new Seek (this,GameObject.FindGameObjectWithTag("Player"), true));
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Destroy (gameObject);
		}
		foreach (IBehaviour bhv in BhList) {
			bhv.Update();
		}
	}
}
