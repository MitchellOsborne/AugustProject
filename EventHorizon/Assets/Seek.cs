using UnityEngine;
using System.Collections;

public class Seek : IBehaviour {
	public GameObject Target;
	// Use this for initialization

	public Seek (Agent aAgent, GameObject aTarget, bool EnableAtStart) : base(aAgent, EnableAtStart)
	{
		Target = aTarget;
	}
	
	// Update is called once per frame
	override public void Update () {
		Vector3 tempVec = ThisAgent.rb.position - Target.transform.position;
		tempVec.Normalize ();
		ThisAgent.rb.position -= tempVec *(ThisAgent.Movespeed * Time.deltaTime);
	}

	public void Disable()
	{
		isEnabled = false;
	}

	public void Enable()
	{
		isEnabled = true;
	}

	void SetTarget(GameObject aTarget)
	{
		Target = aTarget;
	}
}
