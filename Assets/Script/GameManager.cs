using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Player> allPlayers;  
    private List<Player> activePlayers = new List<Player>();  

    private void Start()
    {
        // Get the number of players from PlayerPrefs
        int playerCount = PlayerPrefs.GetInt("NumPlayers", 2); // Default to 2 if no player count is set
        SelectPlayers(playerCount);
    }

    public void SelectPlayers(int playerCount)
    {
        activePlayers.Clear();

        // Activate 
        for (int i = 0; i < playerCount; i++)
        {
            activePlayers.Add(allPlayers[i]);
            allPlayers[i].gameObject.SetActive(true);
            Debug.Log($"{allPlayers[i].name} is active.");
        }

        // Deactivate
        for (int i = playerCount; i < allPlayers.Count; i++)
        {
            allPlayers[i].gameObject.SetActive(false);
            Debug.Log($"{allPlayers[i].name} is inactive.");
        }
    }

    public List<Player> GetActivePlayers()
    {
        return activePlayers;
    }
}
