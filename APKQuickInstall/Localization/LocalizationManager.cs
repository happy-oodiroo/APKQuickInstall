using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace APKQuickInstall.Localization;
/// <summary>
/// Localization manager for the multilingual application
/// </summary>
public sealed class LocalizationManager
{
    private static LocalizationManager instance;
    private static readonly object lockObject = new object();

    private Dictionary<string, JsonElement> translations;
    private string currentLanguage;
    private readonly string languagesPath;

    // Supported languages
    private static readonly string[] SupportedLanguages = { "fr", "en", "ar" };
    private const string DefaultLanguage = "en";

    private LocalizationManager()
    {
        languagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages");
        translations = new Dictionary<string, JsonElement>();

        // Detect and load the language
        currentLanguage = DetectSystemLanguage();
        LoadLanguage(currentLanguage);
    }

    /// <summary>
    /// Singleton instance of the manager
    /// </summary>
    public static LocalizationManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new LocalizationManager();
                    }
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Current language
    /// </summary>
    public string CurrentLanguage => currentLanguage;

    /// <summary>
    /// Detects the system language
    /// </summary>
    private string DetectSystemLanguage()
    {
        try
        {
            // Get the system culture
            var systemCulture = CultureInfo.CurrentUICulture;
            var languageCode = systemCulture.TwoLetterISOLanguageName.ToLower();

            // Check if the language is supported
            foreach (var lang in SupportedLanguages)
            {
                if (lang == languageCode)
                {
                    return lang;
                }
            }

            // Fallback to English if not supported
            return DefaultLanguage;
        }
        catch
        {
            return DefaultLanguage;
        }
    }

    /// <summary>
    /// Loads a language file
    /// </summary>
    private void LoadLanguage(string languageCode)
    {
        try
        {
            // Check if the Languages folder exists
            if (!Directory.Exists(languagesPath))
            {
                Directory.CreateDirectory(languagesPath);
                throw new DirectoryNotFoundException($"Languages folder not found: {languagesPath}");
            }

            var filePath = Path.Combine(languagesPath, $"{languageCode}.json");

            // If the file does not exist, try English
            if (!File.Exists(filePath))
            {
                if (languageCode != DefaultLanguage)
                {
                    LoadLanguage(DefaultLanguage);
                    return;
                }
                throw new FileNotFoundException($"Language file not found: {filePath}");
            }

            // Load the JSON file
            string jsonContent = File.ReadAllText(filePath);
            var jsonDocument = JsonDocument.Parse(jsonContent);

            translations.Clear();

            // Convert to dictionary for fast access
            foreach (var property in jsonDocument.RootElement.EnumerateObject())
            {
                translations[property.Name] = property.Value;
            }

            currentLanguage = languageCode;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while loading language '{languageCode}': {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Changes the application language
    /// </summary>
    public void ChangeLanguage(string languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
        {
            throw new ArgumentException("Language code cannot be empty.");
        }

        languageCode = languageCode.ToLower();

        // Check if the language is supported
        bool isSupported = false;
        foreach (var lang in SupportedLanguages)
        {
            if (lang == languageCode)
            {
                isSupported = true;
                break;
            }
        }

        if (!isSupported)
        {
            throw new ArgumentException($"Unsupported language: {languageCode}");
        }

        LoadLanguage(languageCode);
    }

    /// <summary>
    /// Retrieves a translation by key
    /// </summary>
    /// <param name="key">Translation key (e.g.: "Configuration.Title")</param>
    /// <param name="defaultValue">Default value if the key does not exist</param>
    /// <returns>The translation or the default value</returns>
    public string GetString(string key, string defaultValue = null)
    {
        if (string.IsNullOrEmpty(key))
        {
            return defaultValue ?? key;
        }

        try
        {
            var keys = key.Split('.');
            JsonElement current = default;
            bool found = false;

            // Navigate through the JSON hierarchy
            for (int i = 0; i < keys.Length; i++)
            {
                if (i == 0)
                {
                    if (!translations.TryGetValue(keys[i], out current))
                    {
                        return defaultValue ?? key;
                    }
                    found = true;
                }
                else
                {
                    if (current.TryGetProperty(keys[i], out var next))
                    {
                        current = next;
                    }
                    else
                    {
                        return defaultValue ?? key;
                    }
                }
            }

            if (found && current.ValueKind == JsonValueKind.String)
            {
                return current.GetString() ?? defaultValue ?? key;
            }

            return defaultValue ?? key;
        }
        catch
        {
            return defaultValue ?? key;
        }
    }

    /// <summary>
    /// Gets the list of supported languages
    /// </summary>
    public static string[] GetSupportedLanguages()
    {
        return (string[])SupportedLanguages.Clone();
    }

    /// <summary>
    /// Gets the display name of the language
    /// </summary>
    public static string GetLanguageDisplayName(string languageCode)
    {
        return languageCode.ToLower() switch
        {
            "fr" => "Français",
            "en" => "English",
            "ar" => "العربية",
            _ => languageCode.ToUpper()
        };
    }
}
