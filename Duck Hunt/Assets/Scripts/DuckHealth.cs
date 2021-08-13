using UnityEngine;
using System.Collections;

public class DuckHealth : MonoBehaviour
{
    Animator anim;
    public bool isInvincible;
    private GameObject shoot;
    Shooter shooter;
    public bool isClicked = false;

    void Start()
    {
        //getcomponent
        shoot = GameObject.Find("Main Camera");
        shooter = shoot.GetComponent<Shooter>();
        isInvincible = false;
        anim = gameObject.GetComponent<Animator>();
        GameManager.OnDuckMiss += MakeInvincible;
      //  GameManager.OnDuckShot += MakeInvincible;

    }

    //void Update () {}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "KillZone")
        {
            if (StaticVars.instance.duckNum > 10)
            {
                if(GameManagerNew.instance.totalBirds<=0 && !GameManagerNew.instance.newRoundCalledOnce)
                {
                    Debug.Log("Bird reached kill zone");
                    GameManagerNew.instance.newRoundCalledOnce = true;
                    GameManager.OnNewRound();
                }
             
                Destroy(this.gameObject);
            }
            else
            {
                if (GameManagerNew.instance.totalBirds <= 0)
                {
                    GameManager.OnDuckDeath();
                    Debug.Log("It was called");
                }
               
                Destroy(this.gameObject);
            }
        }
        else if (hit.tag == "FlyAwayZone")
        {
            if (StaticVars.instance.duckNum > 10)
            {
                if (GameManagerNew.instance.totalBirds <= 0 && !GameManagerNew.instance.newRoundCalledOnce)
                {
                    Debug.Log("Bird reached fly away zone");
                    GameManagerNew.instance.newRoundCalledOnce = true;
                    GameManager.OnNewRound();
                }
                Destroy(this.gameObject);
            }
            else
            {
                GameManager.OnDuckFlyAway();
                Destroy(this.gameObject);
            }
        }
        print(StaticVars.instance.duckNum);
    }

    public void KillDuck()
    {
        if (isInvincible == false && isClicked)
        {
            //GameManager.OnDuckShot();
            MakeInvincible();
            anim.Play("duck death");
            Debug.Log(this.transform.gameObject.name);

        }
    }

    public void MakeInvincible()
    {
        isInvincible = true;
    }

    public void OnDisable()
    {
        GameManager.OnDuckMiss -= MakeInvincible;
       // GameManager.OnDuckShot -= MakeInvincible;
    }
}
