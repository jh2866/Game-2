using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class detectHit : MonoBehaviour {

	public GameObject bulletObject;
	public Slider healthBar;
	Animator anim;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			healthBar.value -= 10;
			if (healthBar.value <= 0)
			{
				anim.SetBool ("isDead", true);
				Destroy (this.gameObject, 5.0f);
			}

		}

	}
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
