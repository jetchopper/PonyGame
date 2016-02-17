using UnityEngine;
using System.Collections;

public class BonusSpawner : MonoBehaviour {

	public float size;
	public GameObject bonus;

	private Vector3 randomPoint;

	//just spawns bonus in random field of determined size
	public void Spawn(){
		randomPoint = new Vector3(Random.Range(-size, size), Random.Range(-size, size), 0f);
		Instantiate(bonus, transform.position + randomPoint, Quaternion.identity);
	}
}
