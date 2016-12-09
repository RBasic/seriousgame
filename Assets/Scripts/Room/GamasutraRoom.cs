using UnityEngine;
using System.Collections.Generic;

public class GamasutraRoom : MonoBehaviour
{
    private bool see = false;   // is the room already see by the player

    public int heigh;
    public int width;
    [SerializeField] BoxCollider2D colliderSupperpose;
    private int x = 16;
    private int y = 9;
    [SerializeField]
    GameObject colliderBorder;

    public GameObject checkSide;


    [Header("Inside")]
    public GameObject insidePrefab;
    GameObject inside;
    [SerializeField] private GameObject spawn;
    private List<GameObject> listSpawn = new List<GameObject>();
    private bool alreadySpawn = false;
    private List<GameObject> listEnemies = new List<GameObject>();

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
    public GameObject doorTL;
    public GameObject doorTR;
    public GameObject doorBL;
    public GameObject doorBR;

    [Header("MiniMap")]
    [SerializeField] GameObject miniMap;

    Collider2D[] colliders;

    void Awake()
    {
        if (insidePrefab != null)
        {
            inside = Instantiate(insidePrefab);
            inside.transform.SetParent(this.transform);
            inside.transform.localPosition = Vector3.zero;
            inside.SetActive(false);
        }
        if (spawn != null)
        {
            foreach (Transform go in this.spawn.GetComponentsInChildren<Transform>(true))
            {
                if (go != spawn)
                {
                    listSpawn.Add(go.gameObject);
                }
            }
        }
    }

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
        // check if the centers of the element collide with collider
        if (heigh == 1 && width == 1)
        {
            // center
            Vector3 center = this.GetComponent<Transform>().localPosition;
            deleteCollider(lvlRooms, center);


        }
        else if (heigh == 2 && width == 2)
        {
            // center TL
            Vector3 center = this.GetComponent<Transform>().localPosition;
            center.x -= x/2;
            center.y += y/2;
            deleteCollider(lvlRooms, center);


            // center TR
            center = this.GetComponent<Transform>().localPosition;
            center.x += x/2;
            center.y += y/2;
            deleteCollider(lvlRooms, center);


            // center BL
            center = this.GetComponent<Transform>().localPosition;
            center.x -= x / 2;
            center.y -= y / 2;
            deleteCollider(lvlRooms, center);

            // center BR
            center = this.GetComponent<Transform>().localPosition;
            center.x += x / 2;
            center.y -= y / 2;
            deleteCollider(lvlRooms, center);

        }
        else if (heigh == 1 && width == 2)
        {
            // center L
            Vector3 center = this.GetComponent<Transform>().localPosition;
            center = this.GetComponent<Transform>().localPosition;
            center.x -= x / 2;
         
          
            deleteCollider(lvlRooms, center);


            // center R
            center = this.GetComponent<Transform>().localPosition;
            center = this.GetComponent<Transform>().localPosition;
            center.x += x / 2;

            deleteCollider(lvlRooms, center);

        }
        else if (heigh == 2 && width == 1)
        {
            // center T
            Vector3 center = this.GetComponent<Transform>().localPosition;
            center = this.GetComponent<Transform>().localPosition;
            center.y += y / 2;
            deleteCollider(lvlRooms, center);


            // center B
            center = this.GetComponent<Transform>().localPosition;
            center = this.GetComponent<Transform>().localPosition;
            center.y -= y / 2;
            deleteCollider(lvlRooms, center);
        }
      
    }

    void deleteCollider(List<GameObject> lvlRooms, Vector3 center)
    {
        colliders = Physics2D.OverlapPointAll(center);

        if (colliders.Length > 1)
        {
            for (int i = 1; i < colliders.Length; i++)
            {
                // Debug.Log(this + " " + "delete because of superposition");
                lvlRooms.Remove(colliders[i].gameObject.GetComponentInParent<GamasutraRoom>().gameObject);
                //Debug.Log(lvlRooms.Count);
                Destroy(colliders[i].gameObject.GetComponentInParent<GamasutraRoom>().gameObject);
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
            Vector3 originR = new Vector3(center.x+(x),center.y,center.z);
            colliders = Physics2D.OverlapPointAll(originR);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorR.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorR.SetActive(false);
            }

            Vector3 originL = new Vector3(center.x - (x), center.y, center.z);
            colliders = Physics2D.OverlapPointAll(originL);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorL.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorL.SetActive(false);
            }

            Vector3 originT = new Vector3(center.x , center.y+(y), center.z);
            colliders = Physics2D.OverlapPointAll(originT);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorT.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorT.SetActive(false);
            }

            Vector3 originB = new Vector3(center.x , center.y-(y), center.z);
            colliders = Physics2D.OverlapPointAll(originB);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorB.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorB.SetActive(false);
            }

        }
        // big square
        else if (heigh == 2 && width == 2)
        {

            //Top Left
            Vector3 originTL = new Vector3(center.x - (x/2), center.y+(y)+(y/2), center.z);
            colliders = Physics2D.OverlapPointAll(originTL);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorTL.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorTL.SetActive(false);
            }

            //Top Right
            Vector3 originTR = new Vector3(center.x + (x / 2), center.y + (y) + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originTR);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorTR.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorTR.SetActive(false);
            }

            //Right Top
            Vector3 originRT = new Vector3(center.x + x+(x / 2), center.y + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originRT);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorRT.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorRT.SetActive(false);
            }

            //Right Bottom
            Vector3 originRB = new Vector3(center.x + x + (x / 2), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originRB);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorRB.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorRB.SetActive(false);
            }

            //Bottom Right
            Vector3 originBR = new Vector3(center.x + (x / 2), center.y - (y) - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originBR);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorBR.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorBR.SetActive(false);
            }

            //Bottom Left
            Vector3 originBL = new Vector3(center.x - (x / 2), center.y - (y) - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originBL);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorBL.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorBL.SetActive(false);
            }

            //Left Bottom
            Vector3 originLB = new Vector3(center.x - x - (x / 2), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLB);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorLB.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorLB.SetActive(false);
            }

            //Left Top
            Vector3 originLT = new Vector3(center.x - x - (x / 2), center.y + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLT);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorLT.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorLT.SetActive(false);
            }

        }
        // rect H
        if (heigh == 1 && width == 2)
        {
            //Top Left
            Vector3 originTL = new Vector3(center.x - (x / 2), center.y + (y), center.z);
            colliders = Physics2D.OverlapPointAll(originTL);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorTL.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorTL.SetActive(false);
            }

            //Top Right
            Vector3 originTR = new Vector3(center.x + (x / 2), center.y + (y) , center.z);
            colliders = Physics2D.OverlapPointAll(originTR);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorTR.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorTR.SetActive(false);
            }

            //Right
            Vector3 originR = new Vector3(center.x + x + (x / 2), center.y, center.z);
            colliders = Physics2D.OverlapPointAll(originR);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorR.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorR.SetActive(false);
            }

            //Bottom Right
            Vector3 originBR = new Vector3(center.x + (x / 2), center.y - (y), center.z);
            colliders = Physics2D.OverlapPointAll(originBR);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorBR.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorBR.SetActive(false);
            }

            //Bottom Left
            Vector3 originBL = new Vector3(center.x - (x / 2), center.y - (y) , center.z);
            colliders = Physics2D.OverlapPointAll(originBL);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorBL.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorBL.SetActive(false);
            }

            //Left
            Vector3 originL = new Vector3(center.x - x - (x / 2), center.y , center.z);
            colliders = Physics2D.OverlapPointAll(originL);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorL.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorL.SetActive(false);
            }

        }
       // rect V
        if (heigh == 2 && width == 1)
        {
            //Top
            Vector3 originT = new Vector3(center.x , center.y + (y) + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originT);

            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorT.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorT.SetActive(false);
            }

            //Right Top
            Vector3 originRT = new Vector3(center.x  + (x ), center.y + (y / 2), center.z);
       
            colliders = Physics2D.OverlapPointAll(originRT);
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorRT.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorRT.SetActive(false);
            }

            //Right Bottom
            Vector3 originRB = new Vector3(center.x + (x ), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originRB);
      
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorRB.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                // doorRB.SetActive(false);
            }

            //Bottom
            Vector3 originB = new Vector3(center.x, center.y -(y) - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originB);
     
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorB.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorB.SetActive(false);
            }

            //Left Bottom
            Vector3 originLB = new Vector3(center.x  - (x ), center.y - (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLB);
          
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorLB.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorLB.SetActive(false);
            }

            //Left Top
            Vector3 originLT = new Vector3(center.x  - (x ), center.y + (y / 2), center.z);
            colliders = Physics2D.OverlapPointAll(originLT);
         
            if (colliders.Length > 0)
            {
                cpt++;
                foreach (SpriteRenderer g in doorLT.GetComponentsInChildren<SpriteRenderer>())
                {
                    g.enabled = false;
                    g.GetComponent<BoxCollider2D>().isTrigger = true;
                    g.gameObject.AddComponent<DiscoverRoom>();
                }
                //doorLT.SetActive(false);
            }
        }

        if (cpt == 0)
        {
            Debug.Log(this + " " + "delete because of alone");
            GameObject go = this.gameObject;
            lvlRooms.Remove(this.gameObject);
            Destroy(go);
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

    public bool getSee()
    {
        return see;
    }

    public void setSee(bool state)
    {
        see = state;
        miniMap.SetActive(see); // if the player see the room display it in the minimap
    }

    public void activeBorderCollider()
    {
        foreach (BoxCollider2D box in colliderBorder.GetComponentsInChildren<BoxCollider2D>())
        {
            box.enabled = true;
        }
        colliderSupperpose.enabled = false;
    }

    // put the minimap visible
    public void discoverRoom(bool state)
    {
        if (state && inside!=null)
        {
            inside.SetActive(true);
        }
        // make the enemy spawn if it's not already spawn
        if (state && listSpawn.Count != 0 && !alreadySpawn)
        {
            Debug.Log("ici");
            makeEnemySpawn();
        }
        miniMap.SetActive(state);
    }

    public Vector2 getCenter()
    {
        return  new Vector2(this.transform.position.x, this.transform.position.y);

       
    }

    public Vector2 getSize()
    {
       return new Vector2(x * (width - 1), y * (heigh - 1));

    }

    void makeEnemySpawn()
    {
        
        int nbEnemy = Random.Range(1, listSpawn.Count); // at least one enemy
        Debug.Log("nbenemy : "+nbEnemy);
        while (nbEnemy!=0)
        {
            int indexEnemy = Random.Range(0, listSpawn.Count);
            GameObject enemy = Instantiate(GameManager.instance.getPrefabEnemy());
            enemy.transform.SetParent(this.gameObject.transform);
            enemy.transform.localPosition = listSpawn[indexEnemy].transform.localPosition;
            Debug.Log("Ennemi à la position locale: " + enemy.transform.localPosition + ", globale: " + enemy.transform.position);
            listEnemies.Add(enemy);
            listSpawn.RemoveAt(indexEnemy);
            nbEnemy--;
        }
        alreadySpawn = true;
    }

}
