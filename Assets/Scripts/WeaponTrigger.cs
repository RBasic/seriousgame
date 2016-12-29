using UnityEngine;
using System.Collections;

public class WeaponTrigger : MonoBehaviour
{
    public GameObject coin;
    private Animator Anim;
    private string weaponName;

    [FMODUnity.EventRef]

    public string baseballHit = "event:/Serious Game/FX/BaseballBatSwing";
    public string swordHit = "event:/Serious Game/FX/SwordHit";
    public string machetteHit = "event:/Serious Game/FX/MachetteHit";
    public string axeHit = "event:/Serious Game/FX/AxeHit";

    FMOD.Studio.EventInstance baseballBat;
    FMOD.Studio.EventInstance sword;
    FMOD.Studio.EventInstance machette;
    FMOD.Studio.EventInstance axe;

    // Use this for initialization
    void Start()
    {
        Anim = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Animator>();
        baseballBat = FMODUnity.RuntimeManager.CreateInstance(baseballHit);
        sword = FMODUnity.RuntimeManager.CreateInstance(swordHit);
        machette = FMODUnity.RuntimeManager.CreateInstance(machetteHit);
        axe = FMODUnity.RuntimeManager.CreateInstance(axeHit);
    }

    // Update is called once per frame
    void Update()
    {
        weaponName = transform.GetComponent<SpriteRenderer>().sprite.name;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("collide avec " + other);
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("1 : " + other);
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                //sound depending on which weapon is equipped
                if (weaponName == "arme1" || weaponName == "arme4")
                    axe.start();
                else if (weaponName == "arme2")
                    machette.start();
                else if (weaponName == "arme3")
                    sword.start();
                else if (weaponName == "arme5")
                    baseballBat.start();

                Debug.Log("2 : " + other);
                int nb = 10;
                if (!GameManager.instance.getPlayer().getGender())
                {
                    nb -= 2;
                }
                if (GameManager.instance.getPlayer().getEthnie().ToString() == "arab")
                {
                    nb += 2;
                }
                Instantiate(coin, other.transform.position, other.transform.rotation);
                //Destroy(other.gameObject.transform.parent.gameObject);

                Transform[] transforms = other.gameObject.transform.parent.GetComponentsInChildren<Transform>();
                foreach ( Transform t in transforms)
                {
                    if (t.name == "enemyVision")
                    {
                        t.gameObject.GetComponent<DetectingPlayer>().SwapAnimators();
                    }
                }
            }
        }
    }
}
