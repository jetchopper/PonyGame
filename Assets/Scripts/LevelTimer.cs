using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

	public float initLevelTime;

	private Text text;
	
	void Start () {
		initLevelTime += 1f;
		text = GetComponent<Text>();
		text.text = "TIME " + (int)initLevelTime;
	}
	
	//level countdown and retry screen
	void Update () {
		initLevelTime -= Time.deltaTime;
		text.text = "TIME " + (int)initLevelTime;
		if (initLevelTime < 1f){
			Debug.Log ("lost");
			text.text = "";
		}
	}
}
