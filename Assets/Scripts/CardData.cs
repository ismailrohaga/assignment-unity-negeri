using System;
using UnityEngine;

[Serializable]
public class CardData
{
    public string leftSwipeChoice, rightSwipeChoice;
    public string description;
    public string speakerName;
    public int daysOfExecution;
    public Sprite cardFace;
    public EffectBindingImp leftChoice;
    public EffectBindingImp rightChoice;
}
