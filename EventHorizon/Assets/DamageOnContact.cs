using UnityEngine;
using System.Collections;

public class DamageOnContact : MonoBehaviour {
	public float Damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Other)
	{
		if(Other.tag == "Agent")
		{
			if(Other.GetComponent<Agent>().Team != gameObject.GetComponent<Agent>().Team)
			{
				Other.GetComponent<Agent>().Health -= Damage;
				if(gameObject.GetComponent<Projectile>() != null)
				{
					Destroy(gameObject);
				}
			}
		}
	}
}
