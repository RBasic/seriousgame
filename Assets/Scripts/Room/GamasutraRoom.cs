using UnityEngine;
using System.Collections.Generic;

public class GamasutraRoom : MonoBehaviour
{

    public int heigh;
    public int width;
    [SerializeField] BoxCollider2D colliderSupperpose;
    private int x = 18;
    private int y = 10;

    // doors to shown or not if the elements are next
    [Header("Doors simple wall")]
    public GameObject doorL;
    public GameObject doorR;
    public GameObject doorT;
    public GameObject doorB;

    [Header("Doors double wall")]
    public GameObject doorLT;
    public GameObject doorLB;
    public GameObject doorRT;
    public GameObject doorRB;
    public GameObject DoorTL;
    public GameObject doorTR;
    public GameObject doorBL;
    public GameObject doorBR;


    Collider2D[] colliders;

    public BoxCollider2D getColliderSupperpose()
    {
        return colliderSupperpose;
    }

    public void check(List<GameObject> lvlRooms)
    {
        checkSupperpose(lvlRooms);
        checkSides(lvlRooms);
    }

    public void checkSupperpose(List<GameObject> lvlRooms)
    {
        // center of the element
        Vector3 center = this.GetComponent<Transform>().localPosition;
        colliders = Physics2D.OverlapPointAll(center);
        if (colliders.Length > 1)
        {
            for (int i = 1; i < colliders.Length; i++)
            {
                Debug.Log(this + " " + "delete because of superposition");
                lvlRooms.Remove(colliders[i].gameObject);
                Destroy(colliders[i].gameObject);
            }
        }
    
    }

    public void checkSides(List<GameObject> lvlRooms)
    {
        // center of the element
        Vector3 center = this.GetComponent<Transform>().localPosition;

        // the room is okay if : 
        // has at least one door
        // touch 2 room
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
            lvlRooms.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void getAttainable(List<GameObject> roomsBefore , List<GameObject> roomAfter )
    {

        if (roomsBefore.Contains(this.gameObject))
        {
            roomsBefore.Remove(this.gameObject);
            roomAfter.Add(this.gameObject);

            // center of the element
            Vector3 center = this.GetComponent<Transform>().localPosition;

            // small square
            if (heigh == 1 && width == 1)
            {

                Vector3 originL = new Vector3(center.x + (x), center.y, center.z);
                colliders = Physics2D.OverlapPointAll(originL);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                Vector3 originR = new Vector3(center.x - (x), center.y, center.z);
                colliders = Physics2D.OverlapPointAll(originR);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                Vector3 originT = new Vector3(center.x, center.y + (y), center.z);
                colliders = Physics2D.OverlapPointAll(originT);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                Vector3 originB = new Vector3(center.x, center.y - (y), center.z);
                colliders = Physics2D.OverlapPointAll(originB);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

            }
            // big square
            else if (heigh == 2 && width == 2)
            {

                //Top Left
                Vector3 originTL = new Vector3(center.x - (x/2), center.y + (y) + (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originTL);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Top Right
                Vector3 originTR = new Vector3(center.x + (x/2), center.y + (y) + (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originTR);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Right Top
                Vector3 originRT = new Vector3(center.x + x + (x/2), center.y + (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originRT);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Right Bottom
                Vector3 originRB = new Vector3(center.x + x + (x/2), center.y - (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originRB);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Bottom Right
                Vector3 originBR = new Vector3(center.x + (x/2), center.y - (y) - (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originBR);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Bottom Left
                Vector3 originBL = new Vector3(center.x - (x/2), center.y - (y) - (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originBL);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Left Bottom
                Vector3 originLB = new Vector3(center.x - x - (x/2), center.y - (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originLB);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Left Top
                Vector3 originLT = new Vector3(center.x - x - (x/2), center.y + (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originLT);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

            }
            // rect H
            if (heigh == 1 && width == 2)
            {
                //Top Left
                Vector3 originTL = new Vector3(center.x - (x/2), center.y + (y), center.z);
                colliders = Physics2D.OverlapPointAll(originTL);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Top Right
                Vector3 originTR = new Vector3(center.x + (x/2), center.y + (y), center.z);
                colliders = Physics2D.OverlapPointAll(originTR);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Right
                Vector3 originR = new Vector3(center.x + x + (x/2), center.y, center.z);
                colliders = Physics2D.OverlapPointAll(originR);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Bottom Right
                Vector3 originBR = new Vector3(center.x + (x/2), center.y - (y), center.z);
                colliders = Physics2D.OverlapPointAll(originBR);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Bottom Left
                Vector3 originBL = new Vector3(center.x - (x/2), center.y - (y), center.z);
                colliders = Physics2D.OverlapPointAll(originBL);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Left
                Vector3 originL = new Vector3(center.x - x - (x/2), center.y, center.z);
                colliders = Physics2D.OverlapPointAll(originL);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

            }
            // rect V
            if (heigh == 2 && width == 1)
            {
                //Top
                Vector3 originT = new Vector3(center.x, center.y + (y) + (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originT);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Right Top
                Vector3 originRT = new Vector3(center.x + (x), center.y + (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originRT);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Right Bottom
                Vector3 originRB = new Vector3(center.x + (x), center.y - (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originRB);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Bottom
                Vector3 originB = new Vector3(center.x, center.y - (y) - (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originB);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Left Bottom
                Vector3 originLB = new Vector3(center.x - (x), center.y - (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originLB);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

                //Left Top
                Vector3 originLT = new Vector3(center.x - (x), center.y + (y/2), center.z);
                colliders = Physics2D.OverlapPointAll(originLT);
                if (colliders.Length > 0)
                {
                    colliders[0].GetComponentInParent<GamasutraRoom>().getAttainable(roomsBefore,roomAfter);
                }

            }
        }
    }

    public Vector2 getXY()
    {
        return new Vector2(x*width,y*heigh);
    }

    public int getWidth()
    {
        return width;
    }
    public int getHeight()
    {
        return heigh;
    }

}
