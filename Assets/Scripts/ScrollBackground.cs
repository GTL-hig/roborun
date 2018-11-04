using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public float scrollSpeed = 0.01f;

	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(Time.time * scrollSpeed, 0f);
		GetComponent<Renderer>().material.mainTextureOffset = offset;

	}
}
