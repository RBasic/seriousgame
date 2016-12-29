using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectingPlayer : MonoBehaviour
{
    public bool once = false;
    GameObject enemy;
    TextMesh textShowed;
    List<string> dialogues = new List<string>();
	// Use this for initialization
	void Start ()
    {
	    enemy = gameObject.transform.parent.gameObject;
        textShowed = enemy.GetComponentInChildren<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        if((enemy.transform.localScale.x < 0)&&(textShowed.transform.localScale.x > 0)){
            Vector3 temp = textShowed.transform.localScale;
            temp.x *= -1;
            textShowed.transform.localScale = temp;
        }
        if ((enemy.transform.localScale.x > 0) && (textShowed.transform.localScale.x < 0))
        {
            Vector3 temp = textShowed.transform.localScale;
            temp.x *= -1;
            textShowed.transform.localScale = temp;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!once && enemy.transform.FindChild("body").gameObject.activeInHierarchy == true)
            {
                dialogues.Clear();
                Player p = GameManager.instance.getPlayer();
                if (CSVReader.instance.getPriority(p.getEthnieString(), "boss", p.getGender()) == 1)
                {
                    //Debug.Log(CSVReader.instance.getDialog(p.getEthnieString(), "boss", p.getGender()));
                    dialogues.Add(CSVReader.instance.getDialog(p.getEthnieString(), "boss", p.getGender()));
                }
                if (CSVReader.instance.getPriority(p.getSexualityString(), "boss", p.getGender()) == 1)
                {
                    // Debug.Log(CSVReader.instance.getDialog(p.getSexualityString(), "boss", p.getGender()));
                    dialogues.Add(CSVReader.instance.getDialog(p.getSexualityString(), "boss", p.getGender()));
                }
                if (CSVReader.instance.getPriority(p.getHandicapString(), "boss", p.getGender()) == 1)
                {
                    //Debug.Log(CSVReader.instance.getDialog(p.getHandicapString(), "boss", p.getGender()));
                    dialogues.Add(CSVReader.instance.getDialog(p.getHandicapString(), "boss", p.getGender()));
                }
                if (CSVReader.instance.getPriority(p.getBodyString(), "boss", p.getGender()) == 1)
                {
                    //Debug.Log(CSVReader.instance.getDialog(p.getBodyString(), "boss", p.getGender()));
                    dialogues.Add(CSVReader.instance.getDialog(p.getBodyString(), "boss", p.getGender()));
                }
                if (dialogues.Count != 0)
                {
                    SwapAnimators();
                }
                else
                {
                    dialogues.Add(CSVReader.instance.getDialog(p.getEthnieString(), "boss", p.getGender()));
                }
                int rand = Random.Range(0, dialogues.Count);
                //Debug.Log("je dis = " + dialogues[rand]);
                textShowed.text = dialogues[rand];
                once = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.GetComponent<EnemyPathing>().startSpeedBoostCoroutine();
            //enemy.GetComponent<EnemyPathing>().setChasingPlayer(false);
        }
    }

    public void displayPositiveDialogue()
    {
        dialogues.Clear();
        int rand = Random.Range(0, dialogues.Count);
        dialogues.Add(CSVReader.instance.getDialog("Blanc", "boss", true));
        textShowed.text = dialogues[rand];
        //dialogue positif        
    }

    public void SwapAnimators()
    {
        enemy.transform.FindChild("body").gameObject.SetActive(!enemy.transform.FindChild("body").gameObject.activeInHierarchy);
        enemy.transform.FindChild("bodyT").gameObject.SetActive(!enemy.transform.FindChild("bodyT").gameObject.activeInHierarchy);
        enemy.GetComponent<EnemyPathing>().setChasingPlayer(enemy.GetComponent<EnemyPathing>().getChasingPlayer());
        enemy.GetComponent<EnemyPathing>().setPathing(!enemy.GetComponent<EnemyPathing>().getPathing());
    }
}
