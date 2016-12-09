using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour {

    [FMODUnity.EventRef]

    public string menuTheme = "event:/Serious Game/Music/Menu";
    public string themeWhite = "event:/Serious Game/Music/ThemeWhite";
    public string themeAsian = "event:/Serious Game/Music/ThemeAsian";
    public string themeAfrica = "event:/Serious Game/Music/ThemeAfrica";
    public string themeArabic = "event:/Serious Game/Music/ThemeArabic";
    public string themeBoss = "event:/Serious Game/Music/Boss";

    FMOD.Studio.EventInstance menu;
    FMOD.Studio.EventInstance white;
    FMOD.Studio.EventInstance arabic;
    FMOD.Studio.EventInstance africa;
    FMOD.Studio.EventInstance asian;
    FMOD.Studio.EventInstance boss;

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
        menu = FMODUnity.RuntimeManager.CreateInstance(menuTheme);
        africa = FMODUnity.RuntimeManager.CreateInstance(themeAfrica);
        asian = FMODUnity.RuntimeManager.CreateInstance(themeAsian);
        white = FMODUnity.RuntimeManager.CreateInstance(themeWhite);
        arabic = FMODUnity.RuntimeManager.CreateInstance(themeArabic);
        boss = FMODUnity.RuntimeManager.CreateInstance(themeBoss);

	}
	
	void Update ()
    {

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
}
