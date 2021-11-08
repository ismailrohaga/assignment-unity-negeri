using System;
using UnityEngine;

[Serializable]
public class CardBindingImp : MonoBehaviour
{
    [SerializeField] private string leftSwipeChoice, rightSwipeChoice;
    [SerializeField] private string description;
    [SerializeField] private string speakerName;
    [SerializeField] private int daysOfExecution;
    [SerializeField] private Sprite cardFace;
    public EffectBindingImp leftChoice;
    public EffectBindingImp rightChoice;
    public CardBindingImp(CardData values)
    {
        this.leftSwipeChoice = values.leftSwipeChoice;
        this.rightSwipeChoice = values.rightSwipeChoice;
        this.description = values.description;
        this.speakerName = values.speakerName;
        this.daysOfExecution = values.daysOfExecution;
        this.cardFace = values.cardFace;
        this.leftChoice = values.leftChoice;
        this.rightChoice = values.rightChoice;
    }
    public void BindCard(CardLogic cardLogic)
    {
        cardLogic.leftSwipeChoice.text = leftSwipeChoice;
        cardLogic.rightSwipeChoice.text = rightSwipeChoice;
        cardLogic.description.text = description;
        cardLogic.speakerName.text = speakerName;

        //todo: find a way to serialize sprite
        //cardLogic.cardFace.sprite = cardFace;
    }
    public int GetDaysOfExecution() { return daysOfExecution; }
}
