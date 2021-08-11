using UnityEngine;
using System.Collections;

public class DuckHealth : MonoBehaviour
{
    Animator anim;
    public bool isInvincible;
    private GameObject shoot;
    Shooter shooter;

    void Start()
    {
        //getcomponent
        shoot = GameObject.Find("Main Camera");
        shooter = shoot.GetComponent<Shooter>();
        isInvincible = false;
        anim = gameObject.GetComponent<Animator>();
        GameManager.OnDuckMiss += MakeInvincible;
        GameManager.OnDuckShot += MakeInvincible;

    }

    //void Update () {}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "KillZone")
        {
            if (StaticVars.instance.duckNum > 10)
            {
                GameManager.OnNewRound();
                Destroy(this.gameObject);
            }
            else
            {
                GameManager.OnDuckDeath();
                Destroy(this.gameObject);
            }
        }
        if (hit.tag == "FlyAwayZone")
        {
            if (StaticVars.instance.duckNum > 10)
            {
                GameManager.OnNewRound();
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
        if (isInvincible == false)
        {
            GameManager.OnDuckShot();
            anim.Play("duck death");

        }
    }

    public void MakeInvincible()
    {
        isInvincible = true;
    }

    public void OnDisable()
    {
        GameManager.OnDuckMiss -= MakeInvincible;
        GameManager.OnDuckShot -= MakeInvincible;
    }
}
