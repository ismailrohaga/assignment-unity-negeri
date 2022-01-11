using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    [SerializeField] private Image effect;
    [SerializeField] private Image filler;
    private bool isAnimationRun;
    private float totalValueOfFiller;
    public enum EffectState { none = 0, small= 1, large = 2 }

    public void Update()
    {
        if (isAnimationRun)
            Animate();
    }

    public void SetEffect(float degreeOfVisibility, EffectState state)
    {
        effect.color = new Color(effect.color.r, effect.color.g, effect.color.b, Mathf.Abs(degreeOfVisibility));

        if (state == EffectState.small)
        {
            effect.transform.localScale = new Vector3(0.6f, 0.6f, 1);
        }
        else if (state == EffectState.large)
        {
            effect.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }
    }

    public void SetEffectToZero()
    {
        effect.color = new Color(effect.color.r, effect.color.g, effect.color.b, 0);
    }

    public void SetFiller(float addNumber)
    {
        totalValueOfFiller = filler.fillAmount + addNumber;
        isAnimationRun = true;

        if (totalValueOfFiller <= 0 || totalValueOfFiller >= 1)
        {
            GameController.Instance.gameOverCard.SetActive(true);
            GameController.Instance.gameCard.SetActive(false);
        }
    }

    private void Animate()
    {
        filler.fillAmount = Mathf.Lerp(filler.fillAmount, totalValueOfFiller, Time.deltaTime * 3);
        if (Mathf.Approximately(filler.fillAmount, totalValueOfFiller))
            isAnimationRun = false;
    }
}
