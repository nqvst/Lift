using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust2D : MonoBehaviour {

	public enum Side { Left = 0, Right = 1, Both = 2 }
	public Side side;

	bool isThrustingRight = false;
	bool isThrustingLeft = false;
	bool isThrusting = false;


	void Start () {
		SetExhaust (0);
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

		if (Input.GetAxis("ThrustR") > 0 && (side == Side.Right || side == Side.Both))
		{
			isThrustingRight = true;

		}

		if (Input.GetAxis("ThrustL") > 0 && (side == Side.Left || side == Side.Both) )
		{
			isThrustingLeft = true;
		}

		isThrusting = isThrustingLeft || isThrustingRight;

		if(isThrusting) {
			SetExhaust(Random.Range(0, 1.5f));
		} else {
			SetExhaust(0);
		}



	}

	void SetExhaust(float exhaustRate) {
		transform.localScale = new Vector3(transform.localScale.x, exhaustRate, transform.localScale.z);

	}
}
