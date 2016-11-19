using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    private bool miniMap = false;
    private float x, y;
    private Vector3 newPosition;

    private Vector3 g1;
    private Vector3 g2;
    public void setMinimap(bool state)
    {
        miniMap = state;
    }

    /* position at the beginning*/
    public void firstPositionCorridor(GameObject corridor)
    {
        // put the camera at the left of the corridor
        // left x of the corridor + /2 cam size
        float leftX = corridor.transform.position.x - corridor.GetComponent<GamasutraRoom>().getXY().x/2 + corridor.GetComponent<GamasutraRoom>().getXY().x /6.0f;
        transform.position = new Vector3(leftX, corridor.transform.position.y,this.transform.position.z);
    }

    void Update()
    {
        if (player != null)
        {
            x = player.position.x;
            y = player.position.y;
            
            if (!miniMap )
            {
                isInRoom(x, y);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime*100);
            }
            else if (miniMap)
            {
                Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 100);
            }
        }

    }
    /*
    void OnDrawGizmos()
    {
        if (g1 != null && g2 != null)
        {
            Gizmos.DrawCube(g1,g2 );
            Debug.Log("gizmo "+g1+" "+g2);
        }
    }
    */
    private void isInRoom(float x, float y)
    {
       
       Vector2 size =GameManager.instance.getCurrentRoom()
                .GetComponent<GamasutraRoom>()
                .getSize();

        Vector2 center = GameManager.instance.getCurrentRoom()
                .GetComponent<GamasutraRoom>()
                .getCenter();

        //g1 = new Vector3(bounds.center.x,bounds.center.y,0);
        //g2 = new Vector3(bounds.size.x,bounds.size.y,0);
       
        x = Mathf.Clamp(x, center.x-size.x/2, center.x + size.x/2);
        y = Mathf.Clamp(y, center.y - size.y/2, center.y + size.y/2);

        newPosition.x = x;
        newPosition.y = y;
        newPosition.z = this.transform.position.z;
        //boxRoom.offset =new Vector2(bounds.center.x- this.transform.position.x ,  bounds.center.y- this.transform.position.y);
        //boxRoom.size = bounds.size;


    }

}
