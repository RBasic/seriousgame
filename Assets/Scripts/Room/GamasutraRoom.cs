using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class GamasutraRoom : MonoBehaviour
{

    public int heigh;
    public int width;
    public GameObject go;
    public void check()
    {
        int cpt = 0;
        // if cpt > 0 so there is a room on side
        // small square
        if (heigh == 1 && width==1)
        {
            // center of the element
            Vector3 center = this.GetComponent<Transform>().localPosition;

            float unitX = this.GetComponent<Renderer>().bounds.size.x;
            float unitY = this.GetComponent<Renderer>().bounds.size.y;
            center.x = center.x+unitX/2.0f;
            center.y = center.y-unitY/2.0f;

            // supperpose ?
            Collider2D[] colliders = Physics2D.OverlapPointAll(center);
            if (colliders.Length > 1)
            {
                Debug.Log(this+" "+"supperpose");
                Debug.Log(colliders[0]);
                this.GetComponent<SpriteRenderer>().color=Color.white;
            }

            Vector3 originL = new Vector3(center.x+unitX,center.y,center.z);
            colliders = Physics2D.OverlapPointAll(originL);
            if (colliders.Length > 0) cpt++;
           
            Vector3 originR = new Vector3(center.x - unitX, center.y, center.z);
            colliders = Physics2D.OverlapPointAll(originR);
            if (colliders.Length > 0) cpt++;

            Vector3 originT = new Vector3(center.x , center.y+unitY, center.z);
            colliders = Physics2D.OverlapPointAll(originT);
            if (colliders.Length > 0) cpt++;

            Vector3 originB = new Vector3(center.x , center.y-unitY, center.z);
            colliders = Physics2D.OverlapPointAll(originB);
            if (colliders.Length > 0) cpt++;

            if (cpt == 0)
            {
                this.GetComponent<SpriteRenderer>().color=Color.black;
            }
        }
        // big square
        else if (heigh == 2 && width == 2)
        {
            // center of the element
            Vector3 center = this.GetComponent<Transform>().localPosition;

            float unitX = this.GetComponent<Renderer>().bounds.size.x;
            float unitY = this.GetComponent<Renderer>().bounds.size.y;
            center.x = center.x + unitX / 2.0f;
            center.y = center.y - unitY / 2.0f;

            // supperpose ?
            Collider2D[] colliders = Physics2D.OverlapPointAll(center);
            if (colliders.Length > 1)
            {
                Debug.Log("supperpose");
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }

            Vector3 originL = new Vector3(center.x + unitX, center.y, center.z);
            GameObject g = (GameObject)Instantiate(go, this.transform);
            g.GetComponent<Transform>().localPosition = originL;
            colliders = Physics2D.OverlapPointAll(originL);
            if (colliders.Length > 0) cpt++;

            Vector3 originR = new Vector3(center.x - unitX, center.y, center.z);
            colliders = Physics2D.OverlapPointAll(originR);
            if (colliders.Length > 0) cpt++;

            Vector3 originT = new Vector3(center.x, center.y + unitY, center.z);
            colliders = Physics2D.OverlapPointAll(originT);
            if (colliders.Length > 0) cpt++;

            Vector3 originB = new Vector3(center.x, center.y - unitY, center.z);
            colliders = Physics2D.OverlapPointAll(originB);
            if (colliders.Length > 0) cpt++;

            if (cpt == 0)
            {
                this.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
        // rect H
        if (heigh == 1 && width == 2)
        {

        }
        // rect V
        if (heigh == 2 && width == 1)
        {

        }
    }
}
