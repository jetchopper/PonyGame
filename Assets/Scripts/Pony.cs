using UnityEngine;
using System.Collections;

public class Pony : MonoBehaviour, ICollectable {

	public float runSpeed;

	private Vector3 collectorPosition;
	private Vector3 vectorToRun;
	private bool isRunning;
	private bool inSafeZone;
	private float zAngle;
	private float timer;
	private Animator animator;
	
	//interface methods
	//receiving position of an object to follow if not in safe zone
	public void Taken(Vector3 _targetPosition){
		if (!inSafeZone){
			collectorPosition = _targetPosition;
			isRunning = true;
			animator.SetFloat("speed", 1f);
		}
	}
	//stop if out of range
	public void OutOfRange(){
		isRunning = false;
		animator.SetFloat("speed", 0f);
	}
	//translate to the center of safe zone if there
	public void InSafeZone(Vector3 _safeZonePosition){
		timer += Time.deltaTime;
		inSafeZone = true;
		if (inSafeZone){
			collectorPosition = _safeZonePosition;
			isRunning = true;
			animator.SetFloat("speed", 1f);
		}
		if (timer > 1f){
			isRunning = false;
			animator.SetFloat("speed", 0f);
		}
	}

	void Start(){
		animator = GetComponent<Animator>();
		timer = 0f;
	}

	void Update () {
		//moving the pony towards collector position (dog or safe zone)
		if (isRunning){
			vectorToRun = (collectorPosition - transform.position).normalized;
			transform.Translate(vectorToRun * Time.deltaTime * runSpeed);
		}
	}
}
