using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RandomRooms : MonoBehaviour {
    enum entry
    {
        T,R,L,B,LT,LB,RT,RB,TL,TR,BL,BR
    }
    struct newRoom
    {
        public int height, width;
        public entry e;
    }
    struct sideStruct
    {
        public bool left;
        public bool right;
        public bool top;
        public bool bottom;
    }

    [SerializeField] private GameObject baseUnit;
    private float unit;
    const int sizeX = 100;
    const int sizeY = 100;
    sideStruct[,] rooms = new sideStruct[sizeX, sizeY]; // to know where are the doors
    int[,] bufferRooms = new int[sizeX, sizeY];         // if 0, no room, 1 doing, 2 done

    // H1
    List<GameObject> H1L = new List<GameObject>();  // doors on left
    List<GameObject> H1R = new List<GameObject>();  // doors on right    
    // W1
    List<GameObject> W1T = new List<GameObject>();  // doors on top    
    List<GameObject> W1B = new List<GameObject>();  // doors on bottom   
    // H2
    List<GameObject> H2LT = new List<GameObject>(); // doors on left top
    List<GameObject> H2LB = new List<GameObject>(); // doors on left bottom    
    List<GameObject> H2RT = new List<GameObject>(); // doors on right top
    List<GameObject> H2RB = new List<GameObject>(); // doors on riht bottom  
    // W2
    List<GameObject> W2TL = new List<GameObject>(); // doors on top left
    List<GameObject> W2TR = new List<GameObject>(); // doors on top right    
    List<GameObject> W2BL = new List<GameObject>(); // doors on bottom left
    List<GameObject> W2BR = new List<GameObject>(); // doors on bottom right  

    const int startX = 50;
    const int startY = 50;
    int currentX;
    int currentY;

    List<Vector2> doorsToDo = new List<Vector2>();

    [Header("List of prefab rooms")]
    [SerializeField] List<GameObject> listPrefabsRoom = new List<GameObject>();  // the prebas of the rooms
    [SerializeField] GameObject corridor;

    // Use this for initialization
    void Start ()
    {
        unit = baseUnit.GetComponent<Renderer>().bounds.size.x;
        initArray();    // init the arrays of rooms
        parsePrefab();  // parse the prefab list to put them in the corresponding lists
        currentX = startX;
        currentY = startY;
        addFirstRoom();
        addOtherRooms(5);
    }

    /*
    * @brief : add all the rooms of the level
    * @param nbRooms : nb of rooms to add
    */
    void addOtherRooms(int nbRooms)
    {
        int cpt = 0;
        while (cpt < nbRooms)
        {
            
            cpt++;
        }
        Debug.Log(doorsToDo.Count);
        addRoom(doorsToDo[0]);
    }

    /*
    *@brief : parse the array of rooms preab in several list for the rendom rooms
    */
    void parsePrefab()
    {
        foreach (GameObject go in listPrefabsRoom)
        {
            if (go != null)
            {
                // H1 W1
                if (go.GetComponent<RoomSmallSquare>())
                {
                    RoomSmallSquare r = go.GetComponent<RoomSmallSquare>();
                    if (r.getDoorLeft()) H1L.Add(go);
                    if (r.getDoorRight()) H1R.Add(go);
                    if (r.getDoorTop()) W1T.Add(go);
                    if (r.getDoorBottom()) W1B.Add(go);
                }
                else if (go.GetComponent<RoomRectangle>())
                {
                    RoomRectangle r = go.GetComponent<RoomRectangle>();
                    // H1 W2
                    if (r.getHeight() == 1)
                    {
                        if (r.getDoorLeft()) H1L.Add(go);
                        if (r.getDoorRight()) H1R.Add(go);
                        if (r.getDoorTopLeft()) W2TL.Add(go);
                        if (r.getDoorTopRight()) W2TR.Add(go);
                        if (r.getDoorBottomLeft()) W2BL.Add(go);
                        if (r.getDoorBottomRight()) W2BR.Add(go);
                    }
                    // H2 W1
                    else
                    {
                        if (r.getDoorTop()) W1T.Add(go);
                        if (r.getDoorBottom()) W1B.Add(go);
                        if (r.getDoorLeftTop()) H2LT.Add(go);
                        if (r.getDoorLeftBottom()) H2LB.Add(go);
                        if (r.getDoorRightTop()) H2RT.Add(go);
                        if (r.getDoorRightBottom()) H2RB.Add(go);
                    }
                }
                else if (go.GetComponent<RoomBigSquare>())
                {
                    RoomBigSquare r = go.GetComponent<RoomBigSquare>();
                    if (r.getDoorTopLeft()) W2TL.Add(go);
                    if (r.getDoorTopRight()) W2TR.Add(go);
                    if (r.getDoorBottomLeft()) W2BL.Add(go);
                    if (r.getDoorBottomRight()) W2BR.Add(go);
                    if (r.getDoorLeftTop()) H2LT.Add(go);
                    if (r.getDoorLeftBottom()) H2LB.Add(go);
                    if (r.getDoorRightTop()) H2RT.Add(go);
                    if (r.getDoorRightBottom()) H2RB.Add(go);
                }
                else
                {
                    Debug.LogError("Missing Room Script");
                }
            }
            else
            {
                Debug.LogError("Missing game object in the list of rooms");
            }
        }


    }


    /*
    *@brief : initialize the array of rooms
    */
    void initArray()
    {
        for(int i = 0; i <sizeX; i++)
        {
            for (int j=0;j<sizeY;j++)
            {
                sideStruct s;
                s.left = false;
                s.right = false;
                s.top = false;
                s.bottom = false;
                rooms[i,j] = s;
                bufferRooms[i, j] = 0;
            }
        }
    }

    /*
    *@brief : add the first room of the level, which is always the first corridor
    */

    void addFirstRoom()
    {
        // corridor (49 50) and (50 50)
        rooms[50, 50].right = true;
        bufferRooms[50, 51] = 2;
        doorsToDo.Add(new Vector2(50,50));
        addRoom(new Vector2(50, 50));
    }

    // get the shape of room possible + the entry
    List<newRoom> getListPossibleRooms(Vector2 place)
    {
        List<newRoom> listRooms = new List<newRoom>();

        int x = (int)place.x;
        int y = (int)place.y;
        // check the doors
        if (rooms[x, y].left)
        {
            // big square entry RT
            if (bufferRooms[x - 1, y] == 0 && bufferRooms[x - 2, y] == 0 && bufferRooms[x - 1, y + 1] == 0 && bufferRooms[x - 2, y + 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.RT;
                listRooms.Add(nr);
            }
            // big square entry RB
            if (bufferRooms[x - 1, y] == 0 && bufferRooms[x - 2, y] == 0 && bufferRooms[x - 1, y - 1] == 0 && bufferRooms[x - 2, y - 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.RB;
                listRooms.Add(nr);
            }
            // vertical rectangle square entry RT
            if (bufferRooms[x - 1, y] == 0 && bufferRooms[x - 1, y + 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 1;
                nr.e = entry.RT;
                listRooms.Add(nr);
            }
            // vertical rectangle square entry RB
            if (bufferRooms[x - 1, y] == 0 && bufferRooms[x - 1, y - 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 1;
                nr.e = entry.RB;
                listRooms.Add(nr);
            }
            // horizontal rectangle square entry R
            if (bufferRooms[x - 1, y] == 0 && bufferRooms[x - 2, y ] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 2;
                nr.e = entry.R;
                listRooms.Add(nr);
            }
            // small square entry R
            if (bufferRooms[x - 1, y] == 0 )
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 1;
                nr.e = entry.R;
                listRooms.Add(nr);
            }
        }
        if (rooms[x, y].right)
        {
            // big square entry LT
            if (bufferRooms[x + 1, y] == 0 && bufferRooms[x + 2, y] == 0 && bufferRooms[x + 1, y + 1] == 0 && bufferRooms[x + 2, y + 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.LT;
                listRooms.Add(nr);
            }
            // big square entry LB
            if (bufferRooms[x + 1, y] == 0 && bufferRooms[x + 2, y] == 0 && bufferRooms[x - 1, y - 1] == 0 && bufferRooms[x - 2, y - 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.LB;
                listRooms.Add(nr);
            }
            // vertical rectangle square entry LT
            if (bufferRooms[x + 1, y] == 0 && bufferRooms[x + 1, y + 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 1;
                nr.e = entry.LT;
                listRooms.Add(nr);
            }
            // vertical rectangle square entry LB
            if (bufferRooms[x + 1, y] == 0 && bufferRooms[x + 1, y - 1] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 1;
                nr.e = entry.LB;
                listRooms.Add(nr);
            }
            // horizontal rectangle square entry L
            if (bufferRooms[x + 1, y] == 0 && bufferRooms[x + 2, y] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 2;
                nr.e = entry.L;
                listRooms.Add(nr);
            }
            // small square entry L
            if (bufferRooms[x + 1, y] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 1;
                nr.e = entry.L;
                listRooms.Add(nr);
            }
        }
        if (rooms[x, y].top)
        {
            // big square entry BL
            if (bufferRooms[x , y-1] == 0 && bufferRooms[x , y-2] == 0 && bufferRooms[x +1, y - 1] == 0 && bufferRooms[x +1, y -2] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.BL;
                listRooms.Add(nr);
            }
            // big square entry BR
            if (bufferRooms[x - 1, y-1] == 0 && bufferRooms[x - 1, y-2] == 0 && bufferRooms[x , y - 1] == 0 && bufferRooms[x , y - 2] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.BR;
                listRooms.Add(nr);
            }
            // horizontal rectangle square entry BL
            if (bufferRooms[x , y-1] == 0 && bufferRooms[x +1, y - 1] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 2;
                nr.e = entry.BL;
                listRooms.Add(nr);
            }
            // horizontal rectangle square entry BR
            if (bufferRooms[x - 1, y-1] == 0 && bufferRooms[x , y - 1] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 2;
                nr.e = entry.BR;
                listRooms.Add(nr);
            }
            // vertical rectangle square entry B
            if (bufferRooms[x , y-1] == 0 && bufferRooms[x , y-2] == 0)
            {
                newRoom nr;
                nr.height =2;
                nr.width = 1;
                nr.e = entry.B;
                listRooms.Add(nr);
            }
            // small square entry B
            if (bufferRooms[x , y-1] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 1;
                nr.e = entry.B;
                listRooms.Add(nr);
            }
        }
        if (rooms[x, y].bottom)
        {
            // big square entry TL
            if (bufferRooms[x, y + 1] == 0 && bufferRooms[x, y + 2] == 0 && bufferRooms[x + 1, y + 1] == 0 && bufferRooms[x + 1, y + 2] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.TL;
                listRooms.Add(nr);
            }
            // big square entry TR
            if (bufferRooms[x , y - 1] == 0 && bufferRooms[x , y - 2] == 0 && bufferRooms[x-1, y - 1] == 0 && bufferRooms[x-1, y - 2] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 2;
                nr.e = entry.TR;
                listRooms.Add(nr);
            }
            // horizontal rectangle square entry TL
            if (bufferRooms[x, y + 1] == 0 && bufferRooms[x + 1, y +1] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 2;
                nr.e = entry.TL;
                listRooms.Add(nr);
            }
            // horizontal rectangle square entry TR
            if (bufferRooms[x - 1, y +1] == 0 && bufferRooms[x, y + 1] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 2;
                nr.e = entry.TR;
                listRooms.Add(nr);
            }
            // vertical rectangle square entry T
            if (bufferRooms[x, y + 1] == 0 && bufferRooms[x, y + 2] == 0)
            {
                newRoom nr;
                nr.height = 2;
                nr.width = 1;
                nr.e = entry.T;
                listRooms.Add(nr);
            }
            // small square entry T
            if (bufferRooms[x, y + 1] == 0)
            {
                newRoom nr;
                nr.height = 1;
                nr.width = 1;
                nr.e = entry.T;
                listRooms.Add(nr);
            }
        }
        return listRooms;
    }

    // end = true : cul de sac
    void addDoorsToRoom(List<newRoom> listRoomsPossible, bool end, Vector2 place)
    {
        
        bool found = false;
        while (!found)
        {
            int random = Random.Range(0, listRoomsPossible.Count);// random room of the list
            newRoom typeRoom = listRoomsPossible[random];
            // get the prefab corresponding to the rooms chosen
            List<GameObject> listRooms = new List<GameObject>();
            if (typeRoom.height == 1)
            {
                if (typeRoom.e == entry.L) listRooms.AddRange(H1L);
                else if (typeRoom.e == entry.R) listRooms.AddRange(H1R);
            }
            if (typeRoom.width == 1)
            {
                if (typeRoom.e == entry.T) listRooms.AddRange(W1T);
                else if (typeRoom.e == entry.B) listRooms.AddRange(W1B);
            }
            if (typeRoom.height == 2)
            {
                if (typeRoom.e == entry.LT) listRooms.AddRange(H2LT);
                else if (typeRoom.e == entry.LB) listRooms.AddRange(H2LB);
                else if (typeRoom.e == entry.RT) listRooms.AddRange(H2RT);
                else if (typeRoom.e == entry.RB) listRooms.AddRange(H2RB);
            }
            if (typeRoom.width == 2)
            {
                if (typeRoom.e == entry.TL) listRooms.AddRange(W2TL);
                else if (typeRoom.e == entry.TR) listRooms.AddRange(W2TR);
                else if (typeRoom.e == entry.BL) listRooms.AddRange(W2BL);
                else if (typeRoom.e == entry.BR) listRooms.AddRange(W2BR);
            }
            if (listRooms.Count == 0)
            {
                listRoomsPossible.Remove(typeRoom);
            }
            else
            {
                found = true;
              
                List<GameObject> withoutDuplicate = new List<GameObject>( listRooms.Distinct().ToList()); // delete duplicate
                List<GameObject> li = new List<GameObject>(withoutDuplicate);
                // if end, delete all the room with two doors
                
                    for (int i = 0; i < withoutDuplicate.Count; i++)
                    {
                        Debug.Log(withoutDuplicate[i]);
                        int cpt = 0;
                        if (withoutDuplicate[i].GetComponent<Room>().getDoorLeft()) cpt++;
                        if (withoutDuplicate[i].GetComponent<Room>().getDoorRight()) cpt++;
                        if (withoutDuplicate[i].GetComponent<Room>().getDoorTop()) cpt++;
                        if (withoutDuplicate[i].GetComponent<Room>().getDoorBottom()) cpt++;

                        if (end && cpt>1)
                        {
                            li.Remove(withoutDuplicate[i]);
                        }
                        else if (!end && cpt ==1)
                        {
                            li.Remove(withoutDuplicate[i]);
                        }
                    }
                Debug.Log(li.Count);
                int r = Random.Range(0, li.Count);
                // create the room in the lvl
                GameObject go = (GameObject)Instantiate(li[r], this.GetComponent<Transform>());
                getXYRoom(go, typeRoom.e, place);
                addRoomToArray(go);
                setBufferRooms(typeRoom.height, typeRoom.width,place);
                go.GetComponent<Transform>().localPosition = new Vector3((go.GetComponent<Room>().getXY().x - startX) * unit,- (go.GetComponent<Room>().getXY().y - startY) * unit, this.GetComponent<Transform>().position.z);


            }

        }
        
       
    }

    void addRoom(Vector2 place) {

        // TODO : the first have to get one entry and one issue one the right
        // TODO : make a first path
        List<newRoom> listRooms = getListPossibleRooms(place); // get the list of possible rooms with there shape
        Debug.Log(listRooms.Count);
        addDoorsToRoom(listRooms, false, place);
        doorsToDo.Remove(place);

    }
  
    /*
    void searchRoom(List<GameObject> list, bool end, Vector2 place, string side)
    {
        // cul de sac
        if (end)
        {
            bool found = false;                 // is the room found
            List<GameObject> listGo = new List<GameObject>(list);    // copy the list to delete if not found
            GameObject goRoom = listGo[0];      // game object of the room choosen
          
            while (!found)
            {
                int index = Random.Range(0, listGo.Count);
                goRoom = listGo[index];
                // true : no door
                bool l = true;
                bool r = true;
                bool t = true;
                bool b = true;

                if (list != listRoomsLeft && listRoomsLeft.Contains(goRoom))
                {
                    l = false;
                }
                if (list != listRoomsRight && listRoomsRight.Contains(goRoom))
                {
                    r = false;
                }
                if (list != listRoomsTop && listRoomsTop.Contains(goRoom))
                {
                    t = false;
                }
                if (list != listRoomsBottom && listRoomsBottom.Contains(goRoom))
                {
                    b = false;
                }
                if (l && r && t && b )
                {
                    found = true;
                }
                else
                {
                    listGo.Remove(goRoom);
                }
            }
            getXYRoom(goRoom, side, place);
            addRoomToArray(goRoom, false);
            addRoomToLevel(goRoom);
        }
    }
    */

    void setBufferRooms(int height, int width,Vector2 place )
    {
        bufferRooms[(int) place.x, (int) place.y] = 1;
        if (height==2) bufferRooms[(int)place.x, (int)place.y+1] = 1;
        if(width==2) bufferRooms[(int)place.x+1, (int)place.y] = 1;
        if(height==2 && width==2) bufferRooms[(int)place.x + 1, (int)place.y+1] = 1;

    }
    // entry of the new room
    void getXYRoom(GameObject goRoom, entry e, Vector2 place)
    {
        int x = (int)place.x;
        int y = (int)place.y;
        Debug.Log("Room : " + goRoom + " x: " + x + " y: " + y);

        if (goRoom.GetComponent<RoomSmallSquare>())
        {
            if (e == entry.L) place.x++;
            else if (e == entry.R) place.x--;
            else if (e == entry.T) place.y--;
            else if (e == entry.B) place.y--;
        }
        else if (goRoom.GetComponent<RoomRectangle>())
        {
            //horizontal
            if (goRoom.GetComponent<RoomRectangle>().getHeight() == 1)
            {
                if (e == entry.TL) place.y++;
                else if (e == entry.TR)
                {
                    place.x--;
                    place.y++;
                }
                else if (e == entry.BL) place.y--;
                else if (e == entry.BR)
                {
                    place.x--;
                    place.y--;
                }
                else if (e == entry.L) place.x++;
                else if (e == entry.R) place.x -= 2;
            }
            //vertical
            if (goRoom.GetComponent<RoomRectangle>().getHeight() == 2)
            {
                if (e == entry.RB)
                {
                    place.x--;
                    place.y--;
                }
                else if (e == entry.RT)
                {
                    place.x--;
                    place.y++;
                }
                else if (e == entry.LT) place.x++;
                else if (e == entry.LB)
                {
                    place.y--;
                    place.x++;
                }
                else if (e == entry.B) place.y -= 2;
                else if (e == entry.T) place.y++;
            }
        }
        else if (goRoom.GetComponent<RoomBigSquare>())
        {
            if (e == entry.RT) place.x -= 2;
            else if (e == entry.RB)
            {
                place.x -=2;
                place.y--;
            }
            else if (e == entry.LT) place.x++;
            else if (e == entry.LB)
            {
                place.x++;
                place.y--;
            }
            else if (e == entry.TL) place.y++;
            else if (e == entry.TR)
            {
                place.x--;
                place.y++;
            }
            else if (e == entry.BL) place.y -= 2;
            else if (e== entry.BR)
            {
                place.x--;
                place.y -= 2;
            }
        }
        x = (int)place.x;
        y = (int)place.y;
        goRoom.GetComponent<Room>().setXY(x, y);
        Debug.Log("## : " + goRoom + " x: " + x + " y: " + y);

    }
    /*
    *@brief :   add a room to array
    *@param room : room to add to the array 
    *@param first : if first doesn't add the left door
    */
    void addRoomToArray(GameObject go)
    {
        // get the x y for the top left of the new room
        int witdh = go.GetComponent<Room>().getWidth();
        int height = go.GetComponent<Room>().getHeight();
        if (go.GetComponent<RoomSmallSquare>())
        {
            RoomSmallSquare r = go.GetComponent<RoomSmallSquare>();
            rooms[(int)r.getXY().x, (int)r.getXY().y].left = r.getDoorLeft();
            rooms[(int)r.getXY().x, (int)r.getXY().y].right = r.getDoorRight();
            rooms[(int)r.getXY().x, (int)r.getXY().y].top = r.getDoorTop();
            rooms[(int)r.getXY().x, (int)r.getXY().y].bottom = r.getDoorBottom();
            if (!r.getDoorLeft() && !r.getDoorRight() && !r.getDoorTop() && !r.getDoorBottom())
            {
                bufferRooms[(int)r.getXY().x, (int)r.getXY().y] = 2;
            }
            else
            {
                bufferRooms[(int)r.getXY().x, (int)r.getXY().y] = 1;
                doorsToDo.Add(new Vector2((int)r.getXY().x, (int)r.getXY().y));
            }
        }
        else if (go.GetComponent<RoomRectangle>())
        {
            RoomRectangle r = go.GetComponent<RoomRectangle>();
            // if horizontal
            if (r.getHeight() == 1)
            {
                // first case
                rooms[(int)r.getXY().x, (int)r.getXY().y].left = r.getDoorLeft();
                rooms[(int)r.getXY().x, (int)r.getXY().y].top = r.getDoorTopLeft();
                rooms[(int)r.getXY().x, (int)r.getXY().y].bottom = r.getDoorBottomLeft();
                // no doors
                if (!r.getDoorLeft() && !r.getDoorTopLeft() && !r.getDoorBottomLeft())
                {
                    bufferRooms[(int) r.getXY().x, (int) r.getXY().y] = 2;
                }
                else
                {
                    bufferRooms[(int) r.getXY().x, (int) r.getXY().y] = 1;
                    doorsToDo.Add(new Vector2((int)r.getXY().x, (int)r.getXY().y));
                }
                // second case
                rooms[(int)r.getXY().x+1, (int)r.getXY().y].right = r.getDoorRight();
                rooms[(int)r.getXY().x+1, (int)r.getXY().y].top = r.getDoorTopRight();
                rooms[(int)r.getXY().x+1, (int)r.getXY().y].bottom = r.getDoorBottomLeft();
                // no doors
                if (!r.getDoorRight() && !r.getDoorTopLeft() && !r.getDoorBottomLeft())
                {
                    bufferRooms[(int)r.getXY().x+1, (int)r.getXY().y] = 2;
                }
                else
                {
                    bufferRooms[(int)r.getXY().x+1, (int)r.getXY().y] = 1;
                    doorsToDo.Add(new Vector2((int)r.getXY().x+1, (int)r.getXY().y));
                }
            }
            // if vertical
            else if (r.getHeight() == 2)
            {
                // first case
                rooms[(int)r.getXY().x, (int)r.getXY().y].left = r.getDoorLeftTop();
                rooms[(int)r.getXY().x, (int)r.getXY().y].right = r.getDoorRightTop();
                rooms[(int)r.getXY().x, (int)r.getXY().y].top = r.getDoorTop();
                // if no doors
                if (!r.getDoorLeftTop() & !r.getDoorRightTop() & !r.getDoorTop())
                {
                    bufferRooms[(int) r.getXY().x, (int) r.getXY().y] = 2;
                }
                else
                {
                    bufferRooms[(int) r.getXY().x, (int) r.getXY().y] = 1;
                    doorsToDo.Add(new Vector2((int)r.getXY().x, (int)r.getXY().y));
                }
                // second case
                rooms[(int)r.getXY().x, (int)r.getXY().y+1].right = r.getDoorRightBottom();
                rooms[(int)r.getXY().x, (int)r.getXY().y+1].left = r.getDoorLeftBottom();
                rooms[(int)r.getXY().x, (int)r.getXY().y+1].bottom = r.getDoorBottom();
                // if no doors
                if (!r.getDoorRightBottom() & !r.getDoorLeftBottom() & !r.getDoorBottom())
                {
                    bufferRooms[(int)r.getXY().x, (int)r.getXY().y+1] = 2;
                }
                else
                {
                    bufferRooms[(int)r.getXY().x, (int)r.getXY().y+1] = 1;
                    doorsToDo.Add(new Vector2((int)r.getXY().x, (int)r.getXY().y+1));

                }
            }
        }
        else if (go.GetComponent<RoomBigSquare>())
        {
            RoomBigSquare r = go.GetComponent<RoomBigSquare>();
            //  AB
            //  CD

            // case A
            rooms[(int)r.getXY().x, (int)r.getXY().y].left = r.getDoorLeftTop();
            rooms[(int)r.getXY().x, (int)r.getXY().y].top = r.getDoorTopLeft();
            // if no doors
            if (!r.getDoorLeftTop() && !r.getDoorTopLeft())
            {
                bufferRooms[(int) r.getXY().x, (int) r.getXY().y] = 2;
            }
            else
            {
                bufferRooms[(int) r.getXY().x, (int) r.getXY().y] = 1;
                doorsToDo.Add(new Vector2((int)r.getXY().x, (int)r.getXY().y));

            }
            // case B
            rooms[(int)r.getXY().x+1, (int)r.getXY().y].right = r.getDoorRightTop();
            rooms[(int)r.getXY().x+1, (int)r.getXY().y].top = r.getDoorTopRight();
            // if no doors
            if (!r.getDoorRightTop() && !r.getDoorTopRight())
            {
                bufferRooms[(int)r.getXY().x+1, (int)r.getXY().y] = 2;
            }
            else
            {
                bufferRooms[(int)r.getXY().x+1, (int)r.getXY().y] = 1;
                doorsToDo.Add(new Vector2((int)r.getXY().x+1, (int)r.getXY().y));

            }
            // case C
            rooms[(int)r.getXY().x, (int)r.getXY().y+1].left = r.getDoorLeftTop();
            rooms[(int)r.getXY().x, (int)r.getXY().y+1].bottom = r.getDoorTopLeft();
            // if no doors
            if (!r.getDoorLeftTop() && !r.getDoorTopLeft())
            {
                bufferRooms[(int)r.getXY().x , (int)r.getXY().y+1] = 2;
            }
            else
            {
                bufferRooms[(int)r.getXY().x, (int)r.getXY().y+1] = 1;
                doorsToDo.Add(new Vector2((int)r.getXY().x, (int)r.getXY().y+1));

            }
            // case D
            rooms[(int)r.getXY().x + 1, (int)r.getXY().y+1].right = r.getDoorRightBottom();
            rooms[(int)r.getXY().x + 1, (int)r.getXY().y+1].bottom = r.getDoorBottom();
            // if no doors
            if (!r.getDoorRightBottom() && !r.getDoorBottom())
            {
                bufferRooms[(int)r.getXY().x+1, (int)r.getXY().y + 1] = 2;
            }
            else
            {
                bufferRooms[(int)r.getXY().x+1, (int)r.getXY().y + 1] = 1;
                doorsToDo.Add(new Vector2((int)r.getXY().x+1, (int)r.getXY().y+1));

            }
        }

    }

    void addRoomToLevel(GameObject go)
    {
        GameObject.Instantiate(go, this.GetComponent<Transform>());
        //go.GetComponent<Transform>().localPosition = new Vector3(go.GetComponent<Transform>().position.x, go.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z);
        //        Debug.Log("X : "+ (go.GetComponent<Room>().getXY().x-startX) * unit);
        //        Debug.Log("Y : " + go.GetComponent<Room>().getXY().y * unit);
        go.GetComponent<Transform>().localPosition = new Vector3((go.GetComponent<Room>().getXY().x-startX)*unit, (go.GetComponent<Room>().getXY().y-startY) * unit, this.GetComponent<Transform>().position.z);
    }
}
