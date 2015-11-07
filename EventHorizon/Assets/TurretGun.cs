using UnityEngine;
using System.Collections;

public class TurretGun : MonoBehaviour {
	public GameObject BulletType;
	public float turretRange;
	public int team;
	public SpawnManager sm;
	public float turretSpeed;
	private GameObject target;
	private float fireCounter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fireCounter += Time.deltaTime;

		if (target == null) {
			for(int i = 0; i < sm.NumOfTeams; ++i)
			{
				if(i != team)
				{
					foreach(GameObject obj in sm.TeamList[i])
					{
						if(obj.GetComponent<Agent>())
						{
							//if(Vector3.Magnitude (transform.position - obj.transform.position) > turretRange)
							//{
								target = obj;
							//}
						}
					}
				}
			}
			
		} else 
		{
			float Rads = Mathf.Atan2 (transform.position.y- target.transform.position.y, transform.position.x - target.transform.position.x) * 180 / Mathf.PI;
			Quaternion q = new Quaternion(0,0,Rads*(180/Mathf.PI)*2,0);
			transform.rotation = q;
			if(fireCounter > BulletType.GetComponent<Projectile>().fireRate)
			{
				fireCounter = 0;
				GameObject obj = (GameObject)GameObject.Instantiate(BulletType, transform.position, transform.rotation);
				//Debug.Log(obj.GetComponent<Agent>().BhList.Count);
				obj.GetComponent<Agent>().BhList.Add (new Travel(obj.GetComponent<Agent>(),true,gameObject.transform.up));
				obj.GetComponent<Agent>().Team = gameObject.GetComponentInParent<Agent>().Team;
			}
		}

		if (Vector3.Magnitude (transform.position - target.transform.position) > turretRange) {
			target = null;
		}
		
	}
}
