using UnityEngine;
using System.Collections;

public class IBehaviour{
	public Agent ThisAgent;
	public bool isEnabled;
	// Use this for initialization

	public IBehaviour (Agent aAgent, bool EnabledAtStart)
	{
		ThisAgent = aAgent;
		isEnabled = EnabledAtStart;
	}

	// Update is called once per frame
	public virtual void Update () {
	
	}
}
