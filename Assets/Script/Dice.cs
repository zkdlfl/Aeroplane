using System.Collections;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public TextMeshProUGUI diceCaption;

    public bool Rolled;
    public int randomDiceSide;
    private GameManager gameManager;
    private string currentPlayer;  // Store the current player's name
    private bool hasRolledSecondTime; //avoid second roll after getting a 6
    private bool hasMoved; //make sure the second roll happens after the first move

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = new Sprite[6];
        Rolled = false;

        // Set the default caption
        diceCaption.text = "Waiting for rolling...";

        // Load dice sides
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

        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        // Get the current player 
        currentPlayer = gameManager.GetCurrentPlayerName();
        diceCaption.text = $"{currentPlayer}'s turn";

        // Start the dice roll 
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

        // Final dice result
        randomDiceSide = Random.Range(0, diceSides.Length);
        rend.sprite = diceSides[randomDiceSide] != null ? diceSides[randomDiceSide] : diceSides[0];

        Debug.Log("Dice Roll Result: " + (randomDiceSide + 1));
        Rolled = true;

        if (randomDiceSide == 5&& !hasRolledSecondTime&& !hasMoved)
        {
            diceCaption.text = $" {currentPlayer}, Roll again!";
            Debug.Log($"{currentPlayer} rolled a 6. Allowing a second roll.");
        }
             else if (randomDiceSide == 5 && !hasMoved)
        {
            yield return null;
        }
             else if (randomDiceSide == 5 && hasMoved)
        {
            diceCaption.text = $"{currentPlayer}, Roll again!";
            Debug.Log($"{currentPlayer} rolled a 6. Allowing a second roll.");
            hasRolledSecondTime = true;

            yield return new WaitForSeconds(1.5f);

            // Roll again
            StartCoroutine(RollDice());
        }
        else
        {
            // End turn, next player
            diceCaption.text = $"{currentPlayer}'s turn is over.";
            hasRolledSecondTime = false;
            gameManager.NextTurn();
        }
    }
}

