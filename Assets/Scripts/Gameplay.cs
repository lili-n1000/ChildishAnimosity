using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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
    public InputActionReference chooseObject;

    // Private Variables
    private WeaponUsage weapon;
    private RueScript rueEnemy;

    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponUsage>();
        rueEnemy = GameObject.FindGameObjectWithTag("Rue").GetComponent<RueScript>();
        Debug.Log("Choose your object.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        chooseObject.action.started += ObjectChosen;
    }

    private void OnDisable()
    {
        chooseObject.action.started -= ObjectChosen;
    }

    private void ObjectChosen(InputAction.CallbackContext obj)
    {
        Debug.Log("Object Chosen.");

        string pressedKey = obj.control.name.ToLower();

        if (pressedKey == "a")
        {
            dealObject = scissor;
            Debug.Log("Scissor, It Is.");
        }
        else if (pressedKey == "s")
        {
            dealObject = book;
            Debug.Log("Book, It Is.");
        }
        else if (pressedKey == "d")
        {
            dealObject = paperweight;
            Debug.Log("Paperweight, It Is.");
        }

        rueObject = rueEnemy.rueRandomTool();
        weapon.checkTools(dealObject, rueObject);
    }
}
