using UnityEngine;
using System.Collections;

public class LGun : MonoBehaviour {
	public Object BulletType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetAxis ("Fire1") != 0) {
			GameObject obj = (GameObject)GameObject.Instantiate(BulletType, gameObject.transform.position, gameObject.transform.rotation);
			obj.GetComponent<Projectile>().InitVel (GetComponentInParent<Rigidbody>().velocity);
		}
	}
}
