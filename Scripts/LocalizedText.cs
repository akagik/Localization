using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
    public string key;
    public LocalizationTable table;
    public bool setOnStart;

    private Text _textUI;
    public Text textUI
    {
        get
        {
            if(_textUI == null)
            {
                _textUI = GetComponent<Text>();
            }
            return _textUI;
        }
    }

    public string text {
        get {
            UpdateText();
            return textUI.text;
        }
    }

    public void Start()
    {
        if(setOnStart)
        {
            UpdateText();
        }
    }

    public void UpdateText()
    {
        textUI.text = LocalizationManager.Instance.Get(key);
    }
}
