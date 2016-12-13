using UnityEngine;
using System.Collections;

public class FXPlayer : MonoBehaviour {

    [FMODUnity.EventRef]

    public string footStep1 = "event:/Serious Game/FX/Footstep1";
    public string footStep2 = "event:/Serious Game/FX/Footstep2";
    public string jump = "event:/Serious Game/FX/Jump";
    public string down = "event:/Serious Game/FX/Down";
    public string attack = "event:/Serious Game/FX/Attack";

    private Animator Anim;
    private bool ground;
    private bool downing = false;


    public float poids;
    FMOD.Studio.EventInstance fs1;
    FMOD.Studio.EventInstance fs2;
    FMOD.Studio.EventInstance j;
    FMOD.Studio.EventInstance d;
    FMOD.Studio.EventInstance a;

    // Use this for initialization
    void Start () {

        fs1 = FMODUnity.RuntimeManager.CreateInstance(footStep1);
        fs1.setParameterValue("Poids", poids);
        fs2 = FMODUnity.RuntimeManager.CreateInstance(footStep2);
        fs2.setParameterValue("Poids", poids);

        j = FMODUnity.RuntimeManager.CreateInstance(jump);
        d = FMODUnity.RuntimeManager.CreateInstance(down);
        d.setParameterValue("Poids", poids);

        a = FMODUnity.RuntimeManager.CreateInstance(attack);

        Anim = GameObject.Find("body").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        ground = (Anim.GetBool("ground") && Anim.GetFloat("vSpeed") == 0.0f);

        if(!ground)
        {
            downing = true;
        }
        else if(downing)
        {
            Down();
            downing = false;
        }
	}

    public void FootStep1()
    {
        fs1.start();
    }

    public void FootStep2()
    {
        fs2.start();
    }

    public void Jump()
    {
        j.start();
    }

    public void Down()
    {
        d.start();
    }

    public void Attack()
    {
        a.start();
    }
}
