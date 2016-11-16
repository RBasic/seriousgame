using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions.Comparers;

public class Gamasutra : MonoBehaviour
{
    public List<GameObject> rooms;  // type of rooms possibles
    List<GameObject> lvlRooms = new List<GameObject>();
    List<Vector3> lastPos = new List<Vector3>();    // to check if the elements are always in movement

    public int nbRoom;
    private float tileSizeX = 18f;
    private float tileSizeY = 10f;

    public bool go = false;
    private List<GameObject> listBufferHorizontal;  // to replace the elements on a "grid"
    private List<GameObject> listBufferVertical;    // to replace the elements on a "grid"

    public CreateMiniMap coucou;

    // to create the minimap
    private List<Vector2> miniMapSmall = new List<Vector2>();
    private List<Vector2> miniMapRectV = new List<Vector2>();
    private List<Vector2> miniMapRectH = new List<Vector2>();
    private List<Vector2> miniMapBig = new List<Vector2>();

    // Use this for initialization
    void Start ()
	{
	    createRooms(nbRoom);
	    foreach (GameObject go in lvlRooms )
	    {
	        //go.AddComponent<BoxCollider2D>();
            go.AddComponent<Rigidbody2D>();
	        go.GetComponent<Rigidbody2D>().gravityScale = 0;
	        go.GetComponent<Rigidbody2D>().freezeRotation = true;
	    }
	    for (int i = 0; i < lvlRooms.Count; i++)
	    {
	        lastPos.Add(lvlRooms[i].GetComponent<Transform>().position);
	    }
        listBufferHorizontal = new List<GameObject>(lvlRooms);
        listBufferVertical = new List<GameObject>(lvlRooms);

    }

    void FixedUpdate()
    {

        if (go)
        {
            foreach (GameObject l in lvlRooms)
            {
                l.GetComponent<BoxCollider2D>().enabled = false;
                l.GetComponent<Rigidbody2D>().isKinematic = true;

            }
            while (listBufferHorizontal.Count > 0)
            {
            GameObject higher = listBufferHorizontal[0];
                for (int i = 0; i < listBufferHorizontal.Count; i++)
                {
                    if (listBufferHorizontal[i].GetComponent<Transform>().position.x < higher.GetComponent<Transform>().position.x)
                    {
                            higher = listBufferHorizontal[i];
                    }
                }

                float xOffset = higher.GetComponent<GamasutraRoom>().getXY().x/2;
                float x = higher.GetComponent<Transform>().localPosition.x - xOffset;

                float y = higher.GetComponent<Transform>().localPosition.y;
                float z = higher.GetComponent<Transform>().localPosition.z;       

                bool positif = (x >= 0);
                x = Mathf.Abs(x);
                float xx = Mathf.Floor(x / tileSizeX);
                if (x - xx * tileSizeX > tileSizeX / 2.0f)
                    xx++;
                float xxx = xx * tileSizeX;
                if (!positif)
                    xxx = -xxx;

                higher.GetComponent<Transform>().localPosition = new Vector3(xxx+xOffset, y, z);

                listBufferHorizontal.Remove(higher);

            }
            while (listBufferVertical.Count > 0)
            {
                GameObject higher = listBufferVertical[0];
                for (int i = 0; i < listBufferVertical.Count; i++)
                {
                    if (listBufferVertical[i].GetComponent<Transform>().position.y> higher.GetComponent<Transform>().position.y)
                    {
                        higher = listBufferVertical[i];
                    }
                }
                float yOffset = higher.GetComponent<GamasutraRoom>().getXY().y / 2;

                float x = higher.GetComponent<Transform>().localPosition.x;
                float y = higher.GetComponent<Transform>().localPosition.y+yOffset;
                float z = higher.GetComponent<Transform>().localPosition.z;

                bool positif = (y >= 0);
                y = Mathf.Abs(y);
                float yy = Mathf.Floor(y / tileSizeY);
                if (y - yy * tileSizeY> tileSizeY / 2.0f)
                    yy++;
                float yyy = yy * tileSizeY;
                if (!positif)
                    yyy = -yyy;


                higher.GetComponent<Transform>().localPosition = new Vector3(x,yyy-yOffset,  z);
                listBufferVertical.Remove(higher);
            }
            
            foreach (GameObject l in lvlRooms)
            {

                l.GetComponent<BoxCollider2D>().enabled = false;    // desable the big collider
                l.GetComponent<GamasutraRoom>().getColliderSupperpose().enabled = true; // enable the little

            }
            for (int i = 0; i < lvlRooms.Count; i++)
            {
                lvlRooms[i].GetComponent<GamasutraRoom>().check();
            }

            // minimap for the offset in the array
            float xMin = lvlRooms[0].GetComponent<Transform>().position.x;
            float yMin = lvlRooms[0].GetComponent<Transform>().position.y;
            for (int i = 1; i < lvlRooms.Count; i++)
            {
                if (lvlRooms[i].GetComponent<Transform>().position.x<xMin)
                {
                    xMin = lvlRooms[i].GetComponent<Transform>().position.x;
                }
                if (lvlRooms[i].GetComponent<Transform>().position.y < yMin)
                {
                    yMin = lvlRooms[i].GetComponent<Transform>().position.y;
                }
            }
            for (int i = 0; i < lvlRooms.Count; i++)
            {
                float x = (lvlRooms[i].GetComponent<Transform>().position.x - xMin)/ tileSizeX;
                float y = (lvlRooms[i].GetComponent<Transform>().position.y - yMin)/ tileSizeY;
                Debug.Log(x+" "+y);
                if (lvlRooms[i].GetComponent<GamasutraRoom>().heigh == 1 &&
                    lvlRooms[i].GetComponent<GamasutraRoom>().width == 1)
                {
                    miniMapSmall.Add(new Vector2(x,y));
                }
                else if (lvlRooms[i].GetComponent<GamasutraRoom>().heigh == 2 &&
                    lvlRooms[i].GetComponent<GamasutraRoom>().width == 2)
                {
                    miniMapBig.Add(new Vector2(x, y));
                }
                else if (lvlRooms[i].GetComponent<GamasutraRoom>().heigh == 1 &&
                    lvlRooms[i].GetComponent<GamasutraRoom>().width == 2)
                {
                    miniMapRectH.Add(new Vector2(x, y));
                }
                else if (lvlRooms[i].GetComponent<GamasutraRoom>().heigh == 2 &&
                    lvlRooms[i].GetComponent<GamasutraRoom>().width == 1)
                {
                    miniMapRectV.Add(new Vector2(x, y));
                }
            }
            go = false;
            coucou.create(miniMapSmall,miniMapBig,miniMapRectV,miniMapRectH);
        }
       /*
            for (int i = 0; i < lvlRooms.Count; i++)
            {
                float x = lvlRooms[i].GetComponent<Transform>().localPosition.x;
                float y = lvlRooms[i].GetComponent<Transform>().localPosition.y;
                float z = lvlRooms[i].GetComponent<Transform>().localPosition.z;

                lvlRooms[i].GetComponent<Transform>().localPosition =new Vector3(roundm(x, tileSize),roundm(y, tileSize),z);

            }
          
        */

    }

