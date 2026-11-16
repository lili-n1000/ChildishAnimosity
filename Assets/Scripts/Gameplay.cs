using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.Tutorials.Editor;
using TMPro;
using System.Runtime.CompilerServices;

// This class is for the main gameplay loop. It will call from other classes to make the game function as intended.
public class Gameplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // This will keep track of rounds as well as max rounds.
    public int rounds = 0;
    public int maxRounds = 9;

    // Health of Rue or Player
    public float playerHealth = 3f;
    public float maxPlayerHealth = 3f;
    public float rueHealth = 3f;
    public float maxRueHealth = 3f;

    // Object Stuff
    public GameObject scissor, book, paperweight;
    public GameObject dealObject;
    public GameObject rueObject;

    // References with SerializeField
    // Self-Note: The Serialized Fields makes it easier to make a direct reference to so that you can 
    // slide scripts/objects there without worrying for it to initialize wrong.
    [SerializeField] private InputActionReference chooseObject;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject victory;
    [SerializeField] private Canvas mainGameUI;
    [SerializeField] private WeaponUsage weapon;
    [SerializeField] private RueScript rueEnemy;
    
    // Displays
    [SerializeField] private TMP_Text rueHealthDisplay;
    [SerializeField] private TMP_Text adinHealthDisplay;
    [SerializeField] private TMP_Text timeDisplay;

    // Private Boolean Conditions
    private bool isGameOver = false;
    private bool isVictory = false;
    private bool underFiftyPlayer= false;
    private bool underFiftyRue = false;

    // The very start.
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponUsage>();
        rueEnemy = GameObject.FindGameObjectWithTag("Rue").GetComponent<RueScript>();
        mainGameUI.gameObject.SetActive(true);
        Debug.Log("Choose your object.");
        isGameOver = false;
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

        if (isGameOver || isVictory)
        {
            return;
        }

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
            rueHealthDisplay.text = rueHealth.ToString();
            Debug.Log("Rue Health = " + rueHealth);
        }
        else if (WeaponUsage.winLoseRue == true) {
            playerHealth -= 1;
            adinHealthDisplay.text = playerHealth.ToString();
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
            gameOver.SetActive(true);
            mainGameUI.gameObject.SetActive(false);
            isGameOver = true;
        }
        else if (rueHealth <= 0)
        {
            Debug.Log("Rue has lost! Next Round!");
            isVictory = true;
            victory.SetActive(true);
            Time.timeScale = 0f; // Freezes physics, animations, and Time.deltaTime
        }
    }

    // This method is for if Rue has lost all her health.
    // This initializes the next round.
    public void nextRound()
    {
        victory.SetActive(false);
        isVictory = false;
        Time.timeScale = 1f;

        rounds += 1;
        Debug.Log("Round " + rounds + " out of " + maxRounds + "!");

        // Health Updates
        rueHealth = 3 + 2 * rounds;
        rueHealthDisplay.text = rueHealth.ToString();
        playerHealth = 3 + rounds;
        adinHealthDisplay.text = playerHealth.ToString();

        // Max Health Updates
        maxRueHealth = 3 + 2 * rounds;
        maxPlayerHealth = 3 + rounds;
        underFiftyRue = false;
        underFiftyPlayer = false;
    }

}
