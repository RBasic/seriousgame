using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorCity : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Player(Clone)").transform.position = new Vector2(transform.position.x - 18.0f, transform.position.y);
            GameManager.instance.getPanelCity().SetActive(true);
        }
    }
}
