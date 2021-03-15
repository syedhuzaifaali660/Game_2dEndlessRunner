using UnityEngine;

public class Repeating2Left : MonoBehaviour
{
    public float speed;
    public float endY;
    private float length;

    // Use this for initialization
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x * 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.y < endY)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + length);
        }
    }
}
