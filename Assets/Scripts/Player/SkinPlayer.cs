using UnityEngine;
using System.Collections;

public class SkinPlayer : MonoBehaviour {

    [SerializeField]
    SpriteRenderer leftArm1;
    [SerializeField]
    SpriteRenderer leftArm2;
    [SerializeField]
    SpriteRenderer rightArm1;
    [SerializeField]
    SpriteRenderer rightArm2;
    [SerializeField]
    SpriteRenderer head;
    [SerializeField]
    SpriteRenderer hair;
    [SerializeField]
    SpriteRenderer chest;


    public void changeSkinColor(Color c)
    {
        leftArm1.color = c;
        leftArm2.color = c;
        rightArm1.color = c;
        rightArm2.color = c;
        head.color = c;
    }

    public void changeHair(Sprite s)
    {
        hair.sprite = s;
    }

    public void changeChest(Sprite s)
    {
        chest.sprite = s;
    }

    public void changeHead(Sprite s)
    {
        head.sprite = s;
    }
}
