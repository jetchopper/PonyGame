using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour, ICollectable {

	public float timeToDie;
	public float runSpeed;
	public float bonusTime;

	private bool isRunning;
	private Vector3 collectorPosition;
	private Vector3 vectorToRun;

	//interface methods
	public void Taken(Vector3 _targetPosition){
		collectorPosition = _targetPosition;
		isRunning = true;
	}
	public void OutOfRange(){
	}
	public void InSafeZone(Vector3 safeZonePosition){
	}

	void Awake () {
		Destroy(gameObject, timeToDie);
	}

	void Update () {
		//moving bonus towards collector position (dog)
		if (isRunning){
			vectorToRun = collectorPosition - transform.position;
			transform.Translate(vectorToRun * Time.deltaTime * runSpeed);
			if (Vector3.Distance(transform.position, collectorPosition) < 0.5f){
				//give bonus (calling level time)
				LevelTimer levelTimer = FindObjectOfType(typeof(LevelTimer)) as LevelTimer;
				levelTimer.initLevelTime += bonusTime;
				Destroy(gameObject);
			}
		}
	}
}
