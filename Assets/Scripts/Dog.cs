using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour, ISelectable {

	public float runSpeed;
	public float rotateSpeed;
	
	private bool selected;
	private bool isRunning;
	private Vector3 pointToRun;
	private Vector3 vectorToRun;
	private float zAngle;
	private Quaternion q;

	//interface methods
	//select or deselect object
	public void Selected(){
		selected = selected ? false : true;
	}
	//set point to follow
	public void SetTouchPoint(Vector2 touchPoint){
		if (selected){
			pointToRun = (Vector3)touchPoint;
			isRunning = true;
		}
	}

	void Update () {
		//moving and rotating the dog smoothly towards given point
		if (isRunning){
			vectorToRun = pointToRun - transform.position;
			zAngle = Mathf.Atan2(vectorToRun.y, vectorToRun.x) * Mathf.Rad2Deg;
			q = Quaternion.AngleAxis(zAngle - 180, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
			transform.Translate(Vector2.left * Time.deltaTime * runSpeed);
		}
	}
	
	//calling for magneting ICollectable items (ponys)
	public void OnTriggerStay2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			c.GetComponent<ICollectable>().Taken(transform.position);
		}
	}
	//demagneting
	public void OnTriggerExit2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			c.GetComponent<ICollectable>().OutOfRange();
		}
	}
}
