using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public Image image;
    [SerializeField] public CardControl cardControl;
    [SerializeField] public PowerCard powerCard;
    [SerializeField] public AudioSource audioSourceAvailable;
    [SerializeField] public AudioSource audioSourceUnavailable;
    private float timeRemaining = 10;
    private float freezeTime = 0;
    private float freezeCooldown = 0;
    private bool timerIsRunning = false;
    private bool isFreezeTime = false;
    private bool isCooldownTime = true;

    public void Start()
    {
        ResumeTime();
    }

    public void Update()
    {
        RunTime();
        RunFreezeTime();
        RunFreezeCooldown();
    }

    void RunTime()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                PostTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                cardControl.RandomPick();
                ResetTime();
            }
        }
    }

    void RunFreezeTime()
    {
        if (isFreezeTime)
        {
            if (freezeTime > 0)
            {
                freezeTime -= Time.deltaTime;
            }
            else
            {
                freezeTime = 0;
                freezeCooldown = 0;
                isFreezeTime = false;
                isCooldownTime = true;
                ResumeTime();
            }
        }
    }

    void RunFreezeCooldown()
    {
        if (isCooldownTime)
        {
            if (freezeCooldown < 120)
            {
                freezeCooldown += Time.deltaTime;
                powerCard.SetFiller(freezeCooldown / 21000);
            }
            else
            {
                freezeCooldown = 120;
                audioSourceAvailable.Play();
                isCooldownTime = false;
            }
        }
    }

    void PostTime(float value)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, value / 10);
    }

    public void ResetTime()
    {
        if (!isFreezeTime)
        {
            timeRemaining = 10;
            ResumeTime();
        }
    }

    public void ResumeTime()
    {
        timerIsRunning = true;
    }

    public void PauseTime()
    {
        timerIsRunning = false;
    }

    public void FreezeTime()
    {
        if (freezeCooldown == 120)
        {
            PauseTime();
            isFreezeTime = true;
            freezeTime = 30;
            powerCard.SetFiller(-1);
        }
        else
        {
            audioSourceUnavailable.Play();
        }
    }
}