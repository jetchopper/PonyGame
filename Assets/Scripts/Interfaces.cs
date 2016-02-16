using UnityEngine;
using System.Collections;

public interface ISelectable {

	void Selected();
	void SetTouchPoint(Vector2 touchPoint);
}
