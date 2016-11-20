using UnityEngine;
using System.Collections;

public class FXPlayer : MonoBehaviour {

    [FMODUnity.EventRef]

    public string footStep1 = "event:/Footstep1";
    public string footStep2 = "event:/Footstep2";

    public float poids;
    FMOD.Studio.EventInstance fs1;
    FMOD.Studio.EventInstance fs2;

    // Use this for initialization
    void Start () {

        fs1 = FMODUnity.RuntimeManager.CreateInstance(footStep1);
        fs1.setParameterValue("Poids", poids);
        fs2 = FMODUnity.RuntimeManager.CreateInstance(footStep2);
        fs2.setParameterValue("Poids", poids);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FootStep1()
    {
        fs1.start();
    }

    public void FootStep2()
    {
        fs2.start();
    }
}
