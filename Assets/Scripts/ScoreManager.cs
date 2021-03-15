using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.singleton.Score(1);
            
        }

    }
}
