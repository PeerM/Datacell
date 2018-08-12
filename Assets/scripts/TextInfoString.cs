using UnityEngine;
using UnityEngine.UI;

public class TextInfoString:MonoBehaviour
{
    public Text valueText;

    public void set_current(string value)
    {
        valueText.text = value;
    }
}