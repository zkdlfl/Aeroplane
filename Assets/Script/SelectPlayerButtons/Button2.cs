using UnityEngine;

public class Button2 : PlayerButton
{
    public override void OnButtonClick()
{
    Debug.Log("Button2 clicked!");
    PlayerPrefs.SetInt("NumPlayers", 3);
    PlayerPrefs.Save();
    
    Debug.Log("Player count set to 3. Loading SampleScene...");
    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
}


}