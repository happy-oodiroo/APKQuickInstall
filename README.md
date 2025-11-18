# APK Quick Install

<div align="center">

![APK Quick Install Logo](APKQuickInstall.Setup/Images/Square44x44Logo.altform-lightunplated_targetsize-256.png)

**A powerful Windows application to install and manage Android APK files via ADB**

[![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows)](https://www.microsoft.com/windows)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![GitHub Release](https://img.shields.io/github/v/release/yourusername/adb-apk-installer)](https://github.com/yourusername/adb-apk-installer/releases)

[Features](#-features) • [Download](#-download) • [Installation](#-installation) • [Usage](#-usage) • [Building](#-building-from-source) • [Contributing](#-contributing)

</div>

---

## 📖 Overview

**APK Quick Install** is a modern, user-friendly Windows Forms application built with .NET 9 that simplifies the process of installing and managing Android applications (APK files) on your Android devices using Android Debug Bridge (ADB).

### Why APK Quick Install?

- 🚀 **Easy to use** - No command-line knowledge required
- 🔌 **Multiple connection methods** - USB and WiFi/Network support
- 🌍 **Multi-language** - English, French, and Arabic interface
- 🎯 **Smart ADB detection** - Automatically finds or installs ADB
- 📊 **Activity log** - Real-time installation progress and status
- 🔒 **Privacy-focused** - No data collection, everything stays local
- 🎨 **Modern UI** - Clean and intuitive Windows Forms interface

---

## ✨ Features

### Core Functionality
- ✅ **APK Installation** - Install Android applications on connected devices
- ✅ **APK Uninstallation** - Remove applications by package name
- ✅ **USB Connection** - Standard USB debugging connection
- ✅ **Network Connection** - Connect to devices over WiFi (ADB over TCP/IP)
- ✅ **Multi-device Support** - Manage multiple connected devices simultaneously

### Advanced Features
- 🔄 **Auto ADB Configuration** - Detects existing ADB or downloads/installs automatically
- 📝 **Connection History** - Remembers network device connections
- ⚙️ **Installation Options** - Reinstall mode, grant permissions automatically
- 📈 **Progress Tracking** - Real-time installation progress with percentage
- 📋 **Activity Journal** - Detailed log of all operations with timestamps

### User Experience
- 🌐 **Multi-language Support** - Interface available in:
  - 🇬🇧 English
  - 🇫🇷 Français (French)
  - 🇹🇳 العربية (Arabic)
- 🎨 **Modern Design** - Clean, professional Windows Forms UI
- ⚡ **Fast & Lightweight** - Minimal resource usage
- 🔔 **Clear Feedback** - Status messages and notifications for all actions

---

## 📸 Screenshots

<div align="center">

### Main Interface
![Main Interface](assets/screenshots/main-interface.png)

### ADB Configuration
![ADB Configuration](assets/screenshots/adb-config.png)

### Network Connection
![Network Connection](assets/screenshots/network-connection.png)

### Multi-language Support
![Languages](assets/screenshots/languages.png)

</div>

---

## 💾 Download

### Latest Release

**[⬇️ Download Latest Version](https://github.com/yourusername/adb-apk-installer/releases/latest)**

### System Requirements

| Component | Requirement |
|-----------|-------------|
| **Operating System** | Windows 10 (64-bit) or later |
| **Framework** | .NET 9.0 Runtime or SDK |
| **RAM** | 4 GB minimum |
| **Storage** | 500 MB free space |
| **Internet** | Required for initial ADB download only |

### Download Options

- **📦 Portable Version** - No installation required, just extract and run
- **🔧 Installer (MSI)** - Full installation with Start Menu integration
- **🏪 Microsoft Store** - Coming soon!

---

## 🚀 Installation

### Option 1: Portable Version (Recommended)

1. **Download** the latest release ZIP file
2. **Extract** to your preferred location
3. **Run** `AdbApkInstaller.exe`
4. The app will guide you through ADB setup on first launch

### Option 2: Build from Source

See [Building from Source](#-building-from-source) section below.

### First Launch Setup

On first launch, the application will:

1. **Check for ADB** - Searches for existing Android Debug Bridge installation
2. **Offer Download** - If not found, automatically downloads ADB from Google
3. **Configuration** - Saves ADB path for future use
4. **Ready to Use** - Proceed to main interface

---

## 📱 Usage

### Connecting Your Android Device

#### USB Connection

1. **Enable Developer Mode** on your Android device:
   ```
   Settings → About Phone → Tap "Build Number" 7 times
   ```

2. **Enable USB Debugging**:
   ```
   Settings → Developer Options → USB Debugging (ON)
   ```

3. **Connect** your device via USB cable

4. **Authorize** the computer when prompted on your device

5. **Refresh** device list in the application

#### WiFi/Network Connection

1. **Connect device via USB first** (one-time setup)

2. **Enable ADB over TCP/IP**:
   ```bash
   adb tcpip 5555
   ```

3. **Find your device IP**:
   ```
   Settings → About → Status → IP Address
   ```

4. In the app: Click **"🌐 Network..."** → Enter IP address and port (5555)

5. Click **"Connect"**

### Installing APK Files

1. **Select Device** from the dropdown list
2. **Click "📁 Browse..."** and select your APK file
3. **(Optional)** Check installation options:
   - ☑️ Reinstall (replace existing app)
   - ☑️ Grant all permissions
4. **Click "📦 Install APK"**
5. **Wait** for installation to complete
6. **Confirmation** will appear when done

### Uninstalling Applications

1. **Ensure device is connected**
2. **Click "🗑️ Uninstall an app"**
3. **Enter package name** (e.g., `com.example.app`)
4. **Confirm** uninstallation

> **Tip:** To find package names, use: `adb shell pm list packages`

### Changing Language

1. **Menu** → 🌍 Language
2. **Select** your preferred language:
   - English
   - Français
   - العربية
3. Interface updates immediately

---

## 🛠️ Building from Source

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Git](https://git-scm.com/)
- Visual Studio 2022 (optional, recommended)

### Clone Repository

```bash
git clone https://github.com/yourusername/adb-apk-installer.git
cd adb-apk-installer
```

### Restore Dependencies

```bash
dotnet restore
```

### Build

#### Debug Build
```bash
dotnet build --configuration Debug
```

#### Release Build
```bash
dotnet build --configuration Release
```

### Run

```bash
cd bin/Debug/net10.0-windows
./AdbApkInstaller.exe
```

## 🔧 Technologies Used

- **[.NET 10.0](https://dotnet.microsoft.com/)** - Application framework
- **Windows Forms** - User interface with High DPI support
- **[AdvancedSharpAdbClient](https://github.com/SharpAdb/AdvancedSharpAdbClient)** - ADB .NET library
- **[Android Debug Bridge (ADB)](https://developer.android.com/tools/adb)** - Android device communication
- **JSON** - Configuration and localization storage

---

## 🌍 Localization

The application supports multiple languages with automatic system language detection.

### Supported Languages

| Language | Code | Status |
|----------|------|--------|
| English | `en` | ✅ Complete |
| Français | `fr` | ✅ Complete |
| العربية | `ar` | ✅ Complete |

### Adding New Languages

1. Create a new JSON file in `Languages/` folder (e.g., `es.json` for Spanish)
2. Copy structure from `en.json` and translate all strings
3. Add language code to `SupportedLanguages` in `LocalizationManager.cs`
4. Add display name in `GetLanguageDisplayName()` method

**Contributions for new languages are welcome!**

---

## 🤝 Contributing

We welcome contributions from the community! Here's how you can help:

### Ways to Contribute

- 🐛 **Report Bugs** - [Open an issue](https://github.com/happy-oodiroo/APKQuickInstall/issues)
- 💡 **Suggest Features** - Share your ideas
- 🌍 **Add Translations** - Help translate to new languages
- 📝 **Improve Documentation** - Fix typos, add examples
- 💻 **Submit Code** - Fix bugs or add features

### Development Guidelines

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/amazing-feature`)
3. **Commit** your changes (`git commit -m 'Add amazing feature'`)
4. **Push** to the branch (`git push origin feature/amazing-feature`)
5. **Open** a Pull Request

### Code Style

- Follow C# coding conventions
- Use meaningful variable names
- Add comments for complex logic
- Keep methods focused and concise
- Write clean, readable code

---

## 🐛 Bug Reports

Found a bug? Please [open an issue](https://github.com/happy-oodiroo/APKQuickInstall/issues) with:

- **Clear title** describing the problem
- **Steps to reproduce** the issue
- **Expected behavior** vs. actual behavior
- **Screenshots** if applicable
- **System information** (Windows version, .NET version)
- **Log output** from the application

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

### Third-Party Licenses

- **AdvancedSharpAdbClient** - [Apache License 2.0](https://github.com/SharpAdb/AdvancedSharpAdbClient/blob/main/LICENSE)
- **Android Debug Bridge (ADB)** - [Android Software Development Kit License](https://developer.android.com/studio/terms)

---

## 🔒 Privacy

**APK Quick Install respects your privacy:**

- ❌ No data collection
- ❌ No analytics or tracking
- ❌ No internet connection (except ADB download)
- ✅ Everything stays on your device
- ✅ Open source - verify yourself!

Read our full [Privacy Policy](PrivacyPolicy.en.md).

---

## 📞 Support

### Getting Help

- 📖 **Documentation** - Check the [Wiki](https://github.com/happy-oodiroo/APKQuickInstall/wiki)
- 💬 **Discussions** - [GitHub Discussions](https://github.com/happy-oodiroo/APKQuickInstall/discussions)
- 🐛 **Bug Reports** - [GitHub Issues](https://github.com/happy-oodiroo/APKQuickInstall/issues)
- 📧 **Email** - sassi_said@live.fr

### Useful Resources

- [Android Debug Bridge (ADB) Documentation](https://developer.android.com/tools/adb)
- [Enable USB Debugging Guide](https://developer.android.com/studio/debug/dev-options)
- [Testing Documentation](TESTING.md)
- [Privacy Policy](PrivacyPolicy.en.md)

---

## 🗺️ Roadmap

### Planned Features

- [ ] Batch APK installation (multiple files)
- [ ] APK information viewer (permissions, size, version)
- [ ] Application backup/restore
- [ ] Dark/Light theme toggle
- [ ] Drag-and-drop APK installation
- [ ] Recent APK files history
- [ ] Device file explorer
- [ ] Screen mirroring integration
- [ ] Auto-update functionality

### Future Enhancements

- [ ] More language translations (Spanish, German, etc.)
- [ ] Custom ADB commands
- [ ] Device management features
- [ ] Installation profiles/presets

**Vote for features or suggest new ones in [Discussions](https://github.com/happy-oodiroo/APKQuickInstall/discussions)!**

---

## 🙏 Acknowledgments

Special thanks to:

- **Google/Android** - For Android Debug Bridge
- **AdvancedSharpAdbClient contributors** - For the excellent ADB library
- **Microsoft** - For .NET and Windows Forms
- **All contributors** - For making this project better
- **You** - For using and supporting this project!

---

## 📊 Statistics

![GitHub stars](https://img.shields.io/github/stars/happy-oodiroo/APKQuickInstall?style=social)
![GitHub forks](https://img.shields.io/github/forks/happy-oodiroo/APKQuickInstall?style=social)
![GitHub issues](https://img.shields.io/github/issues/happy-oodiroo/APKQuickInstall)
![GitHub pull requests](https://img.shields.io/github/issues-pr/happy-oodiroo/APKQuickInstall)
![GitHub downloads](https://img.shields.io/github/downloads/happy-oodiroo/APKQuickInstall/total)

---

## 📜 Changelog

See [CHANGELOG.md](CHANGELOG.md) for a detailed history of changes.

---

## ⭐ Star History

[![Star History Chart](https://api.star-history.com/svg?repos=happy-oodiroo/APKQuickInstall&type=Date)](https://star-history.com/#happy-oodiroo/APKQuickInstall&Date)

---

<div align="center">

**Made with ❤️ by [SAÏD SASSI](https://github.com/happy-oodiroo)**

If you find this project useful, please consider giving it a ⭐!

[Report Bug](https://github.com/happy-oodiroo/APKQuickInstall/issues) • [Request Feature](https://github.com/happy-oodiroo/APKQuickInstall/discussions) • [Discussions](https://github.com/happy-oodiroo/APKQuickInstall/discussions)

© 2025 APK Quick Install. All rights reserved.

</div>