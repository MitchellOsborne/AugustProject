using UnityEngine;
using System.Collections;

public class Travel : IBehaviour {

	public Vector3 Velocity;

		public Travel (Agent aAgent, bool EnableAtStart, Vector3 aVel) :base(aAgent, EnableAtStart)
		{
		Velocity = aVel;	
		}
		
		// Update is called once per frame
		override public void Update () {
			
		ThisAgent.rb.position += (Velocity);
		}
		
		public void Disable()
		{
			isEnabled = false;
		}
		
		public void Enable()
		{
			isEnabled = true;
		}
	
}


