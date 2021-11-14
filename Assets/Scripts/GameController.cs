using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Indicator[] indicators;
    [SerializeField] private TextAsset json;
    public static GameController Instance { get; set; }
    public GameInfoState gameState;
    public GameObject gameOverCard;
    public GameObject gameCard;
    private Scenario scenario;
    private int lastIndex = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        scenario = JsonUtility.FromJson<Scenario>(json.text);
    }

    public enum Indicators { Military = 0, People = 1, Economy = 2 }

    public CardBindingImp GetNextCard()
    {
        //Debug.Log("card index: " + lastIndex);
        CardBindingImp card = new CardBindingImp(scenario.data[lastIndex]);
        if (lastIndex < scenario.data.Length - 1)
            lastIndex++;
        else
            lastIndex = 0;

        return card;
    }

    public void SetChangeSignOfIndicators(
        float degreeOfVisibility, 
        EffectBindingImp leftChoice, 
        EffectBindingImp rightChoice
        )
    {
        GameController.Indicators[] rightIndicators = rightChoice.indicatorsWhichChanged;
        Indicator.effectState[] rightStates = rightChoice.statesOfChangedIndicators;

        GameController.Indicators[] leftIndicators = leftChoice.indicatorsWhichChanged;
        Indicator.effectState[] leftStates = leftChoice.statesOfChangedIndicators;

        if (degreeOfVisibility <= 0)
        {
            for (int i = 0; i < rightIndicators.Length; i++)
            {
                this.indicators[(int)rightIndicators[i]].SetEffect(degreeOfVisibility, rightStates[i]);
            }

            if (degreeOfVisibility < 0)
                for (int i = 0; i < leftIndicators.Length; i++)
                    if (leftIndicators[i] != rightIndicators[i])
                        this.indicators[(int)leftIndicators[i]].SetEffect(0, leftStates[i]);
        }

        if (degreeOfVisibility >= 0)
        {
            for (int i = 0; i < leftIndicators.Length; i++)
            {
                this.indicators[(int)leftIndicators[i]].SetEffect(degreeOfVisibility, leftStates[i]);
            }

            if (degreeOfVisibility > 0)
                for (int i = 0; i < rightIndicators.Length; i++)
                    if (leftIndicators[i] != rightIndicators[i])
                        this.indicators[(int)rightIndicators[i]].SetEffect(0, rightStates[i]);
        }
    }

    public void UpdateIndicator(EffectBindingImp confirmedChoice)
    {
        GameController.Indicators[] indicators = confirmedChoice.indicatorsWhichChanged;
        float[] addedNumbers = confirmedChoice.addedNumbers;

        for (int i = 0; i < indicators.Length; i++)
        {
            this.indicators[(int)indicators[i]].SetFiller(addedNumbers[i]);
        }
    }

    public void SetChangeSighOfIndicatorsToZero()
    {
        for (int  i = 0; i < indicators.Length; i++)
        {
            indicators[i].SetEffectToZero();
        }
    }
}
