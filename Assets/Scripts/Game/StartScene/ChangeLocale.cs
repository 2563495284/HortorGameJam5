using UnityEngine;
using UnityEngine.Localization.Settings;

public class ChangeLocale : MonoBehaviour
{
    public void SetLocale(string code)
    {
        var selectedLocale = LocalizationSettings.AvailableLocales.Locales.Find(locale => locale.Identifier.Code == code);
        if (selectedLocale != null)
        {
            LocalizationSettings.SelectedLocale = selectedLocale;
        }
        else
        {
            Debug.LogError("Locale not found: " + code);
        }
    }
}