using UnityEngine;

public class Button3 : PlayerButton
{
    public override void OnButtonClick()
{
    Debug.Log("Button3 clicked!");
    PlayerPrefs.SetInt("NumPlayers", 4);
    PlayerPrefs.Save();
    
    Debug.Log("Player count set to 4. Loading SampleScene...");
    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
}


}