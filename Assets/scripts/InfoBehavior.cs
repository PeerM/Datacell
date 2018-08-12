using DefaultNamespace;
using UnityEngine;

public abstract class InfoBehavior : MonoBehaviour, InfoDisplay
{
    public abstract void set_max(int value);
    public abstract void set_current(int value);
}