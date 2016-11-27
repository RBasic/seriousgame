using UnityEngine;
using System.Collections;

public class EnemyPathing : MonoBehaviour {

    public bool chasingPlayer = false;
    public bool pathing = true;
    public bool backing = false;

    bool checkLastPosition = true;
    Vector3 lastPosition, currentPosition;

    public float basicSpeed = 2.0f;
    public float maxSpeed = 2.8f;

    public Vector3 walkAmount;
    float walkingDirection = 1.0f;

    float xStart, yStart, zStart;
    public float xLeftLimit, xRightLimit;

    public Vector3 start;
    public Vector3 targetDir;
    public float angle;
    PolygonCollider2D visionCone;

    // Use this for initialization
    void Start ()
    {
        start.x = transform.position.x;
        start.y = transform.position.y;
        start.z = transform.position.z;

        xLeftLimit = gameObject.transform.parent.FindChild("TriggerL").transform.localPosition.x;
        xRightLimit = gameObject.transform.parent.FindChild("TriggerR").position.x;

        visionCone = gameObject.GetComponentInChildren<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentPosition = transform.position;

        if (!backing)
        {
            if (chasingPlayer)
                walkAmount.x = maxSpeed * Time.deltaTime;
            else
                walkAmount.x = basicSpeed * Time.deltaTime;

            transform.Translate(walkAmount);
        }

        else
        {
            walkAmount.x = basicSpeed * Time.deltaTime;
            if ((lastPosition.x > currentPosition.x && start.x > currentPosition.x) || (lastPosition.x < currentPosition.x && start.x < currentPosition.x))
                Flip();
            transform.position = Vector3.MoveTowards(transform.position, start, walkAmount.x);

            if (Mathf.Abs(transform.position.x - start.x) < 0.5f)
            {
                backing = false;
                pathing = true;
            }
        }

        lastPosition = currentPosition;
    }

    public bool getChasingPlayer() { return chasingPlayer; }
    public void setChasingPlayer(bool b) { chasingPlayer = b; }

    public bool getPathing() { return pathing; }
    public void setPathing(bool b) { pathing = b; }

    public void Flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void startSpeedBoostCoroutine()
    {
        StartCoroutine(OneSecondSpeedBoost());
        
    }

    IEnumerator OneSecondSpeedBoost()
    {
        yield return new WaitForSeconds(1);

        chasingPlayer = false;
        walkAmount.x = basicSpeed * Time.deltaTime;
        backing = true;
    }
}
