using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace APKQuickInstall.Configuration;

/// <summary>
/// Classe pour gérer la configuration d'ADB
/// </summary>
public class AdbConfiguration
{
    /// <summary>
    /// Chemin complet vers adb.exe
    /// </summary>
    public string AdbPath { get; set; } = string.Empty;

    /// <summary>
    /// Version d'ADB détectée
    /// </summary>
    public string AdbVersion { get; set; } = string.Empty;

    /// <summary>
    /// Date de la dernière vérification
    /// </summary>
    public DateTime LastVerified { get; set; } = DateTime.MinValue;

    private static readonly string ConfigFilePath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "config.json"
    );

    /// <summary>
    /// Sauvegarde la configuration dans un fichier JSON
    /// </summary>
    public void Save()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(ConfigFilePath, jsonString);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erreur lors de la sauvegarde de la configuration: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Charge la configuration depuis le fichier JSON
    /// </summary>
    /// <returns>Configuration chargée ou null si le fichier n'existe pas</returns>
    public static AdbConfiguration Load()
    {
        try
        {
            if (!File.Exists(ConfigFilePath))
            {
                return null;
            }

            string jsonString = File.ReadAllText(ConfigFilePath);
            return JsonSerializer.Deserialize<AdbConfiguration>(jsonString);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erreur lors du chargement de la configuration: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Vérifie si une configuration existe
    /// </summary>
    public static bool ConfigExists()
    {
        return File.Exists(ConfigFilePath);
    }

    /// <summary>
    /// Supprime le fichier de configuration
    /// </summary>
    public static void Delete()
    {
        try
        {
            if (File.Exists(ConfigFilePath))
            {
                File.Delete(ConfigFilePath);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Erreur lors de la suppression de la configuration: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Vérifie si la configuration est valide
    /// </summary>
    public bool IsValid()
    {
        return !string.IsNullOrEmpty(AdbPath) &&
               File.Exists(AdbPath) &&
               !string.IsNullOrEmpty(AdbVersion);
    }
}