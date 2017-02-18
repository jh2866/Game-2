﻿using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{
	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject Bullet_Emitter;

	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject Bullet;

	//Enter the Speed of the Bullet from the Component Inspector.
	public float Bullet_Forward_Force;

	private bool triggerDown;
	private float able;
	private float cooldown = 0.3f;
	private float total = 0;
	private bool hold = false;
	// Use this for initialization
	void Start ()
	{
		triggerDown = false;
	}

	// Update is called once per frame
	void Update ()
	{
		
		able = Time.time - total;
		if (Input.GetAxisRaw ("Fire1") != 1)
		{
			hold = false;
		}
		else
		{
			hold = true;
		}
		if (Input.GetAxisRaw("Fire1") == 1 && able > cooldown)
		{
			total += able;
			able = 0;
			triggerDown = true;
		}
		if ((Input.GetKeyDown(KeyCode.Mouse0) || triggerDown == true) && hold == false)
		{
			//The Bullet instantiation happens here.
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;

			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_Bullet_Handler.transform.Rotate(Vector3.left * -90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			Temporary_RigidBody.AddForce(transform.up * Bullet_Forward_Force);

			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(Temporary_Bullet_Handler, 3.0f);
			triggerDown = false;
		}
	}

}