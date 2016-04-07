using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	
	private bool started = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			this.transform.position = paddle.transform.position  + paddleToBallVector;
		
			if (Input.GetMouseButtonDown(0)) {
				started = true;
				print ("MOUSE CLICKED");
				this.rigidbody2D.velocity = new Vector2(0f, 8f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		int yDirection = rigidbody2D.velocity.y > 0 ? 1 : -1;
		Vector2 tweak = new Vector2(Random.Range(-.2f, 1.5f) * yDirection, Random.Range(-0.1f, 0.4f));
		if(started) {	
			audio.Play();
			
			rigidbody2D.velocity += tweak;
		}
	}
}
