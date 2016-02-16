using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			Debug.Log("wow");
			c.GetComponent<ICollectable>().Taken(transform.position);
		}
	}
}
