using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

	public Transform Player;
	public float speed = 2f;

	public Slider LifeBar;

	private float minDistance = 0.2f;

	private float range;
	
	void Start () {
		Player = GameObject.FindWithTag ("Player").transform;
	 }
	
	void Update () {
		Player = GameObject.FindWithTag ("Player").transform;
		range = Vector2.Distance(transform.position, Player.position);

		if (range > minDistance) {
			Player = GameObject.FindWithTag ("Player").transform;
			transform.position = Vector2.MoveTowards (transform.position, Player.position, speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			Slider LifeBar = Player.GetComponent<PlayerManager>().LifeBar;
			LifeBar.value -= 20;

			Text score = Player.GetComponent<PlayerManager>().score;
			
			int currentScore = Player.GetComponent<PlayerManager>().currentScore ++;

			score.text = currentScore.ToString();
			
			Destroy (GameObject.FindWithTag ("Enemy"));
		}
	}
}
