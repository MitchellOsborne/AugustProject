using UnityEngine;
using System.Collections.Generic;

public class Agent : MonoBehaviour {
	public bool isPlayer;
	public float Health;
	public float Movespeed;
	public int Team;
	public Rigidbody rb;
	public Vector3 Force;
	public List<IBehaviour> BhList = new List<IBehaviour>();
	public SpawnManager sm;
	// Use this for initialization
	void Start () {
		sm = GameObject.FindGameObjectWithTag ("SpawnManager").GetComponent<SpawnManager> ();
		rb = GetComponent<Rigidbody> ();
		//BhList = new List<IBehaviour> ();
		if (isPlayer) {
			BhList.Add (new PlayerBhv (this, true));
		} else {
			BhList.Add(new Seek(this, sm.TeamList[0][0],true));
		}
		sm.TeamList [Team].Add (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			sm.TeamList[Team].Remove(gameObject);
			Destroy (gameObject);
		}
		foreach (IBehaviour bhv in BhList) {
			bhv.Update();
		}
		Force.Normalize ();
		rb.AddForce((Force * Movespeed)*Time.deltaTime);
		Force = Vector3.zero;
	}
}
