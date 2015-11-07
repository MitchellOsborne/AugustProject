using UnityEngine;
using System.Collections.Generic;

public class SmoothFollow : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public List<Transform> targets;
	public float MinCamDist, MaxCamDist;
	
	// Update is called once per frame
	void Update () 
	{
		if (targets.Count > 0)
		{
			Vector3 AvgPos = new Vector3(0,0,0);

			foreach(Transform tf in targets)
			{
				AvgPos += tf.position;

			}

			AvgPos /= targets.Count;

			Vector3 DistVec = new Vector3(0,0,0);
			float Dist = 0;
			foreach(Transform tf in targets)
			{
				DistVec = tf.position - AvgPos;
				if(Mathf.Abs (Dist) < Mathf.Abs (Vector3.Magnitude(DistVec)))
				{
					Dist = Mathf.Abs (Vector3.Magnitude(DistVec));
				}
				
			}
			Dist += 10;
			Dist = Mathf.Clamp (Dist, MinCamDist, MaxCamDist);
			GetComponent<Camera>().orthographicSize = Dist;

			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(AvgPos);
			Vector3 delta = AvgPos - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}
}