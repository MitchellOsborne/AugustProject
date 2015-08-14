using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {
	public GameObject BulletType;
	public string FireKey;
	private float fireCounter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetAxis (FireKey) != 0) {
			fireCounter += Time.deltaTime;
			if(fireCounter > BulletType.GetComponent<Projectile>().fireRate)
			{
				fireCounter = 0;
				GameObject obj = (GameObject)GameObject.Instantiate(BulletType, gameObject.transform.position, gameObject.transform.rotation);
				obj.GetComponent<Projectile>().InitVel (GetComponentInParent<Rigidbody>().velocity);
			}
		}
	}
}
