using UnityEngine;
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

    public UnityEngine.UI.Image foregroundImage;
    public UnityEngine.UI.Image backgroundImage;
    public Color selectedColor;
    public Color unSelectedColor;

    public override void SetData(object objectData)
    {
        base.SetData(objectData);

        data = objectData as Data;
        data.selectedChanged = SelectedChanged;
        foregroundImage.sprite = data.Sprite;

        itemBodyText.text = data.itemBody;
        itemHandicapText.text = data.itemHandicap;
        itemGenderText.text = data.itemGender;
        itemEthnieText.text = data.itemEthnie;
        itemSexualityText.text = data.itemSexuality;
        Sprite sp = Sprite.Create((Texture2D)data.itemTexture, new Rect(0, 0, data.itemTexture.width, data.itemTexture.height), new Vector2(0.5f, 0.5f));
        foregroundImage.sprite = sp;
        foregroundImage.color = new Color(1,1,1,1);

        //SelectedChanged(data.Selected);
    }

    private void SelectedChanged(bool selected)
    {
        backgroundImage.color = (data.Selected ? selectedColor : unSelectedColor);
    }
}
