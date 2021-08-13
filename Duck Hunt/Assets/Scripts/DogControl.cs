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

    public bool dogAnimPlaying;
    public bool popDogClipPlayed;

    public static DogControl instance;


    private void Awake()
    {
        instance = this;
    }

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
        GameManagerNew.instance.newRoundCalledOnce = false;
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
           Debug.Log("Round End");
            if (!popDogClipPlayed)
            {
                anim.Play("dog popup");
                if (!source.isPlaying)
                {
                    source.PlayOneShot(gotDuck, 1);
                }
                popDogClipPlayed = true;
            }
        
        
		
    }
		

    public void PlayNewRound()
    {
        //if(!GameManagerNew.instance.newRoundCalledOnce)
        if(true)
        {
            GameManagerNew.instance.newRoundCalledOnce = true;
            anim.Play("dog walking");
        }
       
    }

    public void OnDisable()
    {
        GameManager.OnDuckDeath -= PlayPopup;
        GameManager.OnDuckFlyAway -= PlayLaugh;
        //        GameManager.OnStartGame += PlayIntro;
        GameManager.OnNewRound -= PlayNewRound;
    }
}