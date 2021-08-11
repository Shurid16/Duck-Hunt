using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DogControl : MonoBehaviour
{
	Animator anim;
	AudioSource source;

    public AudioClip laugh;
    public AudioClip bark;
	public AudioClip gotDuck;
    public AudioClip intro;

	void Start ()
	{
		source = GetComponent<AudioSource> ();
		anim = GetComponent<Animator>();
		GameManager.OnDuckDeath += PlayPopup;
		GameManager.OnDuckFlyAway += PlayLaugh;
//        GameManager.OnStartGame += PlayIntro;
        GameManager.OnNewRound += PlayNewRound;
	}

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
	
	public void SpawnDucks()
	{
		GameManager.OnSpawnDucks();
	}

	public void PlayLaugh()
	{
        anim.Play ("dog laugh");
        source.PlayOneShot(laugh, 1);
    }

//    public void PlayIntro()
//    {
//        anim.Play("dog walking");
//        source.PlayOneShot(intro, 1);
//    }

    public void PlayBark()
    {
        source.PlayOneShot(bark, 1);
    }

    public void PlayPopup()
	{
		anim.Play ("dog popup");
		source.PlayOneShot(gotDuck, 1);
	}

    public void PlayNewRound()
    {
        anim.Play("dog walking");
    }

    public void OnDisable()
    {
        GameManager.OnDuckDeath -= PlayPopup;
        GameManager.OnDuckFlyAway -= PlayLaugh;
        //        GameManager.OnStartGame += PlayIntro;
        GameManager.OnNewRound -= PlayNewRound;
    }
}