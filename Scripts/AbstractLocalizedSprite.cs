using UnityEngine;
using UnityEngine.UI;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

public abstract class AbstractLocalizedSprite : MonoBehaviour
{
#if ODIN_INSPECTOR
    [ValidateInput("FoundLocalizationManager", "LocalizationManager がシーン内に見つかりません。")]
    [ValidateInput("IsValidKey", "不正な key です。")]
#endif
    public string key;
    public bool setOnStart = true;

    public abstract Sprite sprite
    {
        get;
    }

    public void Start()
    {
        if (setOnStart)
        {
            if (!LocalizationManager.Instance.ContainsKey(key))
            {
                Debug.LogError("指定のキーは存在しない: " + key + ", GameObject.name: " + gameObject.name);
                return;
            }
            UpdateSprite();
        }
    }

    public abstract void UpdateSprite();

#if UNITY_EDITOR && ODIN_INSPECTOR
    private bool IsValidKey(string key)
    {
        var manager = FindObjectOfType<LocalizationManager>();

        if (manager == null)
        {
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
    public void UpdateSpriteButton()
    {
        var manager = FindObjectOfType<LocalizationManager>();

        if (manager == null)
        {
            Debug.LogError("LocalizationManager がシーン内に存在しません");
            return;
        }

        if (manager.setDefaultLanguageOnAwake)
        {
            manager.SetLanguage(manager.defaultLanguage);
        }
        UpdateSprite();
    }
#endif
}
