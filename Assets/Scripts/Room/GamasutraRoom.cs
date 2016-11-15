using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class GamasutraRoom : MonoBehaviour
{

    public int heigh;
    public int width;
    [SerializeField] BoxCollider2D colliderSupperpose;
    private int x = 18;
    private int y = 10;

    Collider2D[] colliders;


    public BoxCollider2D getColliderSupperpose()
    {
        return colliderSupperpose;
    }

    public void check()
    {
        checkSupperpose();
        checkSides();
    }

    public void checkSupperpose()
    {
        // center of the element
        Vector3 center = this.GetComponent<Transform>().localPosition;
        colliders = Physics2D.OverlapPointAll(center);
        if (colliders.Length > 1)
        {
            for (int i = 1; i < colliders.Length; i++)
            {
                Debug.Log(this + " " + "delete because of superposition");
                Destroy(colliders[i].GetComponent<GameObject>());
            }
        }
    
    }

    public void checkSides()
    {
        // center of the element
        Vector3 center = this.GetComponent<Transform>().localPosition;

        int cpt = 0;
        // if cpt > 0 so there is a room on side

        // small square
        if (heigh == 1 && width==1)
        {
            
            Vector3 originL = new Vector3(center.x+(x),center.y,center.z);
            colliders = Physics2D.OverlapPointAll(originL);
            if (colliders.Length > 0) cpt++;

            Vector3 originR = new Vector3(center.x - (x), center.y, center.z);
            colliders = Physics2D.OverlapPointAll(originR);
            if (colliders.Length > 0) cpt++;

            Vector3 originT = new Vector3(center.x , center.y+(y), center.z);
            colliders = Physics2D.OverlapPointAll(originT);
            if (colliders.Length > 0) cpt++;

            Vector3 originB = new Vector3(center.x , center.y-(y), center.z);
            colliders = Physics2D.OverlapPointAll(originB);
            if (colliders.Length > 0) cpt++;

        }
        // big square
        else if (heigh == 2 && width == 2)
        {

            //Top Left
            Vector3 originTL = new Vector3(center.x - (x/2), center.y+(y)+(y/2), center.z);
            colliders = Physics2D.OverlapPointAll(originTL);
            if (colliders.Length > 0) cpt++;

            //Top Right
            Vector3 originTR = new Vector3(center.x + (x / 2), center.y + (y) + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originTR);
            if (colliders.Length > 0) cpt++;

            //Right Top
            Vector3 originRT = new Vector3(center.x + x+(x / 2), center.y + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originRT);
            if (colliders.Length > 0) cpt++;

            //Right Bottom
            Vector3 originRB = new Vector3(center.x + x + (x / 2), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originRB);
            if (colliders.Length > 0) cpt++;

            //Bottom Right
            Vector3 originBR = new Vector3(center.x + (x / 2), center.y - (y) - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originBR);
            if (colliders.Length > 0) cpt++;

            //Bottom Left
            Vector3 originBL = new Vector3(center.x - (x / 2), center.y - (y) - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originBL);
            if (colliders.Length > 0) cpt++;

            //Left Bottom
            Vector3 originLB = new Vector3(center.x - x - (x / 2), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLB);
            if (colliders.Length > 0) cpt++;

            //Left Top
            Vector3 originLT = new Vector3(center.x - x - (x / 2), center.y + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLT);
            if (colliders.Length > 0) cpt++;

        }
        // rect H
        if (heigh == 1 && width == 2)
        {
            //Top Left
            Vector3 originTL = new Vector3(center.x - (x / 2), center.y + (y), center.z);
            colliders = Physics2D.OverlapPointAll(originTL);
            if (colliders.Length > 0) cpt++;

            //Top Right
            Vector3 originTR = new Vector3(center.x + (x / 2), center.y + (y) , center.z);
            colliders = Physics2D.OverlapPointAll(originTR);
            if (colliders.Length > 0) cpt++;

            //Right
            Vector3 originR = new Vector3(center.x + x + (x / 2), center.y, center.z);
            colliders = Physics2D.OverlapPointAll(originR);
            if (colliders.Length > 0) cpt++;

            //Bottom Right
            Vector3 originBR = new Vector3(center.x + (x / 2), center.y - (y), center.z);
            colliders = Physics2D.OverlapPointAll(originBR);
            if (colliders.Length > 0) cpt++;

            //Bottom Left
            Vector3 originBL = new Vector3(center.x - (x / 2), center.y - (y) , center.z);
            colliders = Physics2D.OverlapPointAll(originBL);
            if (colliders.Length > 0) cpt++;

            //Left
            Vector3 originL = new Vector3(center.x - x - (x / 2), center.y , center.z);
            colliders = Physics2D.OverlapPointAll(originL);
            if (colliders.Length > 0) cpt++;

        }
       // rect V
        if (heigh == 2 && width == 1)
        {
            //Top
            Vector3 originT = new Vector3(center.x , center.y + (y) + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originT);
            if (colliders.Length > 0) cpt++;

            //Right Top
            Vector3 originRT = new Vector3(center.x  + (x ), center.y + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originRT);
            if (colliders.Length > 0) cpt++;

            //Right Bottom
            Vector3 originRB = new Vector3(center.x + (x ), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originRB);
            if (colliders.Length > 0) cpt++;

            //Bottom
            Vector3 originB = new Vector3(center.x, center.y -(y) - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originB);
            if (colliders.Length > 0) cpt++;

            //Left Bottom
            Vector3 originLB = new Vector3(center.x  - (x ), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLB);
            if (colliders.Length > 0) cpt++;

            //Left Top
            Vector3 originLT = new Vector3(center.x  - (x ), center.y + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLT);
            if (colliders.Length > 0) cpt++;

        }

        if (cpt == 0)
        {
            Debug.Log(this + " " + "delete because of alone");
            Destroy(this.GetComponent<GameObject>());
        }
    }

    

    public Vector2 getXY()
    {
        return new Vector2(x*width,y*heigh);
    }
}
