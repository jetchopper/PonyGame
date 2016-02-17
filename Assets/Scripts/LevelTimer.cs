using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

	public float initLevelTime;

	public static float currentLevelTime;

	private float buffTime;
	private Text text;
	private bool isRunning;

	//GUI timer
	void Start () {
		buffTime = 0f;
		currentLevelTime = initLevelTime;
		text = GetComponent<Text>();
		text.text = "TIME " + (int)currentLevelTime;
		isRunning = true;
	}
	
	//updating GUI timer per second
	void Update () {
		if (isRunning){
			buffTime += Time.deltaTime;
			if (buffTime > 1f){
				currentLevelTime--;
				OnScreenTimer();
				buffTime -= 1f;
			}
		}
	}
	//GUI timer
	private void OnScreenTimer(){
		text.text = "TIME " + (int)currentLevelTime;
		if (currentLevelTime < 1f){
			RetryMenu retryMenu = FindObjectOfType(typeof(RetryMenu)) as RetryMenu;
			retryMenu.ActivateRetryMenu();
			text.text = "";
			isRunning = false;
		}
	}
}
