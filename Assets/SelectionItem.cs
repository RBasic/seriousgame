using UnityEngine;
using System.Collections;

public class SelectionItem : MonoBehaviour
{

    [SerializeField]
    private GameObject selectionSmall;
    [SerializeField]
    private GameObject selectionMedium;
    [SerializeField]
    private GameObject selectionBig;

    private GameObject feedbackSmall;
    private GameObject feedbackMedium;
    private GameObject feedbackBig;

    // Use this for initialization
    void Start()
    {
        feedbackSmall = selectionSmall.transform.FindChild("Image").gameObject;
        feedbackMedium = selectionMedium.transform.FindChild("Image").gameObject;
        feedbackBig = selectionBig.transform.FindChild("Image").gameObject;

        feedbackSmall.SetActive(true);
        feedbackMedium.SetActive(false);
        feedbackBig.SetActive(false);
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
                }

                else if (feedbackMedium.activeSelf)
                {
                    feedbackSmall.SetActive(false);
                    feedbackMedium.SetActive(false);
                    feedbackBig.SetActive(true);
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
                }

                else if (feedbackBig.activeSelf)
                {
                    Debug.Log("Big vers droite");
                    feedbackSmall.SetActive(false);
                    feedbackMedium.SetActive(true);
                    feedbackBig.SetActive(false);
                }
            }
        }
    }
}
