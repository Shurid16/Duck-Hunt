using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    

	void Update ()
	{
		if(Input.GetButton("Fire1"))
        {
            if(HighScoreController.instance.panelShowed)
            SceneManager.LoadScene("MainMenu");
        }
			
	}
}
