using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour, ISafeZone {

	public void OnTriggerStay2D(Collider2D c){
		if (c.GetComponent<ICollectable>() != null){
			c.GetComponent<ICollectable>().InSafeZone(transform.position);
		}
	}
}
