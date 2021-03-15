using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    [Header("Scores Text")]
    public Text score;
    public Text best;
    public Text hP;
    [Header("Menu UI")]
    public GameObject gameOver;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    [Header("Volume Mixers")]
    public AudioMixer audioMixer;


    private void Awake()
    {
        gameOver.SetActive(false);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        score.text ="Score: " +GameManager.singleton.score;
        best.text ="HighScore: " + GameManager.singleton.best;
        hP.text ="HP: " + GameManager.singleton.health;

    }

    public void MainMenu()
    {
        
        HideGameobject(mainMenu);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        
    }

    public void OptionsMenu()
    {
        
        HideGameobject(optionsMenu);
    }

    public void BackButton()
    {
        
        mainMenu.SetActive(true);
        HideGameobject(optionsMenu);
    }

    void HideGameobject(GameObject go)
    {
        if(go.activeInHierarchy)
        {
            go.SetActive(false);
        }
        else
        {
            go.SetActive(true);
        }
    }

    public void CamShakeToggle(bool tog)
    {
        
        GameManager.singleton.camShakeToggle = tog;
        //Debug.Log(tog);
    }

    public void ButtonClickSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void Play()
    {
        
        GameManager.singleton.StartGame();
        MainMenu();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
