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

    private GameObject feedbackSmall;
    private GameObject feedbackMedium;
    private GameObject feedbackBig;

    private float smallPrice = 10f;
    private float mediumPrice = 25f;
    private float bigPrice = 50f;

    private float smallHeal = 5f;
    private float mediumHeal = 10f;
    private float bigHeal = 25f;

    // Use this for initialization
    void Start()
    {
        feedbackSmall = selectionSmall.transform.FindChild("Image").gameObject;
        feedbackMedium = selectionMedium.transform.FindChild("Image").gameObject;
        feedbackBig = selectionBig.transform.FindChild("Image").gameObject;

        feedbackSmall.SetActive(true);
        feedbackMedium.SetActive(false);
        feedbackBig.SetActive(false);

        textPrice.text = smallPrice.ToString();
        textHeal.text = smallHeal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test update slot shop");
        if (GameManager.instance.getPanelMarchand().activeSelf)
        {
            Debug.Log("SHOP LIST SALUT");
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("CHOISIR ITEM");
                if (feedbackSmall.activeSelf)
                {
                    feedbackSmall.SetActive(false);
                    feedbackMedium.SetActive(true);
                    feedbackBig.SetActive(false);

                    textPrice.text = mediumPrice.ToString();
                    textHeal.text = mediumHeal.ToString();
                }

                else if (feedbackMedium.activeSelf)
                {
                    feedbackSmall.SetActive(false);
                    feedbackMedium.SetActive(false);
                    feedbackBig.SetActive(true);

                    textPrice.text = bigPrice.ToString();
                    textHeal.text = bigHeal.ToString();
                }
            }

            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (feedbackMedium.activeSelf)
                {
                    Debug.Log("Medium vers droite");
                    feedbackSmall.SetActive(true);
                    feedbackMedium.SetActive(false);
                    feedbackBig.SetActive(false);

                    textPrice.text = smallPrice.ToString();
                    textHeal.text = smallHeal.ToString();
                }

                else if (feedbackBig.activeSelf)
                {
                    Debug.Log("Big vers droite");
                    feedbackSmall.SetActive(false);
                    feedbackMedium.SetActive(true);
                    feedbackBig.SetActive(false);

                    textPrice.text = mediumPrice.ToString();
                    textHeal.text = mediumHeal.ToString();
                }
            }
        }
    }
}
