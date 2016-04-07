using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name) {
		Debug.Log ("Loading Level " + name);
		
		// Loading the appropriate level
		Application.LoadLevel(name);
		Brick.breakableBrickCount = 0;
	}
	
	public void QuitRequest() {
		Debug.Log("Quit Request was called");
		
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
		Brick.breakableBrickCount = 0;
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableBrickCount <= 0) {
			LoadNextLevel();
		}
	}
}
