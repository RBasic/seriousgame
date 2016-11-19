using UnityEngine;
using System.Collections;

public class FXPlayer : MonoBehaviour {

    [FMODUnity.EventRef]

    public string footSteps = "event:/Footsteps";
    public float poids;
	
    // Use this for initialization
	void Start () {
        poids = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FootSteps()
    {
        FMOD.Studio.EventInstance fs;
        FMOD.Studio.ParameterInstance Poids;
        //Poids.setValue(poids);
        fs = FMODUnity.RuntimeManager.CreateInstance(footSteps);
        fs.getParameter("Poids", out Poids);
        fs.start();
    }
}
