using UnityEngine;

public class ConstantMovement : MonoBehaviour {

	// Speed of camera movement
	public float speed = 1f;

	// Handle to the main character
	public Transform player;

	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;

	private float m_OffsetZ;
	private Vector3 m_LastTargetPosition;
	private Vector3 m_CurrentVelocity;
	private Vector3 m_LookAheadPos;

	private GameManager gameManager;

	// Use this for initialization
	void Start()
	{
		GameObject go = GameObject.FindWithTag("GameManager");
		gameManager = go.GetComponent<GameManager>();
		gameManager.currentScore = 0;
		m_LastTargetPosition = player.position;
		m_OffsetZ = (transform.position - player.position).z;
		transform.parent = null;
		transform.TransformVector(new Vector3(1f, 0f, 1f));
	}


	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.right * Time.deltaTime * speed);
		gameManager.updateScore(gameManager.currentScore + (int)(Time.deltaTime * 100));

		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (player.position - m_LastTargetPosition).x;
		if (xMoveDelta > 0) {
			bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

			if (updateLookAheadTarget) {
				m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
			} else {
				m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
			}

			Vector3 aheadTargetPos = player.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
			Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);
			newPos.y = 0;

			transform.position = newPos;

			m_LastTargetPosition = player.position;
		}
	}

}
