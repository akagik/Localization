using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocalizationManager
{
    public bool isReady { get; private set; }

    public SystemLanguage DefaultLang = SystemLanguage.English;

    public bool enforce;
    public SystemLanguage enforceLanguage;

    public SystemLanguage useLanguage
    {
        get
        {
            if (enforce)
            {
                return enforceLanguage;
            }
            else
            {
                return Application.systemLanguage;
            }
        }
    }

    // [ReadOnly]
    public SystemLanguage usingLanguage;

    private Dictionary<string, string> localizedText;

    private string missingTextString = "Localized text not found";

    public static string GetCode(SystemLanguage lang)
    {
        switch (lang)
        {
            case SystemLanguage.Japanese:
                return "ja";
            case SystemLanguage.Korean:
                return "ko";
            case SystemLanguage.Chinese:
            case SystemLanguage.ChineseSimplified:
            case SystemLanguage.ChineseTraditional:
                return "zh";
            case SystemLanguage.English:
            default:
                return "en";
        }
    }

    public void LoadLocalizedText(SystemLanguage lang)
    {
        this.usingLanguage = lang;

        localizedText = new Dictionary<string, string>();

        // foreach (LocalizationKey key in Enum.GetValues(typeof(LocalizationKey)))
        // {
        //     localizedText.Add(keyStr, value);
        // }

        isReady = true;
        Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries : " + lang);
    }

    public bool Contains(string key)
    {
        checkReady();
        return localizedText.ContainsKey(key);
    }

    public string Get(string key)
    {
        checkReady();

        if (localizedText.ContainsKey(key))
        {
            return localizedText[key];
        }
        return null;
    }

    private void checkReady()
    {
        if (!isReady)
        {
            isReady = true;
            LoadLocalizedText(useLanguage);
        }
    }
}