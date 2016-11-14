using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{
    private int x;  // top left x in the array of rooms
    private int y;  // top left y int he array of rooms

    /*
    *@brief : get the place in the array of the left top point of this room
    * return couple(x,y)
    */
    public Vector2 getXY()
    {
        return new Vector2(x,y);
    }

    /*
    *@brief : set the place in the array of the left top point of this room
    * @param x : top left x in the array of rooms
    * @param y : top left y in the array of rooms
    */
    public void setXY(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    /*
    *@brief : is the room have doors one the left side
    * return true if there are doors on the left side
    */
    public virtual  bool getDoorLeft()
    {
        return false;
    }

    /*
    *@brief : is the room have doors one the right side
    * return true if there are doors on the right side
    */
    public virtual  bool getDoorRight()
    {
        return false;
    }

    /*
    *@brief : is the room have doors one the top side
    * return true if there are doors on the top side
    */
    public virtual bool getDoorTop()
    {
        return false;
    }

    /*
    *@brief : is the room have doors one the bottom side
    * return true if there are doors on the bottom side
    */
    public virtual  bool getDoorBottom()
    {
        return false;
    }

    /*
   *@brief : size of the height
   * return the height of the room
   */
    public virtual int getHeight()
    {
        return 0;
    }

    /*
   *@brief : size of the width
   * return the witdh of the room
   */
    public virtual int getWidth()
    {
        return 0;
    }

}
