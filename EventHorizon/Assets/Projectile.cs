using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float lifetime;
	public float fireRate = 0;
	private float age = 0;
	private Vector3 initVelocity;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		age += Time.deltaTime;
		if(age > lifetime)
		{
			Destroy (gameObject);
		}
	}

}
