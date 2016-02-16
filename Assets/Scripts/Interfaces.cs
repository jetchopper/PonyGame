using UnityEngine;
using System.Collections;

//these are for any who can be controlled
public interface ISelectable {
	void Selected();
	void SetTouchPoint(Vector2 touchPoint);
}
//these are for any who can be taken
public interface ICollectable{
	void Taken(Vector3 targetPosition);
	void OutOfRange();
}
