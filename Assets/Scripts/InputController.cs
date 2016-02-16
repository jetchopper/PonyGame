using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	private RuntimePlatform runPlatform;
	private bool touch;

	private Vector2 screenPointPosition;

	private Transform selectedTransform;

	void Start () {
		//to determine either mouse or touch use
		runPlatform = Application.platform;
		if (runPlatform == RuntimePlatform.Android || runPlatform == RuntimePlatform.IPhonePlayer){
			touch = true;
		}
	}

	void Update () {
		//reading click or touch on screen in pixels
		if (touch){
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				screenPointPosition = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
				SelectOrMove(screenPointPosition);
			}
		}else{
			if (Input.GetMouseButtonDown(0)){
				screenPointPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
				SelectOrMove(screenPointPosition);
			}
		}
	}
	//select if selectable, otherwise move selected if selected :)
	private void SelectOrMove(Vector2 _screenPointPosition){
		Vector2 worldPointPosition = new Vector2(Camera.main.ScreenToWorldPoint(_screenPointPosition).x, 
		                                          Camera.main.ScreenToWorldPoint(_screenPointPosition).y);
		RaycastHit2D hit = Physics2D.Raycast(worldPointPosition, Vector2.zero, 20);
		//parsing our hit
		if (hit){
			if (hit.transform.GetComponent<ISelectable>() != null){
				//deselecting
				if (selectedTransform != null){
					selectedTransform.GetComponent<ISelectable>().Selected();
				}
				//selecting
				selectedTransform = hit.transform;
				selectedTransform.GetComponent<ISelectable>().Selected();
			}else{
				if (selectedTransform != null){
					selectedTransform.GetComponent<ISelectable>().SetTouchPoint(worldPointPosition);
				}
			}
		}else{
			if (selectedTransform != null){
				selectedTransform.GetComponent<ISelectable>().SetTouchPoint(worldPointPosition);
			}
		}
	}
}
