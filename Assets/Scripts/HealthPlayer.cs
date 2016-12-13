using UnityEngine;
using System.Collections;

public class HealthPlayer : MonoBehaviour {

    public GameObject origin;
    public GameObject heartPrefab;
    private int lifePoints = 5;
    private GameObject[] hearts;


	// Use this for initialization
	void Start ()
    {
        GameManager.instance.getPlayerGameObject();
        lifePoints = 5;

        for(int i =0; i<lifePoints;i++)
        {
            Vector3 pos = origin.transform.position;
            pos.x += i * 20;
            GameObject go = (GameObject)Instantiate(heartPrefab, pos, origin.transform.rotation);
            go.transform.SetParent(transform);
        }

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void looseLifePoint()
    {
        if(lifePoints>0)
        {
            Destroy(transform.GetChild(lifePoints).gameObject);
            lifePoints--;
        }
        else
        {
            Debug.Log("Bah c'est grillé ! ");
        }


    }

    public void gainLifePoint()
    {
        if (lifePoints < 5)
        {
            Vector3 pos = origin.transform.position;
            pos.x += lifePoints * 20;
            GameObject go = (GameObject)Instantiate(heartPrefab, pos, origin.transform.rotation);
            go.transform.SetParent(transform);

            lifePoints++;
        }
        
    }
}
