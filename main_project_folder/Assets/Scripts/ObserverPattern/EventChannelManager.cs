using System.Collections.Generic;
using UnityEngine;

public class EventChannelManager : PersistentSingleton<EventChannelManager>
{
    [SerializeField] public VoidEventChannel voidEvent;
    [SerializeField] public FloatEventChannel floatEvent;
    [SerializeField] public GameDataEventChannel gameEvent;

}
