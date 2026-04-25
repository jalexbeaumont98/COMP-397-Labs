
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="Game Data Event Channel", menuName = "Events/Game Data Event")]
public class GameDataEventChannel : ScriptableObject
{
    public UnityAction<GameData> OnEventRaised;

    public void RaiseEvent(GameData value)
    {
        if (OnEventRaised == null) return;

        OnEventRaised.Invoke(value);
    }
}