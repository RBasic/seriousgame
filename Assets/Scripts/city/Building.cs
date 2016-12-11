using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Building : MonoBehaviour {

    [SerializeField]
    Building left;
    [SerializeField]
    Building right;
    [SerializeField]
    Building up;
    [SerializeField]
    Building down;

    bool isBuy = false;
    bool isSelected;

    public void setIsBuy(bool state)
    {
        isBuy = state;
        changeOpacity(state);
    }

    void changeOpacity(bool state)
    {
        Color c = GetComponent<Image>().color;
        if (state)
            c.a = 1.0f;
        else
            c.a = 0.0f;
        GetComponent<Image>().color = c;
    }

    public void setIsSelected(bool state)
    {
        isSelected = state;
        // si selected and no buy : flashing
        if (state && !isBuy)
            StartCoroutine(flashing());
        // si selected et buy : rien
        // si pas selected et buy : rien
        // si pas selectd et pas buy : eteindre
        else if (!isSelected && !isBuy)
        {
            StopCoroutine(flashing());
            changeOpacity(false);
        }
        
    }

    IEnumerator flashing()
    {
        bool state = true;
        while (isSelected)
        {
            changeOpacity(state);
            yield return new WaitForSeconds(0.5f);
            state = !state;
        }
    }

    public Building getLeft()
    {
        return left;
    }

    public Building getRight()
    {
        return right;
    }
}
