using UnityEngine;
using System.Collections;

public class InteractionBuildings : MonoBehaviour {

    [SerializeField]
    Building currentBuilding;

    void Start()
    {
        currentBuilding.setIsSelected(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("left"))
            changeCurrent(currentBuilding.getLeft());

        if (Input.GetKeyDown("right"))
            changeCurrent(currentBuilding.getRight());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentBuilding.setIsBuy(true);
        }
    }

    void changeCurrent(Building newCurrent)
    {
        currentBuilding.setIsSelected(false);
        currentBuilding = newCurrent;
        currentBuilding.setIsSelected(true);

    }
}
