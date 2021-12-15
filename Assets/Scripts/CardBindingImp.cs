using System;
using UnityEngine;

[Serializable]
public class CardBindingImp
{
    [SerializeField] private string[] leftSwipeChoice, rightSwipeChoice;
    [SerializeField] private string[] description;
    [SerializeField] private string speakerName;
    [SerializeField] private int daysOfExecution;
    [SerializeField] private RuntimeAnimatorController cardAnimator;
    public Effect leftChoice;
    public Effect rightChoice;

    public CardBindingImp(Card values, RuntimeAnimatorController cardAnimator)
    {
        this.leftSwipeChoice = values.leftSwipeChoice;
        this.rightSwipeChoice = values.rightSwipeChoice;
        this.description = values.description;
        this.speakerName = values.speakerName;
        this.daysOfExecution = values.daysOfExecution;
        this.cardAnimator = cardAnimator;
        this.leftChoice = values.leftChoice;
        this.rightChoice = values.rightChoice;
    }

    public void BindCard(CardView cardView, int langIndex)
    {
        cardView.leftSwipeChoice.text = leftSwipeChoice[langIndex];
        cardView.rightSwipeChoice.text = rightSwipeChoice[langIndex];
        cardView.description.text = description[langIndex];
        cardView.speakerName.text = speakerName;
        cardView.animator.runtimeAnimatorController = cardAnimator;
    }

    public int GetDaysOfExecution() { return daysOfExecution; }
}
