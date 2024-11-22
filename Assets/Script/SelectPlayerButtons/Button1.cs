using UnityEngine;

public class Button1 : PlayerButton
{
    public override void OnButtonClick()
{
    Debug.Log("Button1 clicked!");
    PlayerPrefs.SetInt("NumPlayers", 2);
    PlayerPrefs.Save();
    
    Debug.Log("Player count set to 2. Loading SampleScene...");
    UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
}


}