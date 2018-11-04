
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

	public GameObject [] platforms;
	public float spawnTimeMin = 1f;
	public float spawnTimeMax = 3f;

	// Use this for initialization
	void Start () {
		SpawnNewPlatform();	
	}

	void SpawnNewPlatform() {
		Instantiate(platforms [Random.Range(0, platforms.Length)], transform.position, Quaternion.identity);
		Invoke("SpawnNewPlatform", Random.Range(spawnTimeMin, spawnTimeMax));
	}
	
}
