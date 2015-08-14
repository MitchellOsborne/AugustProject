using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public bool rotation;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (rotation == true) {
			transform.Rotate (new Vector3 (0, 0, 3));
		} else {
			transform.Rotate (new Vector3 (0, 0, -3));
		}
	}
}
