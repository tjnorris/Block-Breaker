using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public static int breakableBrickCount = 0;
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	
	private int timesHit = 0;
	private LevelManager levelManager;
	private bool isBreakable;
	
	void Start () {
		isBreakable = (this.tag == "Breakable");
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		if (isBreakable) {
			breakableBrickCount++;
		}
		print ("Count: " + breakableBrickCount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		
		if (isBreakable) {
			HandleHits();
		}
		
		print ("Count: " + breakableBrickCount);
		if (breakableBrickCount == 0) {
			levelManager.LoadNextLevel();
		}
		
	}
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			AudioSource.PlayClipAtPoint(crack, transform.position);
			Destroy(gameObject);
			breakableBrickCount--;
			levelManager.BrickDestroyed();
		}
		else {
			LoadSprites();
		}
	}
	
	void LoadSprites() {
		int index = timesHit - 1;
		if (hitSprites[index]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[index];
		}
	}
}
