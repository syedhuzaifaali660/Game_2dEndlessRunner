using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject[] Enemy;

    private void Start()
    {
        int rand = Random.Range(0, Enemy.Length);
        Instantiate(Enemy[rand], transform.position, Quaternion.identity);
    }
}
