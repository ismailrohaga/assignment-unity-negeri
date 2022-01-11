using UnityEngine;
using UnityEngine.UI;

public class PowerCard : MonoBehaviour
{
    [SerializeField] private Image filler;
    private bool isAnimationRun;
    private float totalValueOfFiller;

    public void Update()
    {
        if (isAnimationRun)
            Animate();
    }

    public void SetFiller(float addNumber)
    {
        totalValueOfFiller = filler.fillAmount + addNumber;
        isAnimationRun = true;
    }

    private void Animate()
    {
        filler.fillAmount = Mathf.Lerp(filler.fillAmount, totalValueOfFiller, Time.deltaTime * 3);
        if (Mathf.Approximately(filler.fillAmount, totalValueOfFiller))
            isAnimationRun = false;
    }
}
