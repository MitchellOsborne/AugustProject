using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
	public GameObject Player;
	public float NumOfTeams;
	public List<List<GameObject>> TeamList = new List<List<GameObject>>();
	// Use this for initialization
	void Start () {
		for (int x = 0; x < NumOfTeams; x+=1) {
			TeamList.Add (new List<GameObject> ());
		}
		TeamList [0].Add (Player);
	}
	
	// Update is called once per frame
	void Update () {
	if (TeamList [2].Count > 5) 
		{
			Debug.Log (TeamList[2].Count);
		}
	}
}
