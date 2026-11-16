using JetBrains.Annotations;
using UnityEngine;

public class GameOverScreenScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void deathCall()
    {
        gameObject.SetActive(true);
    }

}
