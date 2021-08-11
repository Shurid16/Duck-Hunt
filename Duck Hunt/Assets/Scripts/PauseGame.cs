using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{
	public GameObject pausedPopup;
	public AudioClip pauseSound;
	public AudioSource source;
	public GameObject pausedText;
	int EscapeNum = 0;



	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.P))
		{
			StaticVars.instance.paused = !StaticVars.instance.paused;

			if (StaticVars.instance.paused)
			{
				source.PlayOneShot (pauseSound);
				pausedPopup.SetActive (true);
				pausedText.SetActive (true);
			}
			else if (!StaticVars.instance.paused)
			{
				pausedPopup.SetActive (false);
				pausedText.SetActive (false);
			}
		}

		if (Input.GetKeyUp (KeyCode.Escape))
		{
			StaticVars.instance.paused = !StaticVars.instance.paused;
			
			if (StaticVars.instance.paused)
			{
				source.PlayOneShot (pauseSound);
				pausedPopup.SetActive (true);
				pausedText.SetActive (true);
			}
			else if (!StaticVars.instance.paused)
				Application.Quit ();
		}

		if (StaticVars.instance.paused) 
		{
			Time.timeScale = 0;
		}

		else if (!StaticVars.instance.paused)
		{
			Time.timeScale = 1;
		}
	}
}
