using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public GameObject Effects;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(Effects, transform.position, Quaternion.identity);
            GameManager.singleton.PlayerHealth(1);
            Destroy(gameObject);
        }
    }
}
