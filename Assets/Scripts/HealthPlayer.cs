using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{

    public GameObject origin;
    public GameObject heartPrefab;
    private int lifePoints = 5;
    private GameObject[] hearts;


    // Use this for initialization
    void Start()
    {
        GameManager.instance.getPlayerGameObject();
        resetLifePoints();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loseLifePoint()
    {
        if (lifePoints - 1 > 0)
        {
            Destroy(transform.GetChild(lifePoints).gameObject);
            lifePoints--;
        }

        else
        {
            GameManager.instance.getPlayer().dead();
        }
    }

    public void gainLifePoint(int nb)
    {
        int nbHearts;

        if (lifePoints + nb < 5)
            nbHearts = nb;
        else
            nbHearts = 5 - lifePoints;

        for (int i = 1; i < nbHearts + 1; i++)
        {
            Vector3 pos = origin.transform.position;
            pos.x += lifePoints * 20;
            GameObject go = (GameObject)Instantiate(heartPrefab, pos, origin.transform.rotation);
            go.transform.SetParent(transform);
            lifePoints++;
        }
    }

    public int getLifePoints()
    {
        return lifePoints;
    }

    public void resetLifePoints()
    {
        lifePoints = 5;

        for (int i = 0; i < lifePoints; i++)
        {
            Vector3 pos = origin.transform.position;
            pos.x += i * 20;
            GameObject go = (GameObject)Instantiate(heartPrefab, pos, origin.transform.rotation);
            go.transform.SetParent(transform);
        }
    }
}
