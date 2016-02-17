using UnityEngine;
using System.Collections;

public class Pony : MonoBehaviour, ICollectable {

	public float runSpeed;

	public static int ponyCounter = 0;

	private Vector3 collectorPosition;
	private Vector3 vectorToRun;
	private bool isRunning;
	private bool inSafeZone;
	private float zAngle;
	private float timer;
	private Animator animator;
	private Transform _transform;
	
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
	//translate to the center of safe zone if there and disable pony
	public void InSafeZone(Vector3 _safeZonePosition){
		timer += Time.deltaTime;
		inSafeZone = true;
		if (inSafeZone){
			collectorPosition = _safeZonePosition;
			isRunning = true;
			animator.SetFloat("speed", 1f);
		}
		//disabling pony
		if (timer > 1f){
			isRunning = false;
			animator.SetFloat("speed", 0f);
			GetComponent<CircleCollider2D>().enabled = false;
			GetComponent<Pony>().enabled = false;
		}
	}

	void Start(){
		_transform = transform;
		animator = GetComponent<Animator>();
		ponyCounter++;
		timer = 0f;
	}

	void Update () {
		//moving the pony towards collector position (dog or safe zone)
		if (isRunning){
			vectorToRun = (collectorPosition - _transform.position).normalized;
			_transform.Translate(vectorToRun * Time.deltaTime * runSpeed);
		}
	}
}
