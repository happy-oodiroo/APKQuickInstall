# Privacy Policy for APK Quick Install

**Effective Date:** November 17, 2025  
**Last Updated:** November 17, 2025

---

## Introduction

This Privacy Policy describes how APK Quick Install collects, uses, and protects your information when you use our Windows application. We are committed to protecting your privacy and ensuring transparency about our data practices.

By using APK Quick Install, you agree to the collection and use of information in accordance with this Privacy Policy.

---

## Information We Collect

### 1. Information We DO NOT Collect

**APK Quick Install does NOT collect, transmit, or share any of the following:**

- ❌ Personal identification information (name, email, phone number)
- ❌ Location data
- ❌ Usage analytics or statistics
- ❌ Crash reports or diagnostic data
- ❌ Device identifiers (IMEI, serial numbers, etc.)
- ❌ APK files or their contents
- ❌ List of installed applications on your Android device
- ❌ Any data from your Android device

### 2. Information Stored Locally

The App stores the following information **locally on your computer only**:

#### a) ADB Configuration (`config.json`)
- **What:** Path to Android Debug Bridge (adb.exe), ADB version, last verification date
- **Purpose:** To remember ADB installation location and avoid re-configuration
- **Storage:** Local file in application directory
- **Sharing:** Never transmitted or shared

#### b) Network Connection History (`network_history.json`)
- **What:** IP addresses and ports of Android devices you have connected to via network
- **Purpose:** To provide quick access to previously connected devices
- **Storage:** Local file in application directory
- **Sharing:** Never transmitted or shared
- **User Control:** Can be cleared by deleting the file

#### c) Language Preference
- **What:** Selected interface language (English, French, or Arabic)
- **Purpose:** To maintain your language preference across sessions
- **Storage:** Stored in configuration file
- **Sharing:** Never transmitted or shared

---

## How We Use Information

All information stored by APK Quick Install is used **exclusively for the application's functionality**:

1. **ADB Configuration**: To locate and execute Android Debug Bridge without requiring re-configuration
2. **Network History**: To provide convenience when reconnecting to previously connected Android devices
3. **Language Preference**: To display the interface in your preferred language

**We do NOT:**
- Send any data to external servers
- Use analytics or tracking services
- Share data with third parties
- Collect telemetry or usage statistics
- Monitor your activities

---

## Data Storage and Security

### Local Storage Only

All data is stored **locally on your computer** in the application's installation directory. No data is transmitted over the internet except when:

1. **Downloading Android Debug Bridge (ADB)**: On first launch, if ADB is not detected, the App downloads the official Android platform-tools package from Google's servers (`https://dl.google.com`). This is a one-time download for installation purposes.

### Security Measures

- **No Remote Servers**: The App does not connect to any remote servers operated by us
- **No Cloud Storage**: All configuration is stored locally
- **File Permissions**: Configuration files are stored with standard user permissions
- **No Encryption Required**: Since no sensitive personal data is collected, encryption of local files is not necessary

### User Control

You have complete control over all stored data:
- Configuration files can be deleted at any time
- Uninstalling the App removes all associated files
- No residual data is left on external servers (because none exists)

---

## Third-Party Services

### Android Debug Bridge (ADB)

The App uses **Android Debug Bridge (ADB)**, an official tool from Google/Android, to communicate with Android devices. 

