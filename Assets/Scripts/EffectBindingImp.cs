using System;

[Serializable]
public class EffectBindingImp
{
    public DeckManager.Indicators[] indicatorsWhichChanged;
    public Indicator.effectState[] statesOfChangedIndicators;
    public float[] addedNumbers;
}
