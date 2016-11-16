using UnityEngine;
using System.Collections.Generic;

public class CreateMiniMap : MonoBehaviour
{
    [SerializeField] private Sprite small;
    [SerializeField]
    private Sprite big;
    [SerializeField]
    private Sprite rectV;
    [SerializeField]
    private Sprite rectH;


    public void create(List<Vector2> miniMapSmall, List<Vector2> miniMapBig, List<Vector2> miniMapRectV, List<Vector2> miniMapRectH)
    {
        /*
        for (int i = 0; i < miniMapSmall.Count; i++)
        {
            GameObject sr = new GameObject("small " + i);
            sr.GetComponent<Transform>().SetParent(this.transform);
            sr.AddComponent<SpriteRenderer>();
            sr.GetComponent<SpriteRenderer>().sprite = small;
            sr.GetComponent<Transform>().position = miniMapBig[i];
        }
        for (int i = 0; i < miniMapBig.Count; i++)
        {
            GameObject sr = new GameObject("big "+i);
            sr.GetComponent<Transform>().SetParent(this.transform);
            sr.AddComponent<SpriteRenderer>();
            sr.GetComponent<SpriteRenderer>().sprite = big;
            sr.GetComponent<Transform>().position = miniMapBig[i];
        }
        for (int i = 0; i < miniMapRectV.Count; i++)
        {
            GameObject sr = new GameObject("rectV "+i);
            sr.GetComponent<Transform>().SetParent(this.transform);
            sr.AddComponent<SpriteRenderer>();
            sr.GetComponent<SpriteRenderer>().sprite = rectV;
            sr.GetComponent<Transform>().position = miniMapRectV[i];
        }
        for (int i = 0; i < miniMapRectH.Count; i++)
        {
            GameObject sr = new GameObject("recth "+i);
            sr.GetComponent<Transform>().SetParent(this.transform);
            sr.AddComponent<SpriteRenderer>();
            sr.GetComponent<SpriteRenderer>().sprite = rectH;
            sr.GetComponent<Transform>().position = miniMapRectH[i];
        }
        */
    }
}
