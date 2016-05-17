using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {

	public GameObject holder;
	private bool isFired;
	private bool wait;
	private float angle;
	Rigidbody2D rgb2d;

	private Vector2 mouse;

	void Start () {
		angle = Mathf.Atan(Input.mousePosition.y/Input.mousePosition.x);
		isFired = false;
		wait = false;
		rgb2d = GetComponent<Rigidbody2D> ();

		mouse = Input.mousePosition;

	}

	void Update () {

		if (!isFired) {
			Physics2D.IgnoreLayerCollision (8, 9, true);
			rgb2d.transform.position = new Vector2 (holder.transform.position.x, holder.transform.position.y);

			//Gets mouse input and calculate angle
			mouse = Input.mousePosition;
			mouse = Camera.main.ScreenToWorldPoint(mouse);
			mouse = new Vector2(mouse.x - holder.transform.position.x,mouse.y - holder.transform.position.y);
			angle = Mathf.Atan(mouse.y/mouse.x );
			angle = Mathf.Rad2Deg*angle;

			//Moves the bar to the selected angle
			transform.rotation = Quaternion.AngleAxis(angle + 90,Vector3.forward);
		} else 
		{
			Physics2D.IgnoreLayerCollision(8, 9, false);
		}
	
	}

	public void fire(float speed)
	{
		rgb2d.velocity = new Vector2 (speed * mouse.x, speed * mouse.y);
		StartCoroutine (collidePlayer());
		isFired = true;
	}
	public void pickUp()
	{
		isFired = false;
		wait = false;
	}

	public bool getWait()
	{
		return wait;
	}

	public bool getFired()
	{
		return isFired;
	}

	IEnumerator collidePlayer()
	{
		yield return new WaitForSeconds(1);
		wait = true;
		yield return 0;
	}

}
