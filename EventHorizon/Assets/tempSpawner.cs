using UnityEngine;
using System.Collections;

public class tempSpawner : MonoBehaviour {
	public GameObject obj;
	public float spawnInterval = 0;
	public float forceMultiply;
	private float spawnCounter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		spawnCounter += Time.deltaTime;
		if(spawnCounter > spawnInterval)
		{
			spawnCounter = 0;
			GameObject Temp = (GameObject)GameObject.Instantiate(obj, gameObject.transform.position, gameObject.transform.rotation);

			Vector3 Direction = new Vector3();
			Direction.x = Random.Range(-100,100);
		    Direction.y = Random.Range(-100,100);
			Temp.GetComponent<Rigidbody>().AddForce(Direction*forceMultiply);

		}
	}
}
