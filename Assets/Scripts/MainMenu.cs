using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text highScore;
	public Text lastScore;

	private int highScoreValue;
	private int lastScoreValue;

	// Use this for initialization
	void Start () {
		this.highScoreValue = PlayerPrefs.GetInt("high_score");
		this.lastScoreValue = PlayerPrefs.GetInt("last_score");
		highScore.text = "" + this.highScoreValue;
		lastScore.text = "" + this.lastScoreValue;
	}

	void Update()
	{
		this.highScoreValue = PlayerPrefs.GetInt("high_score");
		this.lastScoreValue = PlayerPrefs.GetInt("last_score");
		highScore.text = "" + this.highScoreValue;
		lastScore.text = "" + this.lastScoreValue;
	}

	public void playPressed() {
		SceneManager.LoadScene("Level_01");
	}
}
