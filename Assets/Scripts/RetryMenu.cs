using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetryMenu : MonoBehaviour {

	//retry menu
	public void ActivateRetryMenu(){
		GetComponent<Image>().enabled = true;
		transform.GetChild(0).gameObject.SetActive(true);
	}
	//button method
	public void Retry(){
		Application.LoadLevel(0);
	}
}
