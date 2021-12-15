using System;

[Serializable]
public class Effect
{
    public GameController.Indicators[] indicatorsWhichChanged;
    public Indicator.EffectState[] statesOfChangedIndicators;
    public float[] addedNumbers;
}
