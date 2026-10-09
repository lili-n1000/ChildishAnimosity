using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class is for the main gameplay loop. It will call from other classes to make the game function as intended.
public class Gameplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // This will keep track of rounds as well as max rounds.
    public int rounds = 0;
    public int maxRounds = 5;
    public GameObject scissor, book, paperweight;
    public GameObject dealObject;
    public GameObject rueObject;
    // Private Variables
    private WeaponUsage weapon;
    private RueScript rueEnemy;

    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponUsage>();
        rueEnemy = GameObject.FindGameObjectWithTag("Rue").GetComponent<RueScript>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject rueChoice = rueEnemy.rueRandomTool();
        activateTool(rueChoice);
    }
    void activateTool(GameObject rueObject)
    {
        Debug.Log("Choose your object.");
        if (Input.GetKeyDown(KeyCode.A))
        {
            dealObject = scissor;
            weapon.checkTools(dealObject, rueObject);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            dealObject = book;
            weapon.checkTools(dealObject, rueObject);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dealObject = paperweight;
            weapon.checkTools(dealObject, rueObject);
        }
    }
}
