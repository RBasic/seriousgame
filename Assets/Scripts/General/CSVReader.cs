using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class CSVReader : MonoBehaviour
{
    // Dictionnary<nameMob, Dictionnary<namePerso, List dialogues>> 
    Dictionary<string, Dictionary<string,string[]>> menDialogues = new Dictionary<string, Dictionary<string, string[]>>();
    Dictionary<string, Dictionary<string, int>> menPriorities = new Dictionary<string, Dictionary<string, int>>();

    Dictionary<string, Dictionary<string, string[]>> womenDialogues = new Dictionary<string, Dictionary<string, string[]>>();
    Dictionary<string, Dictionary<string, int>> womenPriorities = new Dictionary<string, Dictionary<string, int>>();

    void Start()
    {
        loadCSV();
    }   

    /*
    * @brief : load the csv file to put in in a dico
    */
    public void loadCSV()
    {
		string fileData = (Resources.Load("dialogues") as TextAsset).text;
		Debug.Log ("filedata = " + fileData);
        string[] lines = fileData.Split("\n"[0]);                   // all the line separatly

        /*the first line is the mob name*/
        string[] firstLineData = (lines[0].Trim()).Split(","[0]);   // get all the elements of the line
        for (int j = 1; j < firstLineData.Count(); j = j + 2)       // j=1 because fisrt column is "MEN" and i + 2 because one column on two is priority of the dialog
        {
            menDialogues.Add(firstLineData[j], new Dictionary<string, string[]>());
            menPriorities.Add(firstLineData[j],new Dictionary<string, int>());

            womenDialogues.Add(firstLineData[j], new Dictionary<string, string[]>());
            womenPriorities.Add(firstLineData[j], new Dictionary<string, int>());
        }


        /*other lines*/
        for (int i = 1; i < (lines.Count()/2)+1; i++)                   // i=1 because the first line is already done and /2 because other half are for women
        {
            string[] lineDataMen = (lines[i].Trim()).Split(","[0]);     // get all the elements of the line
            string[] lineDataWomen = (lines[i+ (lines.Count() / 2) ].Trim()).Split(","[0]);    // get all the elements of the line

            string caracPlayerMen = lineDataMen[0];                     // the first element is the carac of the player
            string caracPlayerWomen = lineDataWomen[0];                 // the first element is the carac of the player

            for (int j = 1; j < lineDataMen.Count(); j=j+2)             // i + 2 because one column on two is priority of the dialog
            {
                string[] dialogMen = (lineDataMen[j].Trim()).Split("/"[0]);     // get all the elements of the line                   
                string[] dialogWomen = (lineDataWomen[j].Trim()).Split("/"[0]);     // get all the elements of the line

                menDialogues[firstLineData[j]].Add(caracPlayerMen, dialogMen);
                menPriorities[firstLineData[j]].Add(caracPlayerMen, int.Parse(lineDataMen[j+1]));

                womenDialogues[firstLineData[j]].Add(caracPlayerWomen, dialogWomen);
                womenPriorities[firstLineData[j]].Add(caracPlayerWomen, int.Parse(lineDataMen[j + 1]));
            }       
        }
        
        /*DEBUG*/
        /*
        foreach(string s in menDialogues.Keys)
        {
            foreach(string ss in menDialogues[s].Keys)
            {
               Debug.Log(s+" "+ss+" "+menDialogues[s][ss][0]+" "+menPriorities[s][ss]);
            }
        }
        
        foreach (string s in womenDialogues.Keys)
        {
            foreach (string ss in womenDialogues[s].Keys)
            {
                Debug.Log(s + " " + ss + " " + womenDialogues[s][ss][0]);
            }
        }*/
        

    }

    /*
    * @brief : return the dialog between caracters
    * @param player : the type of the player
    * @param mob : the type of the mob
    * @param player is a woman or a man (man by default)
    * @return the string of the dialog (if several dialog, random)
    */
    public string getDialog(string player, string mob, bool man=true)
    {
        string dialog = "";
        Dictionary<string, string[]> outDictionary = new Dictionary<string, string[]>();    // for th try get value
        string[] listDialog;    // to get the dialog

        if (man)
        {
            menDialogues.TryGetValue(mob, out outDictionary);   
        }
        else
        {
            womenDialogues.TryGetValue(mob, out outDictionary);
        }
        if (outDictionary.Count() != 0)    // if the mob name was correct
        {
            if (outDictionary.TryGetValue(player, out listDialog))
            {
                int random = Random.Range(0, listDialog.Count());
                dialog = listDialog[random];
            }
        }
        return dialog;
    }

    public int getPriority(string player, string mob, bool man = true)
    {
        Dictionary<string, int> outDictionary = new Dictionary<string, int>();    // for th try get value
        int prio = 1;    // to get the dialog

        if (man)
        {
            menPriorities.TryGetValue(mob, out outDictionary);
        }
        else
        {
            womenPriorities.TryGetValue(mob, out outDictionary);
        }
        if (outDictionary.Count() != 0)    // if the mob name was correct
        {
            outDictionary.TryGetValue(player, out prio);
            //Debug.Log("prio = " + prio);
        }
        return prio;
    }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    public static CSVReader instance
    {
        get
        {
            return _instance;
        }
    }
    private static CSVReader _instance;

  
}

