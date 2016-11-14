using UnityEngine;
using System.Collections;

public class RoomBigSquare : Room
{

    [Header("Doors")]
    [SerializeField]
    bool doorTopLeft;      // door on the top left
    [SerializeField]
    bool doorTopRight;     // door on the top right
    [SerializeField]
    bool doorBottomLeft;   // door on the bottom left
    [SerializeField]
    bool doorBottomRight;  // door on the bottom right
    [SerializeField]
    bool doorRightTop;    // door on the right top
    [SerializeField]
    bool doorRightBottom;    // door on the right bottom
    [SerializeField]
    bool doorLeftTop;     // door on the left top
    [SerializeField]
    bool doorLeftBottom;     // door on the left bottom


    public bool getDoorTopLeft()
    {
        return doorTopLeft;
    }
    public bool getDoorTopRight()
    {
        return doorTopRight;
    }
    public bool getDoorRightTop()
    {
        return doorRightTop;
    }
    public bool getDoorRightBottom()
    {
        return doorRightBottom;
    }
    public bool getDoorLeftTop()
    {
        return doorLeftTop;
    }
    public bool getDoorLeftBottom()
    {
        return doorLeftBottom;
    }
    public bool getDoorBottomLeft()
    {
        return doorBottomLeft;
    }
    public bool getDoorBottomRight()
    {
        return doorBottomRight;
    }

    /** OVERRIDE **/
    /*
    *@brief : is the room have doors one the left side
    */
    public override bool getDoorLeft()
    {
        return (doorLeftTop || doorLeftBottom);
    }

    /*
    *@brief : is the room have doors one the right side
    */
    public override bool getDoorRight()
    {
        return (doorRightTop || doorRightBottom);
    }

    /*
    *@brief : is the room have doors one the top side
    */
    public override bool getDoorTop()
    {
        return (doorTopLeft || doorTopRight);
    }

    /*
    *@brief : is the room have doors one the bottom side
    */
    public override bool getDoorBottom()
    {
        return (doorBottomLeft || doorBottomRight);
    }

    /*
 *@brief : size of the height
 * return the height of the room
 */
    public override int getHeight()
    {
        return 2;
    }

    /*
   *@brief : size of the width
   * return the witdh of the room
   */
    public override int getWidth()
    {
        return 2;
    }
}
