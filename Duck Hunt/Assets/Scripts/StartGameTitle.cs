using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameTitle : MonoBehaviour
{
	void Update()
	{
		if (Input.GetButtonUp ("Fire1"))
			SceneManager.LoadScene("DuckHunt");
	}
}
