using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public static GameManager singleton;
    [HideInInspector] public int health = 3;
    [HideInInspector] public int score = 0;
    [HideInInspector] public int best = 0;
    [HideInInspector] public bool camShakeToggle = true;
    
    public Animator camAnime;
    public GameObject gameEnvironment;
    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        best = PlayerPrefs.GetInt("Highscore");

    }

    public void PlayerHealth(int hit)
    {
        health -= hit;
        FindObjectOfType<Player>().DamageUI();
        //Debug.Log("GameManager Health Function Called");
    }

    public void Restart()
    {
        StartCoroutine("RestartWithButtonSound");

    }

    IEnumerator RestartWithButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        yield return new WaitForSeconds(.1f);
        singleton.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void CamShaker()
    {
        if (camShakeToggle == true)
        {
            camAnime.SetTrigger("Shake");
        }
        else
        {
            Debug.Log("Cam shake Off");
        }
    }

    public void Score(int addedScore)
    {
        score += addedScore;
        if(score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            DestroyPlayer();
        }

        ApplicationQuit();


    }

    void DestroyPlayer()
    {
        FindObjectOfType<UIManager>().GameOver();
        Player player = FindObjectOfType<Player>();
        if(player != null) { player.DestroyPlayer(); }
        //FindObjectOfType<Player>().DestroyPlayer();
    }

    public void ApplicationQuit()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }

    public void StartGame()
    {
        gameEnvironment.SetActive(true);
    }

}
