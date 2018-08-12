using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TextInfo : InfoBehavior
    {
        public Text valueText;

        public override void set_max(int value)
        {
            // Ignore
        }

        public override void set_current(int value)
        {
            valueText.text = value.ToString();
        }
    }
}