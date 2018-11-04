using UnityEngine;

public class CollectPickup : MonoBehaviour {


	public GameManager gameManager;

	public void Start()
	{
		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Destroy(gameObject);
			gameManager.pickupCoin();
		}
	}
}
