
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start()
	{

	}

	[SerializeField]
	public float speed = 6;

	private bool isMovedLeft = true;
	private bool isMovedRight = true;
	private bool isJumpingLeft = true;
	private bool isJumpingRight = true;
	private readonly float thrust = 350.0f;
	private bool isJumping = false;


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow)) {
			isMovedLeft = true;
			isMovedRight = false;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			isMovedRight = true;
			isMovedLeft = false;
		} else {
			isMovedLeft = false;
			isMovedRight = false;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping) {
			isJumping = true;
			if (isMovedLeft) isJumpingLeft = true;
			else if (isMovedRight) isJumpingRight = true;
			GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
		}

		if (isMovedRight || isJumpingRight) {
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		} else if (isMovedLeft || isJumpingLeft) {
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Ground") {
			isJumping = false;
			isJumpingLeft = false;
			isJumpingRight = false;
		}
	}
}