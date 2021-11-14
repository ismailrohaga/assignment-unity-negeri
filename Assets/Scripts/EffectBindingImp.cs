using System;

[Serializable]
public class EffectBindingImp
{
    public GameController.Indicators[] indicatorsWhichChanged;
    public Indicator.effectState[] statesOfChangedIndicators;
    public float[] addedNumbers;
}
