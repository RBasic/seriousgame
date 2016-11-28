using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorCity : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("city");
        }
    }
}
