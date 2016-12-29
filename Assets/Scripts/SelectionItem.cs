using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectionItem : MonoBehaviour
{
    [FMODUnity.EventRef]

    public string eating = "event:/Serious Game/FX/Eating";
    public string thanks = "event:/Serious Game/FX/Thanks";

    FMOD.Studio.EventInstance e;
    FMOD.Studio.EventInstance t;


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

    private int smallPrice = 15;
    private int mediumPrice = 25;
    private int bigPrice = 35;

    private int smallHeal = 1;
    private int mediumHeal = 2;
    private int bigHeal = 3;

    // Use this for initialization
    void Start()
    {
        feedbackSmall = selectionSmall.transform.FindChild("Background").GetChild(0).GetComponent<Image>();
        feedbackMedium = selectionMedium.transform.FindChild("Background").GetChild(0).GetComponent<Image>();
        feedbackBig = selectionBig.transform.FindChild("Background").GetChild(0).GetComponent<Image>();

        //selectionSmall.transform.FindChild("Image").gameObject.SetActive(false);
        //selectionMedium.transform.FindChild("Image").gameObject.SetActive(false);
        //selectionBig.transform.FindChild("Image").gameObject.SetActive(false);

        feedbackSmall.enabled = true;
        feedbackMedium.enabled = false;
        feedbackBig.enabled = false;

        textPrice.text = smallPrice.ToString();
        textHeal.text = smallHeal.ToString();

        e = FMODUnity.RuntimeManager.CreateInstance(eating);
        t = FMODUnity.RuntimeManager.CreateInstance(thanks);

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
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                GameManager.instance.getAudioManager().selectsound.start();
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

                else
                {
                    feedbackSmall.enabled = true;
                    feedbackMedium.enabled = false;
                    feedbackBig.enabled = false;

                    textPrice.text = smallPrice.ToString();
                    textHeal.text = smallHeal.ToString();

                }
            }

            else if (Input.GetKeyDown(KeyCode.Z))
            {
                GameManager.instance.getAudioManager().selectsound.start();
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

                else
                {
                    feedbackSmall.enabled = false;
                    feedbackMedium.enabled = false;
                    feedbackBig.enabled = true;

                    textPrice.text = bigPrice.ToString();
                    textHeal.text = bigHeal.ToString();

                }
            }

            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (feedbackSmall.enabled && GameManager.instance.getMoney() >= smallPrice && GameManager.instance.getPanelLife().GetComponent<HealthPlayer>().getLifePoints() < 5)
                    BuyItem(smallPrice, smallHeal);
                else if (feedbackMedium.enabled && GameManager.instance.getMoney() >= mediumPrice && GameManager.instance.getPanelLife().GetComponent<HealthPlayer>().getLifePoints() < 5)
                    BuyItem(mediumPrice, mediumHeal);
                else if (feedbackBig.enabled && GameManager.instance.getMoney() >= bigPrice && GameManager.instance.getPanelLife().GetComponent<HealthPlayer>().getLifePoints() < 5)
                    BuyItem(bigPrice, bigHeal);
                else
                    GameManager.instance.getAudioManager().nomoneysound.start();
            }
        }
    }

    void BuyItem(int vPrice, int vHeal)
    {
        Eating();
        GameManager.instance.setMoney(vPrice);
        GameManager.instance.getPanelLife().GetComponent<HealthPlayer>().gainLifePoint(vHeal);
        Thanks();
    }

    public void Eating()
    {
        e.start();
    }

    public void Thanks()
    {
        t.start();
    }
}
