using UnityEngine;
using System.Collections.Generic;
using EnhancedUI;

public class LoadOldPlayer : MonoBehaviour 
{
    public EnhancedScroller horizontalScroller;
    public UnityEngine.UI.Text horizontalFeedbackText;

    private int currentIndex;
    private int indexMax;
    //string[] linesFile; // the lines of the txt with the old datas

    void Start()
    {
        horizontalScroller.itemSelected = HorizontalItemSelected;
        loadFile();
        
        //LoadData(linesFile.Length);
        LoadData(SaveLoad.savedPlayers.Count);      // load as much as player than datas
        indexMax = SaveLoad.savedPlayers.Count - 1;
        currentIndex = indexMax;
        JumpToIndex(currentIndex); // jump to the last player in hierarchy
    }

    void Update()
    {
        /*
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }*/
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Debug.Log("+");
            if (currentIndex + 1 <= indexMax)
            {
                currentIndex++;
                JumpToIndex(currentIndex);
            }
        }
        else if(Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (currentIndex - 1 >= 0)
            {
                currentIndex--;
                JumpToIndex(currentIndex);
            }
        }
    }
    /*
    * @brief : load all the old datas of the player
    */
    private void LoadData(int itemCount)
    {
        /*
        for (int i = 0; i < itemCount; i++)
        {
            Debug.Log(SaveLoad.savedPlayers[i].getEthnieString());
        }*/
            List<object> data = new List<object>();

        for (int i = 0; i < itemCount; i++)
        {
            //string[] datas = (linesFile[i].Trim()).Split(","[0]);   // get all the datas of the line
            //if (datas.Length == 5) {    // if there are enough data in one raw
            Texture2D tex = new Texture2D(100,100);
            //tex.LoadImage(SaveLoad.savedImages[0]);
            data.Add(new Data()
            {
                itemEthnieString = SaveLoad.savedPlayers[i].getEthnieString(),//datas[0],
                itemBodyString = SaveLoad.savedPlayers[i].getBodyString(),//datas[1],
                itemHandicapString = SaveLoad.savedPlayers[i].getHandicapString(),//datas[2],
                itemGenderString = SaveLoad.savedPlayers[i].getGenderString(),// datas[3],
                itemSexualityString = SaveLoad.savedPlayers[i].getSexualityString(),//datas[4]

                itemEthnie = SaveLoad.savedPlayers[i].getEthnie(),//datas[0],
                itemBody = SaveLoad.savedPlayers[i].getBody(),//datas[1],
                itemHandicap = SaveLoad.savedPlayers[i].getHandicap(),//datas[2],
                itemGender = SaveLoad.savedPlayers[i].getGender(),// datas[3],
                itemSexuality = SaveLoad.savedPlayers[i].getSexuality(),//datas[4]
            });
           }
        

        horizontalScroller.Reload(data, 120f);
    }

    public void JumpToIndex(int index)
    {
        
        horizontalScroller.JumpToIndex(index);
    }

    private void HorizontalItemSelected(ListItemBase listItemBase)
    {
        ListItem listItem = (listItemBase as ListItem);
        /*
        horizontalFeedbackText.text = "Horizontal Item Selected " +
                                        (char)10 + "Item GameObject: " + listItem.gameObject.name +
                                        (char)10 + "Item Index: " + listItem.ItemIndex.ToString() +
                                        (char)10 + "Data Index: " + listItem.DataIndex.ToString();
                                        */
                                
    }

    /*
    *@brief : load the old player datas
    */
    private void loadFile()
    {
        string fileData = System.IO.File.ReadAllText("Assets\\oldPlayers.txt");
        //linesFile = fileData.Split("\n"[0]);                   // all the line separatly
    }


  
}



