using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public Material[] characterMaterials; // An array of materials for different character colors

    private void Start()
    {
        // Get the selected character index from PlayerPrefs
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);

        // Check if the selected character index is within the bounds of your characterMaterials array
        if (selectedCharacter >= 0 && selectedCharacter < characterMaterials.Length)
        {
            // Apply the selected character's color material to the character's renderer (assuming your character has a renderer)
            Renderer characterRenderer = GetComponent<Renderer>(); // Modify this to match your character's setup
            characterRenderer.material = characterMaterials[selectedCharacter];
        }
        else
        {
            Debug.LogWarning("Selected character index is out of bounds.");
        }
    }
}