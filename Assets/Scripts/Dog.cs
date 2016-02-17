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
	private Transform _transform;

	//interface methods
	//select or deselect object
	public void Selected(){
		selected = selected ? false : true;
		GetComponentInChildren<SpriteRenderer>().enabled = selected ? true : false;
	}
	//set point to follow if selected
	public void SetTouchPoint(Vector2 touchPoint){
		if (selected){
			pointToRun = (Vector3)touchPoint;
			isRunning = true;
		}
	}

	void Start(){
		_transform = transform;
	}

	void Update () {
		//moving and rotating the dog smoothly towards given point
		//just for better performance the dog will be running circles
		if (isRunning){
			vectorToRun = pointToRun - _transform.position;
			zAngle = Mathf.Atan2(vectorToRun.y, vectorToRun.x) * Mathf.Rad2Deg;
			q = Quaternion.AngleAxis(zAngle - 180, Vector3.forward);
			_transform.rotation = Quaternion.Slerp(_transform.rotation, q, Time.deltaTime * rotateSpeed);
			_transform.Translate(Vector2.left * Time.deltaTime * runSpeed);
		}
	}
	
	//calling for magneting ICollectable items (ponys, bonuses)
	public void OnTriggerStay2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			c.GetComponent<ICollectable>().Taken(_transform.position);
		}
	}
	//demagneting
	public void OnTriggerExit2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			c.GetComponent<ICollectable>().OutOfRange();
		}
	}
}
