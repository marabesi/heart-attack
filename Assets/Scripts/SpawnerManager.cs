using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

	public GameObject enemy;
	float x;
	float y;
	Vector2 whereSpawn;
	public float spawnTime = 2f;
	float nextSpawn = 0f;

	void Start () {}
	
	void Update () {
		if (Time.time > nextSpawn) 
		{
			nextSpawn = Time.time + spawnTime;

			x = Random.Range (389f, 395f);
			y = Random.Range(651f, 641f);

			whereSpawn = new Vector2 (x, y);
			Instantiate (enemy, whereSpawn, Quaternion.identity);
		}
	}
}
