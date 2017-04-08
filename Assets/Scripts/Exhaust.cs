using UnityEngine;
using System.Collections;

public class Exhaust : MonoBehaviour {

	public enum Side { Left = 0, Right = 1 }
	public Side side;

	ParticleSystem sys;
	void Awake() {
		sys = GetComponent<ParticleSystem>();
	}

	void Start () {
		SetEmmisiionRate (1);
	}
	
	void Update () 
	{

		if (Input.touchCount > 0)
		{
			foreach (Touch touch in Input.touches) 
			{
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				{
					if ((touch.position.x < Screen.width/2 )  && side == Side.Left )
					{
						SetEmmisiionRate(400);
					}
					else if ((touch.position.x > Screen.width/2)  && side == Side.Right )
					{
						SetEmmisiionRate (400);
					}
				}
			}			
		} 
		else if( Input.GetAxis("ThrustR") > 0 && side == Side.Right)
		{
			SetEmmisiionRate(400);

		} 
		else if (Input.GetAxis("ThrustL") > 0 && side == Side.Left )
		{
			SetEmmisiionRate (400);
		}
		else {
			SetEmmisiionRate (400);
		}

	}
		
	void SetEmmisiionRate(float emissionRate) {
		var em = sys.emission;
		var rate = new ParticleSystem.MinMaxCurve();
		rate.constantMax = emissionRate;
		em.rate = rate;

	}
}
