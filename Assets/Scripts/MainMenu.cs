using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;
    public Text myScore;

    void Start()
    {
        highScore.text = $" {GameController.instance.GetHighScore()}";
        myScore.text = GameController.instance.GetMyScore().ToString();        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Play");        
    }
    public void QuittButton()
    {
        Application.Quit();
    }
}
