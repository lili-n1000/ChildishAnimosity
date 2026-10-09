using System;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEngine;
using TMPro;

// This class is to monitor the logic for what tools the player deals with.
// If Rue deals Rock, and you deal paper, you win. Tools will continue 
public class WeaponUsage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // This keeps track of the different choices.
    public enum ToolChoice
    {
        Scissor,
        Book,
        Paperweight
    }

    public ToolChoice playerTool;
    public ToolChoice rueTool;

    public void checkTools(GameObject dealObject, GameObject rueObject)
    {
        // This will convert the player's GameObject name to Enum
        if (TryGetEnumFromObject(dealObject, out ToolChoice chosenPlayerTool))
        {
            playerTool = chosenPlayerTool;
            Debug.Log($"Player chose: {playerTool}");
        }
        else
        {
            Debug.LogError("Player's object name doesn't match any Enum!");
            return;
        }

        // This will convert Rue's GameObject name to Enum
        if (TryGetEnumFromObject(rueObject, out ToolChoice chosenRueTool))
        {
            rueTool = chosenRueTool;
            Debug.Log($"Rue chose: {rueTool}");
        }
        else
        {
            Debug.LogError("Rue's object name doesn't match any Enum! Make sure Rue has an object assigned.");
            return;
        }

        // 3. Now run your power hierarchy logic
        objectPowerHierarchy(playerTool, rueTool);
    }

    // This method allows me to check the given list of tools. 
    bool TryGetEnumFromObject(GameObject obj, out ToolChoice result)
    {
        if (obj == null)
        {
            result = default;
            return false;
        }
        return Enum.TryParse(obj.name, true, out result);
    }

    // This is a method that checks the validity of the object that
    // you have chosen. If the object you have chosen is valid against
    // what Rue deals, then she will lose one HP.
    void objectPowerHierarchy(ToolChoice player, ToolChoice rue)
    {
        // Condition check for a tie.
        // 10-05-2026 note: Code a scenario for a tie.
        if (player == rue)
        {
            Debug.Log("It's a tie! No HP lost.");
            return;
        }

        // Note to self: This method of switch cases is more cleaner
        // looking than writing out switch, condition, and then span many lines.
        // var switch statements as seen below is a bit more cleaner.

        // If the tie condition is not met, we can formally start checking the conditions. 
        // Keeping track that the first slot is whatever the Player chose.
        // Second slot: What Rue chose. 
        var matchResult = (player, rue) switch
        {
            // If the player wins, then Rue loses HP
            (ToolChoice.Scissor, ToolChoice.Book) => RueLosesHP("Your Scissor cuts Rue's Book! Rue loses 1 HP."),
            (ToolChoice.Book, ToolChoice.Paperweight) => RueLosesHP("Your Book covers Rue's Paperweight! Rue loses 1 HP."),
            (ToolChoice.Paperweight, ToolChoice.Scissor) => RueLosesHP("Your Paperweight smashes Rue's Scissor! Rue loses 1 HP."),

            // If Rue wins, then the player loses HP
            (ToolChoice.Book, ToolChoice.Scissor) => PlayerLosesHP("Rue's Scissor shreds your Book!"),
            (ToolChoice.Paperweight, ToolChoice.Book) => PlayerLosesHP("Rue's Book covers your Paperweight!"),
            (ToolChoice.Scissor, ToolChoice.Paperweight) => PlayerLosesHP("Rue's Paperweight smashes your Scissor!"),

            // This is incase we run into a weird, alternate encounter. A bug...
            _ => "Unknown encounter."
        };

        Debug.Log(matchResult);
    }

    string RueLosesHP(string message)
    {

        return message;
    }

    string PlayerLosesHP(string message)
    {
        return message;
    }
}
