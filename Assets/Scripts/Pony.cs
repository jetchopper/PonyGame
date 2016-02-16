using UnityEngine;
using System.Collections;

public class Pony : MonoBehaviour, ICollectable {

	public float runSpeed;
	public float rotateSpeed;

	private Vector3 collectorPosition;
	private Vector3 vectorToRun;
	private bool isRunning;
	private float zAngle;
	private Quaternion q;

	//interface methods
	public void Taken(Vector3 _targetPosition){
		collectorPosition = _targetPosition;
		isRunning = true;
	}
	public void OutOfRange(){
		isRunning = false;
	}

	void Update () {
		//moving and rotating the pony smoothly towards triggered dog
		if (isRunning){
			vectorToRun = collectorPosition - transform.position;
			zAngle = Mathf.Atan2(vectorToRun.y, vectorToRun.x) * Mathf.Rad2Deg;
			q = Quaternion.AngleAxis(zAngle - 180, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
			transform.Translate(Vector2.left * Time.deltaTime * runSpeed);
		}
	}
}
