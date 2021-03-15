
using UnityEngine;

public class Rotate : MonoBehaviour
{

     public float speed = 15;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speed));
    }
}
