using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectionItem : MonoBehaviour
{

    [SerializeField]
    private GameObject selectionSmall;
    [SerializeField]
    private GameObject selectionMedium;
    [SerializeField]
    private GameObject selectionBig;

    [SerializeField]
    private Text textPrice;
    [SerializeField]
    private Text textHeal;

    private GameObject instanceMarchand;

    private Image feedbackSmall;
    private Image feedbackMedium;
    private Image feedbackBig;

    private int smallPrice = 10;
    private int mediumPrice = 25;
    private int bigPrice = 50;

    private int smallHeal = 5;
    private int mediumHeal = 10;
    private int bigHeal = 25;

    // Use this for initialization
    void Start()
    {
        feedbackSmall = selectionSmall.transform.FindChild("Background").GetChild(0).GetComponent<Image>();
        feedbackMedium = selectionMedium.transform.FindChild("Background").GetChild(0).GetComponent<Image>();
        feedbackBig = selectionBig.transform.FindChild("Background").GetChild(0).GetComponent<Image>();

        selectionSmall.transform.FindChild("Image").gameObject.SetActive(false);
        selectionMedium.transform.FindChild("Image").gameObject.SetActive(false);
        selectionBig.transform.FindChild("Image").gameObject.SetActive(false);

        feedbackSmall.enabled = true;
        feedbackMedium.enabled = false;
        feedbackBig.enabled = false;

        textPrice.text = smallPrice.ToString();
        textHeal.text = smallHeal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test update slot shop");
        if (GameManager.instance.getPanelMarchand().activeSelf)
        {
            instanceMarchand = GameManager.instance.getInstanceMarchand();
            Debug.Log(instanceMarchand);
            //Debug.Log(instanceMarchand.GetComponent<Marchand>().getSpriteSmall());
            //selectionSmall.transform.GetComponentInChildren<Image>().sprite = instanceMarchand.GetComponent<Marchand>().getSpriteSmall().sprite;
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (feedbackSmall.enabled)
                {
                    feedbackSmall.enabled = false;
                    feedbackMedium.enabled = true;
                    feedbackBig.enabled = false;

                    textPrice.text = mediumPrice.ToString();
                    textHeal.text = mediumHeal.ToString();
                }

                else if (feedbackMedium.enabled)
                {
                    feedbackSmall.enabled = false;
                    feedbackMedium.enabled = false;
                    feedbackBig.enabled = true;

                    textPrice.text = bigPrice.ToString();
                    textHeal.text = bigHeal.ToString();
                }
            }

            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (feedbackMedium.enabled)
                {
                    feedbackSmall.enabled = true;
                    feedbackMedium.enabled = false;
                    feedbackBig.enabled = false;

                    textPrice.text = smallPrice.ToString();
                    textHeal.text = smallHeal.ToString();
                }

                else if (feedbackBig.enabled)
                {
                    feedbackSmall.enabled = false;
                    feedbackMedium.enabled = true;
                    feedbackBig.enabled = false;

                    textPrice.text = mediumPrice.ToString();
                    textHeal.text = mediumHeal.ToString();
                }
            }

            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (feedbackSmall.enabled && GameManager.instance.getMoney() >= smallPrice)
                    BuyItem(smallPrice, smallHeal);
                else if (feedbackMedium.enabled && GameManager.instance.getMoney() >= mediumPrice)
                    BuyItem(mediumPrice, mediumHeal);
                else if (feedbackBig.enabled && GameManager.instance.getMoney() >= bigPrice)
                    BuyItem(bigPrice, bigHeal);
                    
            }
        }
    }

    void BuyItem(int vPrice, int vHeal)
    {
        Debug.Log("PRIX: " + vPrice);
        GameManager.instance.setMoney(vPrice);
    }
}
