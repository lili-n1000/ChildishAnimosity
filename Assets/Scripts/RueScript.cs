using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;

// This is a script to manage behaviors from Rue, the little girl
// that you are fighting again.
// This will monitor her whatever she dishes out to the player.
// Maybe her health might be managed here.
public class RueScript : MonoBehaviour
{
    public GameObject rueObject;
    // This will be the toolbox for Rue.
    // It is the same as the player.
    public GameObject scissor, book, paperweight;
    public List<GameObject> objectList;
    System.Random rand = new System.Random();

    public GameObject rueRandomTool()
    {
        gameObjectAddToList();
        int randomObject = rand.Next(0, objectList.Count - 1);
        rueObject = objectList[randomObject];

        return rueObject;
    }

    // Supplementary 
    private void gameObjectAddToList()
    {
        objectList.Add(scissor);
        objectList.Add(book);
        objectList.Add(paperweight);

    }
    

}
