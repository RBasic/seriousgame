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
    [SerializeField]
    string textIsBuy;
    [SerializeField]
    string textJustBuying;
    [SerializeField]
    string textIsSelectedBeforeMoney;
    [SerializeField]
    int cost;
    [SerializeField]
    string textIsSelectedAfterMoney;


    bool isBuy = false;
    bool isSelected;

    public void setIsBuy(bool state)
    {
        isBuy = state;
        changeOpacity(state);
    }

    public void changeOpacityNoSeleted()
    {
        Color c = GetComponent<Image>().color;
        if (isBuy)
        {
            c.a -= 0.2f;
        }
        else
        {
            c.a= 0.0f;
        }
        GetComponent<Image>().color = c;
    }

    public void changeOpacitySelected()
    {
        if (!isBuy)
        {
            StartCoroutine(flashing());
        }
        else
        {
            StopCoroutine(flashing());
            changeOpacity(true);
        }
    }

    public void setIsSelected(bool state)
    {
        isSelected = state;
     
    }

    IEnumerator flashing()
    {
        bool state = true;
        while (isSelected && !isBuy)
        {
            changeOpacity(state);
            yield return new WaitForSeconds(0.5f);
            state = !state;
        }
    }

    void changeOpacity(bool state)
    {
        Color c = GetComponent<Image>().color;
        if (state)
        {
            c.a = 1.0f;
        }
        else
        {
            c.a = 0.0f;
        }
        GetComponent<Image>().color = c;
    }
    public Building getLeft()
    {
        return left;
    }

    public Building getRight()
    {
        return right;
    }

    public string getText()
    {
        string s = "";
        if (isBuy)
        {
            s += textIsBuy;
        }
        else
        {
            s += textIsSelectedBeforeMoney;
            s += " ";
            s += cost.ToString();
            s += " ";
            s += textIsSelectedAfterMoney;
        }
        return s;
    }

    public string getTextJustBuying()
    {
        string s = "";
        s += textJustBuying;
        return s;
    }

    public bool getIsBuy()
    {
        return isBuy;
    }
}
