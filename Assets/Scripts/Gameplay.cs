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

    // Health of Rue or Player
    public float playerHealth = 3f;
    public float maxPlayerHealth = 3f;
    public float rueHealth = 3f;
    public float maxRueHealth = 3f;

    public GameObject scissor, book, paperweight;
    public GameObject dealObject;
    public GameObject rueObject;
    public InputActionReference chooseObject;

    // Private Variables
    private WeaponUsage weapon;
    private RueScript rueEnemy;
    private bool underFiftyPlayer= false;
    private bool underFiftyRue = false;

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

    // OnEnable and OnDisable is important that if you press a button, the action will
    // not occur twice when you press on it again.
    private void OnEnable()
    {
        chooseObject.action.started += ObjectChosen;
    }

    private void OnDisable()
    {
        chooseObject.action.started -= ObjectChosen;
    }

    // This is to control the variables that if a certain object 
    // is passed through, then an action happens.
    private void ObjectChosen(InputAction.CallbackContext obj)
    {
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

        // This will keep track if the player or Rue loses HP.
        if (WeaponUsage.winLosePlayer == true)
        {
            rueHealth -= 1;
            Debug.Log("Rue Health = " + rueHealth);
        }
        else if (WeaponUsage.winLoseRue == true) {
            playerHealth -= 1;
            Debug.Log("Player Health = " + playerHealth);
        }

        // If HPs are under 50%, danger prompt appears
        if (playerHealth <= maxPlayerHealth / 2 && underFiftyPlayer != true)
        {
            Debug.Log("DANGER: PLAYER IS UNDER 50%");
            underFiftyPlayer = true;
        }
        else if (rueHealth <= maxRueHealth / 2 && underFiftyRue != true)
        {
            Debug.Log("ALERT: RUE MAY DIE!");
            underFiftyRue = true;
        }

        // Prompts for healths going to 0.
        if (playerHealth <= 0)
        {
            Debug.Log("Player has lost! Game Over!");
        }
        else if (rueHealth <= 0)
        {
            Debug.Log("Rue has lost! Next Round!");
            nextRound();
        }

    }

    // This method is for if Rue has lost all her health.
    private void nextRound()
    {
        rounds += 1;
        Debug.Log("Round 1!");
        rueHealth = 3 + 2 * rounds;
        maxRueHealth = 3 + 2 * rounds;
        maxPlayerHealth = 3 + rounds;
        playerHealth = 3 + rounds;
        underFiftyRue = false;
        underFiftyPlayer = false;
    }

}
