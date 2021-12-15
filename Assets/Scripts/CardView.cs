using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardView : MonoBehaviour
{
    private GameController gameController;
    private CardBindingImp cardBinding;
    [SerializeField] private int language;
    [SerializeField] private bool isGameOverCard;
    public Text leftSwipeChoice, rightSwipeChoice;
    public Text description;
    public Text speakerName;
    public Animator animator;

    public void Start()
    {
        gameController = GameController.Instance;

        if (!isGameOverCard)
            cardBinding = gameController.GetNextCard();
        cardBinding.BindCard(this, language);
    }

    public void ConfirmChoice(bool isChoiceLeft)
    {
        if (!isGameOverCard)
        {
            if (isChoiceLeft)
                gameController.UpdateIndicator(cardBinding.leftChoice);
            else
                gameController.UpdateIndicator(cardBinding.rightChoice);

            gameController.gameState.IncreaseDaysInPower(cardBinding.GetDaysOfExecution());
            cardBinding = gameController.GetNextCard();
            cardBinding.BindCard(this, language);
            gameController.SetChangeSighOfIndicatorsToZero();
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
        gameController.SetChangeSignOfIndicators(degreeOfVisibility, cardBinding.leftChoice, cardBinding.rightChoice);
    }
}
