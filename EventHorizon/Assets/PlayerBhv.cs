using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBhv : IBehaviour {

	public float ShipSpeed = 2000;
	public float MaxVelocity;
	public float RotateSpeed = 3.0f;
	public float maxBoosterEnergy = 200;
	private ParticleSystem boosterPS;
	private ParticleSystem thrusterPS;
	float boosterEnergy = 0;
	bool notBoosting = true;
	Vector2 Angle;
	Rigidbody rb;
	Transform tf;

	public PlayerBhv (Agent aAgent, bool EnableAtStart) : base(aAgent, EnableAtStart)
	{
		tf = ThisAgent.gameObject.transform;
		rb = ThisAgent.gameObject.GetComponent<Rigidbody> ();
		thrusterPS = ThisAgent.GetComponent<ParticleManager> ().thrusterPS;
		boosterPS = ThisAgent.GetComponent<ParticleManager> ().boosterPS;
	}
	
	// Update is called once per frame
	override public void Update () {
		
		Angle.x = Input.GetAxis ("Horizontal");
		Angle.y = Input.GetAxis ("Vertical");
		//Angle.z = 0;
		//Debug.Log (Angle);
		Debug.Log (Quaternion.Euler(Angle));
		if (Input.GetAxis ("Brake") != 0) {
			notBoosting = false;
		}
		
		if(Angle.x != 0 || Angle.y != 0)
		{
			Angle.x *= -1;
			float tempAngle = Mathf.Atan2 (Angle.x, Angle.y) * Mathf.Rad2Deg;
			Vector3 tempVec = new Vector3(0,0,tempAngle);
			//Debug.Log (tf.rotation.eulerAngles);
			Quaternion nyuk = Quaternion.Slerp (tf.rotation,Quaternion.Euler(tempVec), RotateSpeed*Time.deltaTime);
			Debug.Log (nyuk);
			tf.rotation = (nyuk);
			
			if (notBoosting) {
				rb.AddForce (tf.up * (ShipSpeed * Time.deltaTime));
				rb.drag = 2f;
			} else {
				if(rb.velocity.magnitude < 10)
				{
					rb.drag = 0;
				}else{
					rb.drag = 2f;
				}
				thrusterPS.Stop();
				boosterEnergy += 100*Time.deltaTime;
				if (boosterEnergy > maxBoosterEnergy)
				{
					boosterEnergy = maxBoosterEnergy;
				}
			}
		}
		Debug.Log (tf.rotation.eulerAngles);
		
		if (Input.GetAxis("Brake") == 0 && notBoosting == false) {
			//rb.velocity = Vector3.zero;
			rb.AddForce (tf.up * (ShipSpeed * Time.deltaTime) * boosterEnergy);
			notBoosting = true;
			boosterEnergy = 0;
			boosterPS.Play ();
			thrusterPS.Play();
		}
		
		
		Debug.Log (boosterEnergy);
		GameObject.FindGameObjectWithTag ("HealthText").GetComponent<Text> ().text = ThisAgent.Health.ToString ();
	}
}
