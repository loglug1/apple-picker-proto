using UnityEngine;

public class TreeController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePreFab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirection = 0.1f;
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x >= leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        } else if (pos.x <= -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        }
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    //FixedUpdate runs 50 times per second
    void FixedUpdate()
    {
        if (Random.Range(0f,1f) <= chanceToChangeDirection) {
            speed *= -1f;
        }
    }

    void DropApple() {
        Instantiate(applePreFab, transform.position, transform.rotation);
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
