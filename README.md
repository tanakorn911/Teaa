<<<<<<< HEAD
# Teaa
=======
# Tea Application

แอปพลิเคชันสำหรับสั่งเครื่องดื่มชาและเครื่องดื่มต่างๆ พร้อมระบบการชำระเงิน

## ภาพรวมโปรเจกต์

โปรเจกต์นี้เป็นระบบสั่งเครื่องดื่มที่พัฒนาด้วย .NET 9 และ Blazor โดยมีโครงสร้างแบบ Multi-platform ที่รองรับทั้ง Web Application และ Mobile Application (MAUI)

### โครงสร้างโปรเจกต์

- **Tea** - MAUI Application (iOS, Android, macOS, Windows)
- **Tea.Web** - Blazor Web Application
- **Tea.Shared** - Shared Components และ Services

## ความต้องการระบบ

### Software Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 (17.14 หรือใหม่กว่า) หรือ Visual Studio Code
- สำหรับ Mobile Development:
  - Android SDK (API Level 24+)
  - iOS SDK (iOS 15.0+)
  - macOS SDK (macOS 15.0+)

### Platform Support

- **Android**: API Level 24+
- **iOS**: iOS 15.0+
- **macOS**: macOS 15.0+ (Mac Catalyst)
- **Windows**: Windows 10 version 1809+
- **Web**: ทุกเบราว์เซอร์สมัยใหม่

## การติดตั้งและเรียกใช้

### 1. Clone Repository

```bash
git clone <repository-url>
cd Tea
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. เรียกใช้ Web Application

```bash
cd Tea.Web
dotnet run
```

เข้าใช้งานได้ที่:
- HTTP: http://localhost:5189
- HTTPS: https://localhost:7007

### 4. เรียกใช้ MAUI Application

#### สำหรับ Windows
```bash
cd Tea
dotnet build -f net9.0-windows10.0.19041.0
dotnet run -f net9.0-windows10.0.19041.0
```

#### สำหรับ Android
```bash
cd Tea
dotnet build -f net9.0-android
dotnet run -f net9.0-android
```

#### สำหรับ iOS (ต้องใช้ macOS)
```bash
cd Tea
dotnet build -f net9.0-ios
dotnet run -f net9.0-ios
```

## การพัฒนา

### โครงสร้างโค้ด

#### Tea.Shared
- **Models**: โมเดลข้อมูลสำหรับเครื่องดื่ม, ตะกร้า, การชำระเงิน
- **Services**: Services สำหรับจัดการข้อมูลและ Business Logic
- **Components**: Blazor Components ที่ใช้ร่วมกัน
- **Pages**: หน้าเว็บต่างๆ (เมนู, ตะกร้า, การชำระเงิน)

#### คุณสมบัติหลัก
- ระบบเมนูเครื่องดื่มแบบหลายภาษา (ไทย/อังกฤษ)
- ระบบตะกร้าสินค้า
- ระบบการชำระเงินผ่าน QR Code
- รองรับการใช้งานบนหลายแพลตฟอร์ม

### การ Build

#### Build ทั้งหมด
```bash
dotnet build
```

#### Build สำหรับ Platform เฉพาะ
```bash
# Web Application
dotnet build Tea.Web

# Android
dotnet build Tea -f net9.0-android

# iOS
dotnet build Tea -f net9.0-ios

# Windows
dotnet build Tea -f net9.0-windows10.0.19041.0
```

### การ Publish

#### Web Application
```bash
cd Tea.Web
dotnet publish -c Release -o ./publish
```

#### MAUI Application
```bash
cd Tea
# Android APK
dotnet publish -f net9.0-android -c Release

# iOS App
dotnet publish -f net9.0-ios -c Release

# Windows App
dotnet publish -f net9.0-windows10.0.19041.0 -c Release
```

## การกำหนดค่า

### appsettings.json
ไฟล์ appsettings.json ที่พบในโปรเจกต์มีดังนี้:

#### ไฟล์หลักที่ต้องแก้ไข:

**1. `/Tea.Web/appsettings.json` (Web Application)**

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Omise": {
    "TestPublicKey": "pkey_test_xxxxxxxxxxxxxxxxx",
    "TestSecretKey": "skey_test_xxxxxxxxxxxxxxxxx"
  }
}
```

**2. `/Tea/appsettings.json` (MAUI Application)**

```json
{
  "Omise": {
    "TestPublicKey": "pkey_test_xxxxxxxxxxxxxxxxx",
    "TestSecretKey": "skey_test_xxxxxxxxxxxxxxxxx"
  }
}
```

แก้ไขไฟล์ `appsettings.json` ในแต่ละโปรเจกต์เพื่อกำหนดค่าที่จำเป็น เช่น:
- Payment Gateway Settings (Omise Keys)
- 
## การแก้ไขปัญหา

### ปัญหาที่พบบ่อย

1. **Build Error**: ตรวจสอบว่าติดตั้ง .NET 9 SDK แล้ว
2. **Android Build Error**: ตรวจสอบ Android SDK และเครื่องมือที่จำเป็น
3. **iOS Build Error**: ต้องใช้ macOS และติดตั้ง Xcode

### Logs และ Debugging

- Web Application: ดู logs ใน Developer Tools ของเบราว์เซอร์
- MAUI Application: ใช้ Visual Studio Debugger

## การมีส่วนร่วม

1. Fork repository
2. สร้าง feature branch
3. Commit การเปลี่ยนแปลง
4. Push ไปยัง branch
5. สร้าง Pull Request
>>>>>>> 6205248 (Add project files.)
