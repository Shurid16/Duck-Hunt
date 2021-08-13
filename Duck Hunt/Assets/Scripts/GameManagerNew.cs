using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerNew : MonoBehaviour
{

    public int level = 1;
    public int totalBirds = 0;
    public bool newRoundCalledOnce = false;
    public bool roundEnd = false;
    public static GameManagerNew instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GameManager.OnNewRound += OnNewRound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OneBirdKilled()
    {
        totalBirds--;
        if (totalBirds <= 0)
        {
            StaticVars.instance.noClick = true;
            roundEnd = true;
        }
    }

    public void OnNewRound()
    {
        level++;
        if (level > 2) { level = 2; };
        newRoundCalledOnce = false;
        roundEnd = false;
        DogControl.instance.dogAnimPlaying = true;
        DogControl.instance.popDogClipPlayed = true;
}

    private void OnDisable()
    {
       
        GameManager.OnNewRound -= OnNewRound;
    }
}
