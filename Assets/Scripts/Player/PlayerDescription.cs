using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDescription : MonoBehaviour {
    [Header("Perso")]
    [SerializeField]
    Text genderPerso;
    [SerializeField]
    Text ethniePerso;
    [SerializeField]
    Text handicapPerso;
    [SerializeField]
    Text corpulencePerso;
    [SerializeField]
    Text sexualityPerso;

    [Header("Decription")]
    [SerializeField]
    Text genderDesc;
    [SerializeField]
    Text ethnieDesc;
    [SerializeField]
    Text handicapDesc;
    [SerializeField]
    Text corpulenceDesc;
    [SerializeField]
    Text sexualityDesc;


    void Start()
    {
        Player p = GameManager.instance.getPlayer();
        setPerso(p.getGenderString(), p.getEthnieString(),p.getHandicapString(),p.getBodyString(),p.getSexualityString());
        setBonusMalus(p);
    }
    public void setPerso(string gender, string ethnie, string handicap, string corpulence, string sexuality)
    {
        genderPerso.text = gender;
        ethniePerso.text = ethnie;
        handicapPerso.text = handicap;
        corpulencePerso.text = corpulence;
        sexualityPerso.text = sexuality;
    }

    private void setBonusMalus(Player p)
    {
        setBonnusMalusGender(p.getGender());
        setBonusMalusEthnie(p.getEthnie());
        setBonusMalusCorpulence(p.getBody());
        setBonusMalusSexuality(p.getSexuality());
    }

    private void setBonnusMalusGender(bool man)
    {
        if (man)
        {
            genderDesc.text = "-";
        }
        else
        {
            genderDesc.text = "Gagne 20% d'argent en moins";
        }
    }

    
    private void setBonusMalusEthnie(Player.ethnie e)
    {
        if(e == Player.ethnie.arab)
        {
            ethnieDesc.text  = "Vole 20% d'argent en plus";
        }
        else if(e == Player.ethnie.asian){
            ethnieDesc.text = "Meilleur en Kung Fu (coming soon)";
        }
        else if(e == Player.ethnie.black)
        {
            ethnieDesc.text = "Court plus vite";
        }
        else
        {
            ethnieDesc.text = "-";
        }
    }

    private void setBonusMalusCorpulence(Player.body b)
    {
        if (b == Player.body.thin)
        {
            corpulenceDesc.text = "Saute plus haut";
        }
        else if(b == Player.body.average)
        {
            corpulenceDesc.text = "-";
        }
        else if (b == Player.body.fat)
        {
            corpulenceDesc.text = "Saute moins haut";
        }
    }
        
    private void setBonusMalusSexuality(bool hetero)
    {
        if (hetero)
        {
            sexualityDesc.text = "-";
        }
        else
        {
            sexualityDesc.text = "Coming Soon";
        }
    }
}
