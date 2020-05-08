using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    const string HIGH_SCORE = "HighScore";
    const string MY_SCORE = "MyScore";
    //const string LIFE_POINT = "LifePoint";
    void Start()
    {
        InstantianVeriables();
        if (instance != null)
        {
            Destroy(gameObject);            
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }            
    }
    public void InstantianVeriables()
    {
        if (!PlayerPrefs.HasKey("InstantianVeriables"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(MY_SCORE, 0);
            //PlayerPrefs.SetInt(LIFE_POINT, 0);
            PlayerPrefs.SetInt("InstantianVeriables", 0);
        }
    }
    public void SetHighScore(int highScore) { PlayerPrefs.SetInt(HIGH_SCORE, highScore); }
    public int GetHighScore() { return PlayerPrefs.GetInt(HIGH_SCORE); }

    public void SetMyScore(int myScore) { PlayerPrefs.SetInt(MY_SCORE, myScore); }
    public int GetMyScore() { return PlayerPrefs.GetInt(MY_SCORE); }

    //public void SetLifePoint (int lifePoint) { PlayerPrefs.SetInt(LIFE_POINT, lifePoint); }
}
