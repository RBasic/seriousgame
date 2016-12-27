using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour {

    [FMODUnity.EventRef]

    int type = 0;

    public string menuTheme = "event:/Serious Game/Music/Menu";
    public string themeWhite = "event:/Serious Game/Music/ThemeWhite";
    public string themeAsian = "event:/Serious Game/Music/ThemeAsian";
    public string themeAfrica = "event:/Serious Game/Music/ThemeAfrica";
    public string themeArabic = "event:/Serious Game/Music/ThemeArabic";
    public string themeBoss = "event:/Serious Game/Music/Boss";

    public string paused = "snapshot:/Pause";
    public string lowReverb = "snapshot:/LowReverb";
    public string midReverb = "snapshot:/MidReverb";
    public string highReverb = "snapshot:/HighReverb";

    public static FMOD.Studio.Bus MusicBus;
    public static FMOD.Studio.Bus SFXBus;

    FMOD.Studio.EventInstance menu;
    FMOD.Studio.EventInstance white;
    FMOD.Studio.EventInstance arabic;
    FMOD.Studio.EventInstance africa;
    FMOD.Studio.EventInstance asian;
    FMOD.Studio.EventInstance boss;

    FMOD.Studio.EventInstance p;
    FMOD.Studio.EventInstance lr;
    FMOD.Studio.EventInstance mr;
    FMOD.Studio.EventInstance hr;


    private static AudioManager instance;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

	void Start ()
	{
	    MusicBus = FMODUnity.RuntimeManager.GetBus("bus:/General/Music");
	    SFXBus = FMODUnity.RuntimeManager.GetBus("bus:/General/FX");

        menu = FMODUnity.RuntimeManager.CreateInstance(menuTheme);
        africa = FMODUnity.RuntimeManager.CreateInstance(themeAfrica);
        asian = FMODUnity.RuntimeManager.CreateInstance(themeAsian);
        white = FMODUnity.RuntimeManager.CreateInstance(themeWhite);
        arabic = FMODUnity.RuntimeManager.CreateInstance(themeArabic);
        boss = FMODUnity.RuntimeManager.CreateInstance(themeBoss);
        p = FMODUnity.RuntimeManager.CreateInstance(paused);
        lr = FMODUnity.RuntimeManager.CreateInstance(lowReverb);
        mr = FMODUnity.RuntimeManager.CreateInstance(midReverb);
        hr = FMODUnity.RuntimeManager.CreateInstance(highReverb);


    }

    void Update ()
    {
        if(GameManager.instance)
        {
            FMOD.Studio.PLAYBACK_STATE state;
            if (GameManager.instance.getPause())
            {
                p.getPlaybackState(out state);

                if (state == FMOD.Studio.PLAYBACK_STATE.STOPPED)
                {
                    p.start();
                }
            }
            else
            {
                p.getPlaybackState(out state);

                if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
                {
                    p.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
            }

            if(GameManager.instance.getCurrentRoom() && type != GameManager.instance.getCurrentRoom().GetComponent<GamasutraRoom>().heigh * GameManager.instance.getCurrentRoom().GetComponent<GamasutraRoom>().width)
            {
                type = GameManager.instance.getCurrentRoom().GetComponent<GamasutraRoom>().heigh * GameManager.instance.getCurrentRoom().GetComponent<GamasutraRoom>().width;
                if(type == 1)
                {
                    releaseAllReverb();
                    lr.start();
                }
                else if(type == 2)
                {
                    releaseAllReverb();
                    mr.start();
                }
                else if(type == 4)
                {
                    releaseAllReverb();
                    hr.start();
                }
            }
        }

        
    }

    public void LaunchMenuTheme()
    {
        releaseAll();
        menu.start();
    }

    public void LaunchTheme()
    {
        string e = GameManager.instance.getPlayer().getEthnie().ToString();
        releaseAll();
        switch (e)
        {
            case "white":
                white.start();
                break;

            case "asian":
                asian.start();
                break;

            case "black":
                africa.start();
                break;

            case "arab":
                arabic.start();
                break;
        }
    }

    public void LaunchThemeMenu()
    {
        releaseAll();
        menu.start();
    }

    public void LaunchThemeBoss()
    {
        releaseAll();
        boss.start();
    }

    public void releaseAll()
    {
        FMOD.Studio.PLAYBACK_STATE state;

        white.getPlaybackState(out state);

        if ( state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            white.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        asian.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            asian.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        arabic.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            arabic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        africa.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            africa.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        boss.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            boss.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        menu.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            menu.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public void releaseAllReverb()
    {
        FMOD.Studio.PLAYBACK_STATE state;

        lr.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            lr.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        mr.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            mr.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        hr.getPlaybackState(out state);

        if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            hr.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public void changeMusicVolume(float vol)
    {
        MusicBus.setFaderLevel(vol);
    }

    public void changeSFXVolume(float vol)
    {
        SFXBus.setFaderLevel(vol);
    }


}
