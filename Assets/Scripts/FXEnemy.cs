using UnityEngine;
using System.Collections;

public class FXEnemy : MonoBehaviour {

    [FMODUnity.EventRef]

    public string impact = "event:/Serious Game/FX/Impact patron";
    FMOD.Studio.EventInstance i;

    // Use this for initialization
    void Start () {
        i = FMODUnity.RuntimeManager.CreateInstance(impact);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void PlayImpact()
    {
        i.start();
    }
}
