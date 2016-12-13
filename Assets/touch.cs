using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PERTE VIE");
            GameManager.instance.getPanelLife().GetComponent<HealthPlayer>().loseLifePoint();
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
