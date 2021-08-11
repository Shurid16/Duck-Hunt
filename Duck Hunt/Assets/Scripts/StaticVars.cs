using UnityEngine;
using System.Collections;

public class StaticVars : MonoBehaviour
{

    public static StaticVars instance;


    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
      
    }

    public bool noClick;
	public int roundNum;
	public int duckNum;
    public bool paused;


}
