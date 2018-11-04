using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	public Text score;
	private GameManager gameManager;

	public void Start()
	{
		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}


	// Update is called once per frame
	void Update () {
		score.text = "" + gameManager.currentScore;
	}
}
