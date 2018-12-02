using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LocalizationTable : ScriptableObject
{
    public LocalizationData[] rows;

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Kohei/LocalizationTable")]
    public static void CreateInstance()
    {
        var obj = ScriptableObject.CreateInstance<LocalizationTable>();
        Generic.ScriptableObjectCreator.Create<LocalizationTable>(obj,name: "NewLocalizationTable");
    }
#endif
}