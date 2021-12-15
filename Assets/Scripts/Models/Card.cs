using System;

[Serializable]
public class Card
{
    public string[] leftSwipeChoice, rightSwipeChoice;
    public string[] description;
    public string speakerName;
    public int speakerId;
    public int daysOfExecution;
    public Effect leftChoice;
    public Effect rightChoice;
}
