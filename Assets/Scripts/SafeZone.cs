using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

	public int ponyAmountForBonus;

	private float bonusTimer;
	private int ponyCount;
	private int totalPonyCount;
	private bool startCountdown;
	
	void Start(){
		bonusTimer = 0f;
		ponyCount = 0;
		totalPonyCount = 0;
	}

	void Update(){
		//setting bonus if given amount of ponies saved with 1 second timer delay
		if (startCountdown){
			bonusTimer -= Time.deltaTime;
			if (bonusTimer < 0f){
				startCountdown = false;
				bonusTimer = 0f;
				ponyCount = 0;
			}
			if (bonusTimer > 0 && ponyCount == ponyAmountForBonus){
				startCountdown = false;
				bonusTimer = 0f;
				ponyCount = 0;
				//calling spawner
				BonusSpawner spawner = FindObjectOfType(typeof (BonusSpawner)) as BonusSpawner;
				spawner.Spawn();
			}
		}
	}
	//counting ponies setting countdown for bonus
	public void OnTriggerEnter2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			ponyCount++;
			Debug.Log(ponyCount);
			totalPonyCount++;
			bonusTimer = 1f;
			startCountdown = true;
		}
	}

	public void OnTriggerStay2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			c.GetComponent<ICollectable>().InSafeZone(transform.position);
		}
	}
}
