using UnityEngine;
using System.Collections;

public class ScreenShots : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
    }

    public static ScreenShots instance
    {
        get
        {
            return _instance;
        }
    }
    private static ScreenShots _instance;


    public int resWidth = 2550;
    public int resHeight = 3300;
    Rect imageRect;

    private bool takeHiResShot = false;
    int count = 0;
    public void TakeHiResShot(RectTransform rect)
    {
            StartCoroutine(ScreenshotEncode(rect));

    }

    IEnumerator ScreenshotEncode(RectTransform r)
    {
        // wait for graphics to render
        yield return new WaitForEndOfFrame();

        // create a texture to pass to encoding
        Texture2D texture = new Texture2D((int)r.rect.width, (int)r.rect.height, TextureFormat.RGB24, false);

        // put buffer into texture
        float i = Screen.width / 2;
        float j = Screen.height / 2;
        texture.ReadPixels(new Rect(i+r.rect.x/2,j+r.rect.y/2 , (int)r.rect.width, (int)r.rect.height), 0, 0);
        texture.Apply();
        
        // split the process up--ReadPixels() and the GetPixels() call inside of the encoder are both pretty heavy
        yield return 0;

        byte[] bytes = texture.EncodeToPNG();
        SaveLoad.SaveImage(bytes);
        // save our test image (could also upload to WWW)

        //System.IO.File.WriteAllBytes("Assets\\ScreenShots\\"+ count + ".png", bytes);
        //count++;
        // Added by Karl. - Tell unity to delete the texture, by default it seems to keep hold of it and memory crashes will occur after too many screenshots.
        DestroyObject(texture);

        //Debug.Log( Application.dataPath + "/../testscreen-" + count + ".png" );
    }

}
