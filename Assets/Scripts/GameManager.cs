using UnityEngine;

public class GameManager : MonoBehaviour {

	public int highScoreValue = 0;
	public int currentScore = 0;

	public static GameManager instance;


	public int CoinReward = 100;


	public void updateScore(int newValue) {
		currentScore = newValue;
	}

	public void pickupCoin() {
		currentScore += CoinReward;
	}

	public void storeScore() {
		highScoreValue = PlayerPrefs.GetInt("high_score");
		if (currentScore > highScoreValue) {
			PlayerPrefs.SetInt("high_score", currentScore);
		}

		PlayerPrefs.SetInt("last_score", currentScore);
	}

}
