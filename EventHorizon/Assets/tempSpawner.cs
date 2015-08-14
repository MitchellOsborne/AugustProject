using UnityEngine;
using System.Collections;

public class tempSpawner : MonoBehaviour {
	public GameObject obj;
	public float spawnInterval = 0;
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
			GameObject.Instantiate(obj, gameObject.transform.position, gameObject.transform.rotation);
		}
	}
}
