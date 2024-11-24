using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allPlayers;
    private List<GameObject> activePlayers = new List<GameObject>();
    public int currentPlayerIndex = 0;

    private void Start()
    {
        // Get the number of players from PlayerPrefs
        int playerCount = PlayerPrefs.GetInt("NumPlayers", 2);
        SelectPlayers(playerCount);
    }

    public void SelectPlayers(int playerCount)
    {
        activePlayers.Clear();

        // Activate players
        for (int i = 0; i < playerCount; i++)
        {
            activePlayers.Add(allPlayers[i]);
            allPlayers[i].gameObject.SetActive(true);
            Debug.Log($"{allPlayers[i].name} is active.");
        }

        // Deactivate players
        for (int i = playerCount; i < allPlayers.Count; i++)
        {
            allPlayers[i].gameObject.SetActive(false);
            Debug.Log($"{allPlayers[i].name} is inactive.");
        }
    }

    public List<GameObject> GetActivePlayers()
    {
        return activePlayers;
    }

    // Get the current player's name
    public string GetCurrentPlayerName()
    {
        if (activePlayers.Count > 0)
        {
            return activePlayers[currentPlayerIndex].name;  // Return the name of the current player
        }
        return "Unknown";  //  "Unknown" if no players
    }

    // next player's turn
    public void NextTurn()
    {
        currentPlayerIndex = (currentPlayerIndex+1) % activePlayers.Count;
    }
}
