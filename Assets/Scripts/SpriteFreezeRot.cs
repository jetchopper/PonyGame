using UnityEngine;
using System.Collections;

public class SpriteFreezeRot : MonoBehaviour {

	private Vector3 prevPosition;
	private Transform _transform;

	//freezind look to far Z axis, flipping horizontally on delta position sings
	//used for dog as still sprite
	//it is made to avoid dog's sprite rotation because of it's parent move style
	void Start(){
		_transform = transform;
	}

	void LateUpdate () {
		if(_transform.position.x - prevPosition.x > 0f){
			_transform.LookAt(Vector3.back * 100);
			_transform.localRotation = Quaternion.Euler(0, 180, _transform.localEulerAngles.z);
		}else{
			_transform.LookAt(Vector3.forward * 100);
			_transform.localRotation = Quaternion.Euler(0, 0, _transform.localEulerAngles.z);
		}
		prevPosition = _transform.position;
	}
}
