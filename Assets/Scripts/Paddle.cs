using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private static int numWorldUnits = 16;
	public bool isAutoplay;
	
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isAutoplay) {
			MoveWithMouse();
		}
		else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse() {
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * numWorldUnits;
		
		float minimumXPosition = 0.5f;
		float maximumXPosition = numWorldUnits - 0.5f;
		
		Vector3 newPosition = new Vector3(Mathf.Clamp(mousePosInBlocks, minimumXPosition, maximumXPosition), this.transform.position.y);
		
		
		this.transform.position = newPosition;
	}
	
	void AutoPlay() {
		float newXPos = ball.transform.position.x;
		float minimumXPosition = 0.5f;
		float maximumXPosition = numWorldUnits - 0.5f;
		
		Vector3 newPosition = new Vector3(Mathf.Clamp(newXPos, minimumXPosition, maximumXPosition), this.transform.position.y);
		
		this.transform.position = newPosition;
	}
}
