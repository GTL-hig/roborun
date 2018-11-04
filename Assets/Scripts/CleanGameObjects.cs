using UnityEngine;

public class CleanGameObjects : MonoBehaviour {


	/** 
	 * Called when other objects collides with us.
	 */
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.transform.parent) {
			Destroy(coll.gameObject.transform.parent.gameObject);
		} else {
			Destroy(coll.gameObject);
		}
	}
}
