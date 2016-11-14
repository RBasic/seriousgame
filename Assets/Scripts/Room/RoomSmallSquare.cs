using UnityEngine;
using System.Collections;

public class RoomSmallSquare : Room {
    [Header("Doors")]
    [SerializeField]
    bool doorsTop;      // door on the top
    [SerializeField]
    bool doorsBottom;   // door on the bottom
    [SerializeField]
    bool doorsRight;    // door on the right
    [SerializeField]
    bool doorsLeft;     // door on the left


    /*
    *@brief : is the room have doors one the left side
    */
    public override bool getDoorLeft()
    {
        return doorsLeft;
    }

    /*
    *@brief : is the room have doors one the right side
    */
    public override bool getDoorRight()
    {
        return doorsRight;
    }

    /*
    *@brief : is the room have doors one the top side
    */
    public override bool getDoorTop()
    {
        return doorsTop;
    }

    /*
    *@brief : is the room have doors one the bottom side
    */
    public override bool getDoorBottom()
    {
        return doorsBottom;
    }

    /*
  *@brief : size of the height
  * return the height of the room
  */
    public override int getHeight()
    {
        return 1;
    }

    /*
   *@brief : size of the width
   * return the witdh of the room
   */
    public override int getWidth()
    {
        return 1;
    }
}
