using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;

namespace APKQuickInstall.Core
{
    /// <summary>
    /// Classe pour gérer ADB (détection, validation, téléchargement)
    /// </summary>
    public class AdbManager
    {
        private const string PlatformToolsUrl = "https://dl.google.com/android/repository/platform-tools-latest-windows.zip";
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Détecte ADB sur le système
        /// </summary>
        /// <returns>Chemin vers adb.exe ou null si non trouvé</returns>
        public static string DetectAdb()
        {
            // 1. Chercher dans la variable PATH
            var pathVariable = Environment.GetEnvironmentVariable("PATH");
            if (!string.IsNullOrEmpty(pathVariable))
            {
                var paths = pathVariable.Split(';');
                foreach (var path in paths)
                {
                    var adbPath = Path.Combine(path.Trim(), "adb.exe");
                    if (File.Exists(adbPath))
                    {
                        return adbPath;
                    }
                }
            }

            // 2. Chercher dans Android SDK (emplacements courants)
            var androidSdkPaths = new[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Android", "Sdk", "platform-tools", "adb.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "AppData", "Local", "Android", "Sdk", "platform-tools", "adb.exe"),
                Path.Combine("C:", "Android", "sdk", "platform-tools", "adb.exe")
            };

            foreach (var path in androidSdkPaths)
            {
                if (File.Exists(path))
                {
                    return path;
                }
            }

            // 3. Chercher dans le dossier de l'application
            var localAdbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "platform-tools", "adb.exe");
            if (File.Exists(localAdbPath))
            {
                return localAdbPath;
            }

            return null;
        }

        /// <summary>
        /// Vérifie si ADB fonctionne et retourne sa version
        /// </summary>
        /// <param name="adbPath">Chemin vers adb.exe</param>
        /// <returns>Version d'ADB ou null si erreur</returns>
        public static string GetAdbVersion(string adbPath)
        {
            if (!File.Exists(adbPath))
            {
                return null;
            }

            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = adbPath,
                    Arguments = "version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(processInfo);
                if (process == null)
                {
                    return null;
                }

                process.WaitForExit(5000); // Timeout de 5 secondes

                string output = process.StandardOutput.ReadToEnd();

                // Extraire la version (ex: "Android Debug Bridge version 1.0.41")
                var lines = output.Split('\n');
                var versionLine = lines.FirstOrDefault(l => l.Contains("Android Debug Bridge version"));

                if (versionLine != null)
                {
                    var parts = versionLine.Split(new[] { "version" }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        return parts[1].Trim();
                    }
                }

                return output.Trim();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Télécharge et installe les platform-tools
        /// </summary>
        /// <param name="progress">Callback pour le progrès du téléchargement (0-100)</param>
        /// <returns>Chemin vers adb.exe installé</returns>
        public static async Task<string> DownloadAndInstallAdb(IProgress<int> progress = null)
        {
            var tempZipPath = Path.Combine(Path.GetTempPath(), "platform-tools.zip");
            var installPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "platform-tools");

            try
            {
                // Télécharger le fichier ZIP
                progress?.Report(0);

                using (var response = await httpClient.GetAsync(PlatformToolsUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var canReportProgress = totalBytes != -1;

                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(tempZipPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    {
                        var buffer = new byte[8192];
                        long totalRead = 0;
                        int bytesRead;

                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalRead += bytesRead;

                            if (canReportProgress)
                            {
                                var progressPercentage = (int)((totalRead * 50) / totalBytes);
                                progress?.Report(progressPercentage);
                            }
                        }
                    }
                }

                progress?.Report(50);

                // Supprimer le dossier existant si présent
                if (Directory.Exists(installPath))
                {
                    Directory.Delete(installPath, true);
                }

                // Extraire le ZIP
                ZipFile.ExtractToDirectory(tempZipPath, AppDomain.CurrentDomain.BaseDirectory);
                progress?.Report(100);

                // Supprimer le fichier temporaire
                File.Delete(tempZipPath);

                var adbPath = Path.Combine(installPath, "adb.exe");

                if (!File.Exists(adbPath))
                {
                    throw new Exception("L'installation a échoué. adb.exe n'a pas été trouvé.");
                }

                return adbPath;
            }
            catch (Exception ex)
            {
                // Nettoyer en cas d'erreur
                if (File.Exists(tempZipPath))
                {
                    File.Delete(tempZipPath);
                }

                throw new Exception($"Erreur lors du téléchargement/installation d'ADB: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Vérifie si ADB est valide (existe et fonctionne)
        /// </summary>
        public static bool ValidateAdb(string adbPath)
        {
            if (string.IsNullOrEmpty(adbPath) || !File.Exists(adbPath))
            {
                return false;
            }

            var version = GetAdbVersion(adbPath);
            return !string.IsNullOrEmpty(version);
        }
    }
}
