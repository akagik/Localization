using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string key;
    public int fontSize;

    public void Start()
    {
        Text text = GetComponent<Text>();

        // LocalizationValue value = LocalizationManager.Instance.GetLocalizedValue(key);

        // text.text = value.value;
        // text.font = value.font;

        // text.fontSize = CalcFontSize(value);
    }

}
