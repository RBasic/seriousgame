using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public GameObject lifeGrid;
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
            Debug.Log(lifeGrid.GetComponent<Transform>().childCount+" "+lifePoints);
            Destroy(lifeGrid.transform.GetChild(lifePoints-1).gameObject);
            lifePoints--;
        }

        else
        {
            Destroy(lifeGrid.transform.GetChild(lifePoints - 1).gameObject);
            lifePoints--;
            GameManager.instance.getPlayer().dead();
            GameManager.instance.getPanelLife().GetComponent<HealthPlayer>().gainLifePoint(5);
            GameManager.instance.getPanelLife().SetActive(false);
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
            GameObject newHeart = (GameObject)Instantiate(heartPrefab);
            newHeart.transform.SetParent(lifeGrid.transform);
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
            GameObject newHeart = (GameObject)Instantiate(heartPrefab);
            newHeart.transform.SetParent(lifeGrid.transform);
        }
    }
}
