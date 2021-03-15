using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float DestroyTime;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}
