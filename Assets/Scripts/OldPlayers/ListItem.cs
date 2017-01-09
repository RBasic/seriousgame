using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using EnhancedUI;

public class ListItem : ListItemBase 
{
    public Data data { get; private set; }

    public UnityEngine.UI.Text itemBodyText;
    public UnityEngine.UI.Text itemHandicapText;
    public UnityEngine.UI.Text itemGenderText;
    public UnityEngine.UI.Text itemEthnieText;
    public UnityEngine.UI.Text itemSexualityText;

    //public UnityEngine.UI.Image foregroundImage;
    public UnityEngine.UI.Image backgroundImage;
    public Color selectedColor;
    public Color unSelectedColor;
    public GameObject parentPlayerForUI;
    private bool alreadyPlayerForUI = false;

    public GameObject prefabUIPlayer;
    private GameObject playerUIList;

    public override void SetData(object objectData)
    {
        if (!alreadyPlayerForUI)
        {
            playerUIList = Instantiate(prefabUIPlayer);
            playerUIList.transform.SetParent(parentPlayerForUI.transform);

            playerUIList.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            playerUIList.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

            playerUIList.GetComponent<RectTransform>().localScale = new Vector3(0.5f,0.5f,0.5f);

            alreadyPlayerForUI = true;
        }
        base.SetData(objectData);

        data = objectData as Data;
        data.selectedChanged = SelectedChanged;
        //foregroundImage.sprite = data.Sprite;

        itemBodyText.text = data.itemBodyString;
        itemHandicapText.text = data.itemHandicapString;
        itemGenderText.text = data.itemGenderString;
        itemEthnieText.text = data.itemEthnieString;
        itemSexualityText.text = data.itemSexualityString;


        playerUIList.GetComponentInChildren<UIPlayer>().changeUI(data.itemGender, data.itemEthnie, false);
        



        //Sprite sp = Sprite.Create((Texture2D)data.itemTexture, new Rect(0, 0, data.itemTexture.width, data.itemTexture.height), new Vector2(0.5f, 0.5f));
        //foregroundImage.sprite = sp;
        //foregroundImage.color = new Color(1,1,1,1);

        //SelectedChanged(data.Selected);
    }

    private void SelectedChanged(bool selected)
    {
        backgroundImage.color = (data.Selected ? selectedColor : unSelectedColor);
    }
}
