
using UnityEngine;

public class RepeatingEnvironment : MonoBehaviour
{

    public float speed;
    public float Xstart;
    public float Xend;


    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < Xend)
        {
            Vector2 pos = new Vector2(Xstart, transform.position.y);
            transform.position = pos;
            Debug.Log("condition");
        }

    }
}
