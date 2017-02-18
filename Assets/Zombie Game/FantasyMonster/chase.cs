using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chase : MonoBehaviour 
{
	public Transform player;
	Animator anim;
	public Slider healthBar;
	static double walkDistance = 2;
	static double runDistance = 5;
	static double idleDistance = 15;
	static double visionAngle = 30;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}


	// Update is called once per frame
	void Update () 
	{
		if (healthBar.value <= 0)
			return;

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle (direction, this.transform.forward);
		if (Vector3.Distance (player.position, this.transform.position) < idleDistance) {
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

			anim.SetBool ("isIdle", false);
			if (direction.magnitude > runDistance) 
			{
				this.transform.Translate (0, 0, 0.15f);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isRunning", true);
				anim.SetBool ("isAttacking", false);
			} 
			else if (direction.magnitude > walkDistance) 
			{
				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isAttacking", false);
			}
			else 
			{
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isAttacking", true);
			}
		} 
		else
		{
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isRunning", false);
		}
	}
}