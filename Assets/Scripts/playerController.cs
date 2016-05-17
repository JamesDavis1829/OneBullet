using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float moveSpeed;
	public float maxSpeed;
	public float jumpSpeed;
	public float bulletSpeed;
	public GameObject bullet;

	private Rigidbody2D rb2d;
	private bool canJump = true;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	
	}

	void Update () {
		float direction = Input.GetAxis ("Horizontal");


		rb2d.velocity = new Vector2 (direction * moveSpeed, rb2d.velocity.y);

		if (canJump) {
			if (Input.GetKey (KeyCode.Space)) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed);
			}
		}

		if (!rb2d.IsTouchingLayers (LayerMask.GetMask ("Wall"))) {
			canJump = false;
		} else {
			canJump = true;
		}

		if (Input.GetKey (KeyCode.Mouse0) && !bullet.GetComponent<bulletBehaviour>().getFired ())
		{
			bullet.GetComponent<bulletBehaviour> ().fire (bulletSpeed);
		}

		if (bullet.GetComponent<bulletBehaviour>().getWait() && bullet.GetComponent<bulletBehaviour> ().getFired() && rb2d.IsTouchingLayers(LayerMask.GetMask("PBullet")))
		{
			bullet.GetComponent<bulletBehaviour>().pickUp();
		}


		
	}
	
}
