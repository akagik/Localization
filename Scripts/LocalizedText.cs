using UnityEngine;
using UnityEngine.UI;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
#if ODIN_INSPECTOR
    [ValidateInput("FoundLocalizationManager","LocalizationManager がシーン内に見つかりません。")]
    [ValidateInput("IsValidKey","不正な key です。")]
#endif
    public string key;
    public bool setOnStart = true;

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

    public string text
    {
        get
        {
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

#if UNITY_EDITOR && ODIN_INSPECTOR
    private bool IsValidKey(string key)
    {
        var manager = FindObjectOfType<LocalizationManager>();

        if (manager == null) {
            return false;
        }
        return LocalizationManager.Instance.ContainsKey(key);
    }

    private bool FoundLocalizationManager(string key)
    {
        var manager = FindObjectOfType<LocalizationManager>();
        return manager != null;
    }

    [Button]
    public void UpdateTextButton()
    {
        var manager = FindObjectOfType<LocalizationManager>();

        if (manager == null) {
            Debug.LogError("LocalizationManager がシーン内に存在しません");
            return;
        }

        if (manager.setDefaultLanguageOnAwake) {
            manager.SetLanguage(manager.defaultLanguage);
        }
        textUI.text = manager.Get(key);
    }
#endif

}
