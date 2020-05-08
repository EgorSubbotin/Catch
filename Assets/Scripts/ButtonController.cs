using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{    
    public void GoToMenu()
    {        
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {        
        SceneManager.LoadScene("Play");
    }
}
