using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyPauseMenu : MonoBehaviour
{
	public Transform canvas;
	public Transform Player;

	public Button resumeText;
	public Button quitText;

	void Start()
	{
		Cursor.lockState = 0;
		Cursor.visible = false;
		canvas.gameObject.SetActive (false);
		quitText = quitText.GetComponent<Button> ();
		resumeText = resumeText.GetComponent<Button> ();
	}

	void Update()
	{
		if (canvas.gameObject.activeInHierarchy == true) 
		{
			Cursor.visible = true;
			Cursor.lockState = 0;
		}
		else if (canvas.gameObject.activeInHierarchy == false) 
		{
			Cursor.visible = false;
		}
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown("joystick button 9")) 
		{
			pause ();
		}
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown ("joystick button 17"))
		{
			NoPress ();
		}
	}
	public void pause()
	{
		if (canvas.gameObject.activeInHierarchy == false) 
		{
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			Player.GetComponent<FirstPersonController> ().enabled = false;
		} 
		else 
		{
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			Player.GetComponent<FirstPersonController> ().enabled = true;
		}
	}

	public void ExitPress ()
	{
		SceneManager.LoadScene (0);
		resumeText.enabled = false;
		quitText.enabled = false;
	}

	public void NoPress ()
	{
		canvas.gameObject.SetActive (false);
		resumeText.enabled = true;
		quitText.enabled = true;
		Time.timeScale = 1;
		Player.GetComponent<FirstPersonController> ().enabled = true;
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}
}