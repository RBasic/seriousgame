using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updateVolume : MonoBehaviour
{
    public Slider Volume;
    public Slider SFX;

    AudioManager A;

	// Use this for initialization
	public void Start ()
	{
        Volume.onValueChanged.AddListener(delegate {changeMusicVolume();});
        SFX.onValueChanged.AddListener(delegate { changeSFXVolume(); });
        A = GameManager.instance.getAudioManager();

    }

    // Update is called once per frame
    public void Update ()
    {
        Debug.Log("Je suis la =D");        
	}

    public void changeMusicVolume()
    {
        float vol = Volume.value;
        A.changeMusicVolume(vol);
    }

    public void changeSFXVolume()
    {
        float vol = SFX.value;
        A.changeSFXVolume(vol);
    }
}
