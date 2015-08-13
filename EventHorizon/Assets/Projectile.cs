using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float damage;
	public float speed;
	public float lifetime;
	private float age = 0;
	private Vector3 initVelocity;
	// Use this for initialization
	void Start () {
		gameObject.tag = "PlayerBullet";
	}

	public void InitVel(Vector3 Vel)
	{
		initVelocity = Vel;
	}
	
	// Update is called once per frame
	void Update () {
		age += Time.deltaTime;

		gameObject.transform.position += ((transform.up * speed) + initVelocity)* Time.deltaTime;

		if(age > lifetime)
		{
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.GetType());
		if (other.gameObject.tag != "PlayerBullet") {
			Destroy (gameObject);
		}
	}
}
