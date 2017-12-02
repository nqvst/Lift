using UnityEngine;
using System.Collections;

public class Exhaust : MonoBehaviour {

	public enum Side { Left = 0, Right = 1, Both = 2 }
	public Side side;

	ParticleSystem sys;

	bool isThrustingRight = false;
	bool isThrustingLeft = false;
	bool isThrusting = false;

	void Awake() {
		sys = GetComponent<ParticleSystem>();
	}

	void Start () {
		SetEmmisiionRate (0);
	}

	void Update ()
	{
		isThrustingLeft = isThrustingRight = isThrusting = false;

		if (Input.touchCount > 0)
		{
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				{
					if ((touch.position.x < Screen.width/2 )  && (side == Side.Left || side == Side.Both) )
					{
						isThrustingLeft = true;
					}

					if ((touch.position.x > Screen.width/2)  && (side == Side.Right || side == Side.Both) )
					{
						isThrustingRight = true;

					}
				}
			}
		}

		if( Input.GetAxis("ThrustR") > 0 && (side == Side.Right || side == Side.Both))
		{
			isThrustingRight = true;

		}

		if (Input.GetAxis("ThrustL") > 0 && (side == Side.Left || side == Side.Both) )
		{
			isThrustingLeft = true;
		}

		isThrusting = isThrustingLeft || isThrustingRight;

		if(isThrusting) {
			SetEmmisiionRate(400);
		} else {
			SetEmmisiionRate(0);
		}



	}

	void SetEmmisiionRate(float emissionRate) {
		var em = sys.emission;
		var rate = new ParticleSystem.MinMaxCurve();
		rate.constantMax = emissionRate;
		em.rateOverTime = rate;

	}
}
