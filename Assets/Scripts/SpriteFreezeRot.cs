﻿using UnityEngine;
using System.Collections;

public class SpriteFreezeRot : MonoBehaviour {

	private Vector3 prevPosition;

	//freezind look to far Z axis, flipping horizontally on delta position sings
	//used for dog as still sprite
	//it is made to avoid dog's sprite rotation because of it's parent move style
	void LateUpdate () {
		if(transform.position.x - prevPosition.x > 0f){
			transform.LookAt(Vector3.back * 100);
			transform.localRotation = Quaternion.Euler(0, 180, transform.localEulerAngles.z);
		}else{
			transform.LookAt(Vector3.forward * 100);
			transform.localRotation = Quaternion.Euler(0, 0, transform.localEulerAngles.z);
		}
		prevPosition = transform.position;
	}
}
