using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions.Comparers;

public class Gamasutra : MonoBehaviour
{
    public List<GameObject> rooms;
    List<GameObject> lvlRooms = new List<GameObject>();
    List<Vector3> lastPos = new List<Vector3>();
    public int nbRoom;
    private float tileSize = 0.2f;

    public bool go = false;
    private List<GameObject> listBufferHorizontal;
    private List<GameObject> listBufferVertical;

    // Use this for initialization
    void Start ()
	{
	    createRooms(nbRoom);
	    foreach (GameObject go in lvlRooms )
	    {
	        go.AddComponent<BoxCollider2D>();
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
            

                float x = higher.GetComponent<Transform>().localPosition.x;
                float y = higher.GetComponent<Transform>().localPosition.y;
                float z = higher.GetComponent<Transform>().localPosition.z;
                float xx = Mathf.Floor(x/tileSize);
               
                if (x - xx*tileSize < tileSize/2.0f)
                    xx++;

                higher.GetComponent<Transform>().localPosition = new Vector3(xx*tileSize, y, z);

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

                float x = higher.GetComponent<Transform>().localPosition.x;
                float y = higher.GetComponent<Transform>().localPosition.y;
                float z = higher.GetComponent<Transform>().localPosition.z;
                bool positif = (y >= 0);
                
                y = Mathf.Abs(y);
                float yy = Mathf.Floor(y / tileSize);

                if (y- yy * tileSize > tileSize / 2.0f)
                    yy++;
                float yyy = yy*tileSize;
                if (!positif)
                    yyy = -yyy;


                higher.GetComponent<Transform>().localPosition = new Vector3(x,yyy,  z);
                listBufferVertical.Remove(higher);
            }
            foreach (GameObject l in lvlRooms)
            {

                l.GetComponent<BoxCollider2D>().enabled = true;

            }
            for (int i = 0; i < lvlRooms.Count; i++)
            {
                
                lvlRooms[i].GetComponent<GamasutraRoom>().check();
                
            }
            go = false;
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
            s.GetComponent<Transform>().localPosition = getRandomPointInEllipse(2f,0.4f);//getRandomPointInCircle(1.0f);
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
        return new Vector2(roundm(ellipse_width * r * Mathf.Cos(t)/2, tileSize), roundm(ellipse_height * r * Mathf.Sin(t)/2, tileSize));

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

        return new Vector2(roundm(radius*r*Mathf.Cos(t), tileSize), roundm(radius*r*Mathf.Sin(t),tileSize));
    }

    float roundm(float n , float  m )
    {
        return Mathf.Floor((n + m - 1)/m)*m;
    }

    // check if alone
    
}
