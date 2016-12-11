using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionBuildings : MonoBehaviour {

    [SerializeField]
    Building currentBuilding;
    [SerializeField]
    Text textDisplay;
    bool buttonDown = true;

    void Start()
    {
        currentBuilding.setIsSelected(true);
        currentBuilding.changeOpacitySelected();
        changeText();
    }

    void Update()
    {
        /*
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                Debug.Log(vKey);
            }
        }
        */
        float move = Input.GetAxis("DpadHorizontal");
        if (!buttonDown && (move == -1 || Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            changeCurrent(currentBuilding.getLeft());
            buttonDown = true;
        }

        else if (!buttonDown && (move == 1 || Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            changeCurrent(currentBuilding.getRight());
            buttonDown = true;
        }

        else if (buttonDown && move ==0)
        {
            buttonDown = false;
        }

        else if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Space))
        {
            if (!currentBuilding.getIsBuy())
            {
                currentBuilding.setIsBuy(true);
                textDisplay.text = currentBuilding.getTextJustBuying();
            }
        }

    }

    void changeCurrent(Building newCurrent)
    {
       
        currentBuilding.setIsSelected(false);
        currentBuilding.changeOpacityNoSeleted();
        currentBuilding = newCurrent;
        currentBuilding.setIsSelected(true);
        currentBuilding.changeOpacitySelected();
        changeText();

    }

    void changeText()
    {
        textDisplay.text = currentBuilding.getText();
    }
}