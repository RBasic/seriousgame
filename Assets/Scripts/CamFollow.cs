using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
    public Transform player;

    // Update is called once per frame
    void Update () {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime*100);
        }
    }
}
