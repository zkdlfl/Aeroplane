using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerButton : MonoBehaviour
{
    public abstract void OnButtonClick();

    protected void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
             button.onClick.AddListener(() => OnButtonClick());
        }
        else
        {
            Debug.LogError("Button component is missing!");
        }
    }
}