- **Provider:** Google LLC
- **Purpose:** To install APK files and manage Android applications
- **Data Transfer:** Communication occurs directly between your computer and your Android device over USB or local network
- **Privacy:** Refer to [Google's Privacy Policy](https://policies.google.com/privacy) and [Android Debug Bridge documentation](https://developer.android.com/tools/adb)

**Important:** When you connect an Android device, ADB facilitates local communication. No data passes through our servers or any third-party servers.

### AdvancedSharpAdbClient Library

The App uses the open-source **AdvancedSharpAdbClient** library to interface with ADB.

- **Provider:** Open-source community
- **Purpose:** To provide .NET interface to ADB
- **License:** [View License](https://github.com/SharpAdb/AdvancedSharpAdbClient/blob/main/LICENSE)
- **Privacy:** Library operates locally; no data collection

---

## Children's Privacy

APK Quick Install does not knowingly collect any information from anyone, including children under the age of 13. The App is a development tool intended for users who are managing Android applications.

---

## Your Rights and Choices

### Data Access and Deletion

Since all data is stored locally on your device:

- **Access**: You can view all stored data by opening the configuration files in the application directory
- **Deletion**: You can delete any configuration file at any time
- **Portability**: Configuration files are in standard JSON format and can be backed up or transferred

### Opt-Out Options

- **Network History**: Delete `network_history.json` to clear connection history
- **Language Preference**: Change at any time via the application menu
- **Complete Removal**: Uninstall the application to remove all data

---

## Changes to Android Device

When you use APK Quick Install to install or uninstall applications on your Android device:

- **Local Operation**: All operations are performed locally between your computer and device
- **User Authorization**: Android requires you to explicitly authorize USB debugging
- **Device Control**: You maintain complete control over what is installed or removed
- **No Tracking**: We do not track which applications you install or remove

---

## International Data Transfers

**Not Applicable**: Since APK Quick Install does not transmit any data to external servers, there are no international data transfers.

All data remains on your local computer.

---

## Updates to This Privacy Policy

We may update this Privacy Policy from time to time. We will notify you of any changes by:

1. Posting the new Privacy Policy on this page
2. Updating the "Last Updated" date at the top
3. (If distributed via Microsoft Store) Updating the app listing

We encourage you to review this Privacy Policy periodically for any changes.

**Continued use of the App after changes constitutes acceptance of the updated Privacy Policy.**

---

## Data Retention

Since all data is stored locally:

- **Retention Period**: Data persists until you delete it or uninstall the application
- **Automatic Deletion**: Uninstalling the App removes all configuration files
- **User Control**: You can manually delete configuration files at any time

---

## Legal Basis for Processing (GDPR)

For users in the European Economic Area (EEA):

- **Legal Basis**: Legitimate interest in providing application functionality
- **Data Minimization**: We only store the minimum data necessary for the App to function
- **No Personal Data**: The App does not process personal data as defined by GDPR
- **Local Processing**: All processing occurs locally on your device

---

## California Privacy Rights (CCPA)

For California residents:

- **No Sale of Data**: We do not sell personal information
- **No Collection**: We do not collect personal information as defined by CCPA
- **Access and Deletion**: You have full control over locally stored data

---

## Contact Information

If you have any questions, concerns, or requests regarding this Privacy Policy or our data practices, please contact us:

**Email:** [sassi_said@live.fr]  
**GitHub:** [https://github.com/happy-oodiroo/APKQuickInstall)  
**Issue Tracker:** [https://github.com/happy-oodiroo/APKQuickInstall/issues)

**Response Time:** We aim to respond to all inquiries within 21 business days.

---

## Consent

By using APK Quick Install, you hereby consent to this Privacy Policy and agree to its terms.

---

## Open Source

APK Quick Install is open-source software. You can review the complete source code to verify our privacy claims:

**Repository:** [https://github.com/yourusername/adb-apk-installer](https://github.com/yourusername/adb-apk-installer)

---

## Summary

**In simple terms:**

✅ **We collect ZERO personal information**  
✅ **All data stays on your computer**  
✅ **No analytics or tracking**  
✅ **No ads or third-party services**  
✅ **Open-source and transparent**  
✅ **You have complete control**

---

## Acknowledgments

This Privacy Policy complies with:

- General Data Protection Regulation (GDPR)
- California Consumer Privacy Act (CCPA)
- Microsoft Store requirements
- Best practices for privacy-respecting software

---

**Version:** 1.0  
**Language:** English

---

*This Privacy Policy was last updated on November 17, 2025. For the most current version, please visit our GitHub repository or the Microsoft Store listing.*