using UnityEngine;
using UnityEngine.SceneManagement;

// This is the class the manage the main menu.
// The main menu allows the player to adjust settings, play the game, or quit.
public class MainMenu : MonoBehaviour
{
    // For the play button
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
