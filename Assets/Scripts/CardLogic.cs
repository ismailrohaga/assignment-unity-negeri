using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardLogic : MonoBehaviour
{
    private DeckManager deckManager;
    [SerializeField] private CardBindingImp cardData;
    [SerializeField] private bool isGameOverCard;
    public Text leftSwipeChoice, rightSwipeChoice;
    public Text description;
    public Text speakerName;
    public Image cardFace;

    private void Start()
    {
        deckManager = DeckManager.Instance;

        if (!isGameOverCard)
            cardData = deckManager.GetNextCard();
        cardData.BindCard(this);
    }

    public void ConfirmChoice(bool isChoiceLeft)
    {
        if (!isGameOverCard)
        {
            if (isChoiceLeft)
                deckManager.UpdateIndicator(cardData.leftChoice);
            else
                deckManager.UpdateIndicator(cardData.rightChoice);

            deckManager.gameState.IncreaseDaysInPower(cardData.GetDaysOfExecution());

            cardData = deckManager.GetNextCard();
            cardData.BindCard(this);
            deckManager.SetChangeSighOfIndicatorsToZero();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateVisibility(float degreeOfVisibility)
    {
        if (!isGameOverCard)
        {
            UpdateChoicesVisibility(degreeOfVisibility);
            UpdateIndicatorsVisibility(degreeOfVisibility);
        }
    }

    private void UpdateChoicesVisibility(float degreeOfVisibility)
    {
        if (degreeOfVisibility <= 0)
        {
            rightSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, Mathf.Abs(degreeOfVisibility));
            leftSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, 0);
        }
        else
        {
            leftSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, degreeOfVisibility); ;
            rightSwipeChoice.color = new Color(leftSwipeChoice.color.r, leftSwipeChoice.color.g, leftSwipeChoice.color.b, 0);
        }
    }

    private void UpdateIndicatorsVisibility(float degreeOfVisibility)
    {
        deckManager.SetChangeSignOfIndicators(degreeOfVisibility, cardData.leftChoice, cardData.rightChoice);
    }
}
