using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			GameObject gameManager = GameObject.FindWithTag("GameManager");
			gameManager.GetComponent<GameManager>().storeScore();
			SceneManager.LoadScene("Main");
		}
	}
}
