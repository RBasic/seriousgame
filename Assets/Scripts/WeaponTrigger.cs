using UnityEngine;
using System.Collections;

public class WeaponTrigger : MonoBehaviour
{

    public GameObject coin;
    private Animator Anim;
    // Use this for initialization
    void Start()
    {
        Anim = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            int nb = 10;
            if (!GameManager.instance.getPlayer().getGender())
            {
                nb = 8;
            }
            else if (GameManager.instance.getPlayer().getEthnie().ToString() == "arab")
            {
                nb = 12;
            }
            Instantiate(coin, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
