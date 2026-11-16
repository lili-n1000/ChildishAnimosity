using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // This sets the GameOver Screen to true.
    public void deathCall()
    {
        gameObject.SetActive(true);
    }

    // This button restarts the game.
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // This button sends the player back to the title screen.
    public void exitTitle()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
