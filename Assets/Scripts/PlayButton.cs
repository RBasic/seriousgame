using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    void onClick()
    {
        SceneManager.LoadScene("TestCam");
    }
}
