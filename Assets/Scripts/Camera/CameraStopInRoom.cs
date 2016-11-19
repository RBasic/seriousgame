using UnityEngine;
using System.Collections;

public class CameraStopInRoom : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        double vertExtent = this.GetComponent<Camera>().orthographicSize;
        double horzExtent = vertExtent * Screen.width / Screen.height;
	    Debug.Log(vertExtent + " " + horzExtent);
        float  mapX = 100.0f;
        float  mapY = 100.0f;
        // Calculations assume map is position at the origin
        double minX = horzExtent - mapX / 2.0;
        double maxX = mapX / 2.0 - horzExtent;
        double minY = vertExtent - mapY / 2.0;
        double maxY = mapY / 2.0 - vertExtent;

        Debug.Log(minX+" "+ maxX+" "+ minY+" "+ maxY);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
