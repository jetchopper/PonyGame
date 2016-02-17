﻿using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

	public int ponyAmountForBonus;

	private float bonusTimer;
	private int ponyCount;
	private int totalPonyCount;
	private bool startCountdown;
	private Transform _transform;
	
	void Start(){
		bonusTimer = 0f;
		ponyCount = 0;
		totalPonyCount = 0;
		_transform = transform;
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
	//counting all icollectable
	//checking if all icollectables collected
	public void OnTriggerEnter2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			ponyCount++;
			totalPonyCount++;
			if (totalPonyCount == Pony.ponyCounter){
				LevelTimer.currentLevelTime = 0;
			}
			bonusTimer = 1f;
			startCountdown = true;
		}
	}
	//calling icollectable to move in center of safe zone
	public void OnTriggerStay2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			c.GetComponent<ICollectable>().InSafeZone(_transform.position);
		}
	}
}
