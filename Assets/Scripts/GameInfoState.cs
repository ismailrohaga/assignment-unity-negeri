using UnityEngine;
using UnityEngine.UI;

public class GameInfoState : MonoBehaviour
{
    private int reignDuration = 1;
    [SerializeField] private Text daysInPowerUI;
    public void IncreaseDaysInPower(int addedDays)
    {
        reignDuration += addedDays;
        daysInPowerUI.text = reignDuration + " days in power";
    }
}