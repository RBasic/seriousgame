using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player : MonoBehaviour{

    public enum ethnie { white, black, asian, arab };
    ethnie e = ethnie.white;
    public enum body { thin, average, fat };
    body b = body.average;
    bool handicap = false;
    bool gender = true;        // H or F
    bool sexuality = true;     // hetero or gay/lesbo
    bool scolarSkill;   // change when see a new teacher (the teacher decide of your skill)

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void dead()
    {

        //writeFile(getEthnieString() , getBodyString(), getHandicapString(), getGenderString(),getSexualityString());
        randomPlayer();
        SceneManager.LoadScene("Description");
        SaveLoad.Load();
    }

    /*
    *@brief : convert int to bool
    *@param int : int to convert to bool
    *@return the boolean of the int
    */
    bool intToBool(int value)
    {
        
        if (value == 0)
            return false;
        else
            return true;
    }

    /*
    *@brief : randomize the player params
    */
    public void randomPlayer()
    {
        int lenght = ethnie.GetNames(typeof(ethnie)).Length;
        int rand = Random.Range(0,lenght);
        e = (ethnie)rand;
        
        lenght = body.GetNames(typeof(body)).Length;
        rand = Random.Range(0, lenght);
        b = (body)rand;

        handicap = intToBool(Random.Range(0, 2));
        gender = intToBool(Random.Range(0, 2));
        sexuality = intToBool(Random.Range(0, 2));
        scolarSkill = intToBool(Random.Range(0, 2));

    }

   
 /*
    *@brief : get the ethnie param
    *@return the ethnie param
    */
    public ethnie getEthnie()
    {
        return e;
    }

    /*
    *@brief : get the body param
    *@return the body param
    */
    public body getBody()
    {
        return b;
    }

    /*
    *@brief : get the handicap param
    *@return the handicap param
    */
    public bool getHandicap()
    {
        return handicap;
    }

    /*
   *@brief : get the sexuality param
   *@return the sexuality param
   */
    public bool getSexuality()
    {
        return sexuality;
    }

    /*
   *@brief : get the gender param
   *@return the gender param
   */
    public bool getGender()
    {
        return gender;
    }

    /*
   *@brief : get the ethnie param string
   *@return the string of the ethnie param
   */
    public string getEthnieString()
    {
        string s = "";
        if (e == ethnie.arab)
            s = "Arabe";
        else if (e == ethnie.asian)
            s = "Asiatique";
        else if (e == ethnie.black)
            if (gender)
                s = "Noir";
            else
                s = "Noire";
        else if (e == ethnie.white)
            if (gender)
                s = "Blanc";
            else
                s = "Blanche";
        return s;
    }

    /*
    *@brief : get the body param string
    *@return the string of the body param
    */
    public string getBodyString()
    {
        string s = "";
        if (b == body.thin)
            s = "Mince";
        else if (b == body.average)
            if (gender)
                s = "Moyen";
            else
                s = "Moyenne";
        else if (b == body.fat)
            if (gender)
                s = "Gros";
            else
                s = "Grosse";
        return s;
    }

    /*
    *@brief : get the handicap param string
    *@return the string of the handicap param
    */
    public string getHandicapString()
    {
        string s = "";
        if (handicap)
            if (gender)
                s = "Handicapé";
            else
                s = "Handicapée";
        else
            s = "Valide";
        return s;

    }

    /*
   *@brief : get the sexuality param string
   *@return the string of the sexuality param
   */
    public string getSexualityString()
    {
        string s = "";
        if (sexuality)
            if (gender)
                s = "Hétérosexuel";
            else
                s = "Hétérosexuelle";
        else
            if (gender)
            s = "Gay";
        else
            s = "Lesbienne";
        return s;
    }

    /*
   *@brief : get the gender param string
   *@return the string of the gender param
   */
    public string getGenderString()
    {
        string s = "";
        if (gender)
            s = "Homme";
        else
            s = "Femme";
        return s;
    }

    /*
  *@brief : write the new player datas
  */
    private void writeFile(string ethnie, string body, string handicap, string gender, string sexuality)
    {
        using (System.IO.StreamWriter file =
          new System.IO.StreamWriter("Assets\\oldPlayers.txt", true))
        {
            file.WriteLine(ethnie+","+body+","+handicap+","+gender+","+sexuality);
        }
    }
}
