using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;

    public bool Rolled;
    public int randomDiceSide;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = new Sprite[6];
        Rolled = false;
        for (int i = 0; i < 6; i++)
        {
            diceSides[i] = Resources.Load<Sprite>($"Sprites/dicesides/{i + 1}");
            if (diceSides[i] == null)
            {
                Debug.LogError($"Failed to load sprite: Sprites/dicesides/{i + 1}");
            }
        }

        if (diceSides[0] != null)
        {
            rend.sprite = diceSides[0];
        }
        else
        {
            Debug.LogError("diceSides[0] is null, no initial sprite set!");
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(RollDice());
    }

    private IEnumerator RollDice()
    {
         randomDiceSide = 0;

        for (int i = 0; i < 10; i++)
        {
            randomDiceSide = Random.Range(0, diceSides.Length);

            rend.sprite = diceSides[randomDiceSide] != null ? diceSides[randomDiceSide] : diceSides[0];

            yield return new WaitForSeconds(0.05f);
        }

        randomDiceSide = Random.Range(0, diceSides.Length);
        rend.sprite = diceSides[randomDiceSide] != null ? diceSides[randomDiceSide] : diceSides[0];

        Debug.Log("Dice Roll Result: " + (randomDiceSide + 1));
        Rolled = true;

    }
}