    void createRooms(int nbRooms)
    {
        for (int i = 0; i < nbRooms; i++)
        {
            GameObject s = (GameObject) Instantiate(rooms[Random.Range(0, rooms.Count)], this.transform);
            s.GetComponent<Transform>().localPosition = getRandomPointInEllipse(40,10);//getRandomPointInCircle(1.0f);
            lvlRooms.Add(s);
        }
    }

    Vector2 getRandomPointInEllipse(float ellipse_width, float ellipse_height)
    {
        float t = 2 * Mathf.PI * Random.Range(0.0f, 1.0f);
        float u = Random.Range(0.0f, 1.0f) + Random.Range(0f, 1f);
        float r = 0;
        if (u > 1)
        {
            r = 2.0f - u;
        }
        else
        {
            r = u;
        }
        return new Vector2(roundm(ellipse_width * r * Mathf.Cos(t)/2, tileSizeX), roundm(ellipse_height * r * Mathf.Sin(t)/2, tileSizeY));

    }


    Vector2 getRandomPointInCircle(float radius)
    {
        float t = 2*Mathf.PI*Random.Range(0.0f,1.0f);
        float u = Random.Range(0.0f, 1.0f)+ Random.Range(0f, 1f);
        float r = 0;
        if (u > 1)
        {
            r = 2.0f - u;
        }
        else
        {
            r = u;
        }
        //return new Vector2(radius*r*Mathf.Cos(t),radius*r*Mathf.Sin(t));

        return new Vector2(roundm(radius*r*Mathf.Cos(t), tileSizeX), roundm(radius*r*Mathf.Sin(t),tileSizeY));
    }

    float roundm(float n , float  m )
    {
        return Mathf.Floor((n + m - 1)/m)*m;
    }

    // check if alone
    
}
