using UnityEngine;
using System.Collections;

public class Exhaust : MonoBehaviour {

	public float amount = 100;
	public enum Side { Left = 0, Right = 1 }
	public Side side;

	void Start () {
		particleSystem.emissionRate = 1;
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
						particleSystem.emissionRate = 400;
					}
					else if ((touch.position.x > Screen.width/2)  && side == Side.Right )
					{
						particleSystem.emissionRate = 400;					
					}
				}
			}			
		} 
		else if( Input.GetAxis("ThrustR") > 0 && side == Side.Right)
		{
			particleSystem.emissionRate = 400;

		} 
		else if (Input.GetAxis("ThrustL") > 0 && side == Side.Left )
		{
			particleSystem.emissionRate = 400;
		}
		else {
			particleSystem.emissionRate = 1;
		}

	}

}
