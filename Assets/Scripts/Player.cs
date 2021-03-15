using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private Vector2 targetPos1;

    public float Xincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    [Header("Prefabs For Player Movement")]
    public List<GameObject> PlayerEffects = new List<GameObject>();
    [Header("Prefabs For Damage Function")]
    public List<GameObject> DamageRelatedPrefabs = new List<GameObject>();

    private void Awake()
    {
        targetPos1 = transform.position;
    }


    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.MoveTowards(transform.position, targetPos1, speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxHeight)        {
            //Instantiate(PlayerEffects, transform.position, Quaternion.identity);
            PlayerMovementPrefabs();
            GameManager.singleton.CamShaker();
            targetPos1 = new Vector2(transform.position.x + Xincrement, transform.position.y);

        } else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minHeight)        {
            //Instantiate(PlayerEffects, transform.position, Quaternion.identity);
            PlayerMovementPrefabs();
            GameManager.singleton.CamShaker();
            targetPos1 = new Vector2(transform.position.x - Xincrement,transform.position.y);
        }
  
 
    }

    private void PlayerMovementPrefabs()
    {
        foreach (GameObject go in PlayerEffects)
        {
            Instantiate(go, transform.position, Quaternion.identity);
        }
    }

    public void DamageUI()
    {
        for (int i = 0; i < DamageRelatedPrefabs.Count; i++)
        {
            Instantiate(DamageRelatedPrefabs[i], transform.position, Quaternion.identity);
        }

    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
