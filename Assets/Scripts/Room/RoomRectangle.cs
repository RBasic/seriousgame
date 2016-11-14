using UnityEngine;
using System.Collections;

public class RoomRectangle : RoomBigSquare
{
    [Header("Rotation +90° sens horaire")]
    [SerializeField]
    bool horizontal;      // is the room horizontal or vertical ?

    /*
 *@brief : size of the height
 * return the height of the room
 */
    public override int getHeight()
    {
        if (horizontal)
            return 1;
        else
            return 2;
    }

    /*
   *@brief : size of the width
   * return the witdh of the room
   */
    public override int getWidth()
    {
        if (horizontal)
            return 1;
        else
            return 2;
    }

}
