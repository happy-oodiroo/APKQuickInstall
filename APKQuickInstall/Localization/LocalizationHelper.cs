using System;
using System.Collections.Generic;
using System.Text;

namespace APKQuickInstall.Localization;
/// <summary>
/// Helper class to facilitate the use of localization in forms
/// </summary>
public static class LocalizationHelper
{
    /// <summary>
    /// Shortcut to get a translation
    /// </summary>
    public static string T(string key, string defaultValue = null)
    {
        return LocalizationManager.Instance.GetString(key, defaultValue).Replace("\n",Environment.NewLine);
    }

    /// <summary>
    /// Gets a translation with formatting
    /// </summary>
    public static string T(string key, params object[] args)
    {
        var text = LocalizationManager.Instance.GetString(key, key).Replace("\n", Environment.NewLine);
        try
        {
            return string.Format(text, args);
        }
        catch
        {
            return text;
        }
    }

    /// <summary>
    /// Applies translations to a form
    /// </summary>
    public static void ApplyLocalization(Form form, string formKey)
    {
        if (form == null) return;

        // Form title
        form.Text = T($"{formKey}.Title");

        // Browse all controls
        ApplyLocalizationToControls(form.Controls, formKey);
    }

    /// <summary>
    /// Applies translations to controls recursively
    /// </summary>
    private static void ApplyLocalizationToControls(Control.ControlCollection controls, string formKey)
    {
        foreach (Control control in controls)
        {
            // If the control has a Tag with a translation key
            if (control.Tag is string translationKey && !string.IsNullOrEmpty(translationKey))
            {
                // If the key starts with ".", it is relative to the form
                if (translationKey.StartsWith("."))
                {
                    translationKey = formKey + translationKey;
                }

                control.Text = T(translationKey);
            }

            // Handle GroupBox
            if (control is GroupBox groupBox && !string.IsNullOrEmpty(groupBox.Name))
            {
                var key = $"{formKey}.{groupBox.Name.Replace("grp", "")}Group";
                groupBox.Text = T(key, groupBox.Text);
            }

            // Handle Labels with naming convention
            if (control is Label label && !string.IsNullOrEmpty(label.Name))
            {
                if (label.Name.StartsWith("lbl") && label.Name.EndsWith("Label"))
                {
                    var key = $"{formKey}.{label.Name.Replace("lbl", "").Replace("Label", "")}Label";
                    label.Text = T(key, label.Text);
                }
            }

            // Handle Buttons with naming convention
            if (control is Button button && !string.IsNullOrEmpty(button.Name))
            {
                if (button.Name.StartsWith("btn") && button.Name.EndsWith("Button"))
                {
                    var key = $"{formKey}.{button.Name.Replace("btn", "").Replace("Button", "")}Button";
                    button.Text = T(key, button.Text);
                }
            }

            // Browse children
            if (control.HasChildren)
            {
                ApplyLocalizationToControls(control.Controls, formKey);
            }
        }
    }

    /// <summary>
    /// Localizes a MessageBox
    /// </summary>
    public static DialogResult ShowMessage(string messageKey, string titleKey,
        MessageBoxButtons buttons = MessageBoxButtons.OK,
        MessageBoxIcon icon = MessageBoxIcon.Information,
        params object[] args)
    {
        var message = args.Length > 0 ? T(messageKey, args) : T(messageKey);
        var title = T(titleKey);
        return MessageBox.Show(message, title, buttons, icon);
    }

    /// <summary>
    /// Localizes a MessageBox with direct text
    /// </summary>
    public static DialogResult ShowLocalizedMessage(string message, string titleKey,
        MessageBoxButtons buttons = MessageBoxButtons.OK,
        MessageBoxIcon icon = MessageBoxIcon.Information)
    {
        var title = T(titleKey);
        return MessageBox.Show(message, title, buttons, icon);
    }

    /// <summary>
    /// Sets a control with a translation key
    /// </summary>
    public static void SetTranslationKey(Control control, string translationKey)
    {
        control.Tag = translationKey;
    }

    /// <summary>
    /// Applies a direct translation to a control
    /// </summary>
    public static void Localize(Control control, string translationKey, params object[] args)
    {
        if (control == null) return;

        if (args.Length > 0)
        {
            control.Text = T(translationKey, args);
        }
        else
        {
            control.Text = T(translationKey);
        }
    }

    /// <summary>
    /// Changes the application language and reloads all open forms
    /// </summary>
    public static void ChangeLanguage(string languageCode)
    {
        LocalizationManager.Instance.ChangeLanguage(languageCode);

        // Reload all open forms
        foreach (Form form in Application.OpenForms)
        {
            // Trigger a reload event if the form implements it
            if (form is ILocalizable localizable)
            {
                localizable.ReloadLocalization();
            }
        }
    }

    /// <summary>
    /// Creates a ComboBox with available languages
    /// </summary>
    public static ComboBox CreateLanguageSelector()
    {
        var comboBox = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList
        };

        var languages = LocalizationManager.GetSupportedLanguages();
        foreach (var lang in languages)
        {
            var item = new LanguageItem
            {
                Code = lang,
                Name = LocalizationManager.GetLanguageDisplayName(lang)
            };
            comboBox.Items.Add(item);

            // Select the current language
            if (lang == LocalizationManager.Instance.CurrentLanguage)
            {
                comboBox.SelectedItem = item;
            }
        }

        comboBox.SelectedIndexChanged += (s, e) =>
        {
            if (comboBox.SelectedItem is LanguageItem item)
            {
                ChangeLanguage(item.Code);
            }
        };

        return comboBox;
    }

    private class LanguageItem
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";

        public override string ToString() => Name;
    }
}

/// <summary>
/// Interface for forms that support localization reload
/// </summary>
public interface ILocalizable
{
    void ReloadLocalization();
}