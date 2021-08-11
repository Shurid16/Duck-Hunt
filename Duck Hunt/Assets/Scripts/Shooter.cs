using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Shooter : MonoBehaviour
{
    RaycastHit hit;

    public AudioClip shot;
    public AudioSource source;
    private float volMin = .7f;
    private float volMax = .9f;

    public AudioClip win;
    public AudioClip lose;

    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;

    private Text scoreTxt;
    private int score;
    public GameObject scoreObject;

    private Text roundText;
    public GameObject roundObject;

    [SerializeField]
    private int bulletAmount;
    public int maxBullets;

    public GameObject[] redDuck;

	public GameObject whiteDucks;
	public Animator anim;

    private int duckShotNum;

    public GameObject[] directionChanger;

    private int _counter;

    // Use this for initialization
    void Start()
    {
		anim = whiteDucks.GetComponent<Animator>();

        scoreTxt = scoreObject.GetComponent<Text>();
        roundText = roundObject.GetComponent<Text>();
        StaticVars.instance.duckNum = 1;
        duckShotNum = 0;
        StaticVars.instance.roundNum = 1;

        maxBullets = 3;
        bulletAmount = 50;
        GameManager.OnSpawnDucks += ResetBullets;
        GameManager.OnSpawnDucks += ClickOn;
		GameManager.OnSpawnDucks += DuckGUI;
		GameManager.OnDuckMiss += DuckGUIStop;
		GameManager.OnDuckShot += DuckGUIStop;
        GameManager.OnNewRound += ResetRound;
        GameManager.OnNewRound += ResetBullets;
        GameManager.OnNewRound += RoundNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (StaticVars.instance.noClick == false)
            {
                bulletAmount--;
                BulletGUI(bulletAmount);

                if (bulletAmount < 0)
                {
                    bulletAmount = 20;
                    StaticVars.instance.roundNum++;
                    StaticVars.instance.noClick = true;
                    SetScore(0);
                    GameManager.OnDuckMiss();
                }

                if (0 <= bulletAmount && bulletAmount <= 3)
                {
                    float vol = UnityEngine.Random.Range(volMin, volMax);
                    source.PlayOneShot(shot, vol);
                }

                if (bulletAmount == 0)
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = Camera.main.transform.position.z;

                    Debug.DrawRay(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, Color.red, 3f);

                    if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, out hit, Mathf.Infinity))
                    {
                        if (hit.transform.tag == "Duck")
                        {
                            //StaticVars.instance.noClick = true;
                            DuckHealth health = hit.transform.GetComponent<DuckHealth>();
                            health.KillDuck();
                            SetScore(500);
                            duckShotNum++;
                            DuckGUIShot();
							StaticVars.instance.duckNum++;
                            Debug.Log("Bullet amount zero if");
                        }
                    }
                    else
                    {
                        StaticVars.instance.duckNum++;
                       // StaticVars.instance.noClick = true;
                        SetScore(0);
                        GameManager.OnDuckMiss();
                        Debug.Log("Bullet amount zero else");
                    }
                }
                else
                {
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = Camera.main.transform.position.z;

                    Debug.DrawRay(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, Color.red, 3f);

                    if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, out hit, Mathf.Infinity))
                    {
                        if (hit.transform.tag == "Duck")
                        {
                            //StaticVars.instance.noClick = true;
                            DuckHealth health = hit.transform.GetComponent<DuckHealth>();
                            health.KillDuck();
                            SetScore(500);
                            //duckShotNum++;
                           // DuckGUIShot();
							//StaticVars.instance.duckNum++;
                            Debug.Log("Actual Line" + _counter++);
						}
                    }
                }
            }
        }
    }


    public void SetScore(int _score)
    {
        score += _score;
        scoreTxt.text = score.ToString().PadLeft(6, '0');
        ScoreManager.instance.SetHighScore(score);
    }

    public void ResetRound()
    {
		for(int i = 0; i < 10; i++)
		{
			redDuck [i].SetActive (false);
		}
        StaticVars.instance.duckNum = 1;
    }

    public void DuckGUIShot()
    {
		redDuck [StaticVars.instance.duckNum-1].SetActive (true);
    }

	public void DuckGUI()
	{
        try
        {
            print("duckNum = " + StaticVars.instance.duckNum);
            switch (StaticVars.instance.duckNum)
            {
                case 1:
                    anim.Play("1"); break;
                case 2:
                    anim.Play("2"); break;
                case 3:
                    anim.Play("3"); break;
                case 4:
                    anim.Play("4"); break;
                case 5:
                    anim.Play("5"); break;
                case 6:
                    anim.Play("6"); break;
                case 7:
                    anim.Play("7"); break;
                case 8:
                    anim.Play("8"); break;
                case 9:
                    anim.Play("9"); break;
                case 10:
                    anim.Play("10"); break;
                default: break;
            }
        }
        catch(Exception e)
        {

        }
		
	}

	public void DuckGUIStop()
	{
			anim.Play ("no flash");
	}
		
		public void ResetBullets()
		{
        try
        {
            bulletAmount = maxBullets;
            bullet3.SetActive(true);
            bullet2.SetActive(true);
            bullet1.SetActive(true);
        }
        catch
        {
            Debug.Log("Bullet 3 Destroy Error");
        }
			
		}
		
		public void BulletGUI(int bullets)
		{
			if (bullets == 2)
			{
				bullet3.SetActive(false);
			}
			else if (bullets == 1)
			{
				bullet3.SetActive(false); bullet2.SetActive(false);
        }
        else if (bullets <= 0)
        {
            bullet3.SetActive(false); bullet2.SetActive(false); bullet1.SetActive(false);
        }
        else
        {
            bullet3.SetActive(true); bullet2.SetActive(true); bullet1.SetActive(true);
        }

    }

    public void RoundNum()
    {
        if (duckShotNum > 6)
        {
            source.PlayOneShot(win, 1);
            StaticVars.instance.roundNum++;
            roundText.text = "R = " + StaticVars.instance.roundNum.ToString();
        }
        else
        {
//            source.PlayOneShot(lose, 1);
//            StaticVars.instance.roundNum = 1;
//            roundText.text = "R = " + StaticVars.instance.roundNum.ToString();
//			score = 0;
//			scoreTxt.text = score.ToString().PadLeft(6, '0');
			Application.LoadLevel("GameOver");
        }
        duckShotNum = 0;
    }

    public void ClickOn()
    {
        StaticVars.instance.noClick = false;
    }

    private void OnDisable()
    {
        GameManager.OnSpawnDucks -= ResetBullets;
        GameManager.OnSpawnDucks -= ClickOn;
        GameManager.OnSpawnDucks -= DuckGUI;
        GameManager.OnDuckMiss -= DuckGUIStop;
        GameManager.OnDuckShot -= DuckGUIStop;
        GameManager.OnNewRound -= ResetRound;
        GameManager.OnNewRound -= ResetBullets;
        GameManager.OnNewRound -= RoundNum;

        
    }
}