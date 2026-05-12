<a name="readme-top"></a>

<p align="center">
  <img src="README_assets/Banner.png" width="100%" alt="TPS Project Banner"/>
</p>

<h1 align="center">🔫 Advanced TPS Gameplay Framework</h1>

<p align="center">
  <img src="https://img.shields.io/badge/Creator-Nhat%20Huy-red?style=for-the-badge&logo=github" />
  <img src="https://img.shields.io/badge/Engine-Unity-black?style=for-the-badge&logo=unity" />
  <img src="https://img.shields.io/badge/Architecture-Modular-blue?style=for-the-badge" />
</p>

---

## 👋 About This Project

Welcome to **TPS_NhatHuy**. This project showcases a high-fidelity **Third-Person Shooter framework** built from the ground up. 

I focused on creating a responsive multi-speed movement system and a tactical combat loop where positioning and resource management (keys and health) are vital to progressing through the mission.

---

## 🎬 Gameplay Gallery

This section demonstrates the core systems scripted within this project:

### 1. Multi-Tiered Locomotion
The movement script handles three distinct states: **Walking** (Stealth/Precision), **Running** (Standard), and **Sprinting** (Fast Travel/Evasion).
<p align="center">
  <img src="README_assets/movement_demo.gif" width="90%" />
</p>

### 2. Tactical Combat & Weapon Swapping
You can switch between a precision **Rifle** and a heavy **Plasma Gun**. Note: Fire logic is locked until the player enters the "Aim" state.
<p align="center">
  <img src="README_assets/combat_demo.gif" width="90%" />
</p>

### 3. Mission Objectives & Survival
The environment features interactive **Medical Kits** for survival and a **Key-Access system** required to unlock the final Boss Room.
<p align="center">
  <img src="README_assets/items_key.gif" width="90%" />
</p>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

## ⚔️ Arsenal & Equipment

I engineered the weapons to provide two completely different tactical feels:

| Weapon | Logic Type | Style | Feature |
| :--- | :--- | :--- | :--- |
| **Rifle ** | Raycast | Precision | Fast fire rate; best for medium range. |
| **Plasma Gun ** | Projectile | Heavy / AoE | Grenade-style arc; high damage energy bolts. |

* **Combat Constraint:** Integrated a "Ready-to-Fire" check requiring the player to hold the **Aim** button before the trigger can be pulled.

---

## ⚙️ Core Mechanics (The Code)

### 🧠 Locomotion Logic
The character's velocity is calculated based on three input modifiers:
* **Ctrl (Hold):** Walk (Low speed for tight spaces).
* **Move (Basic):** Jog/Run (Standard exploration).
* **Shift (Hold):** Sprint (High-speed movement).

### 🔑 Mission System
- **Keycard System:** A Boolean-based verification script. The Boss Room door remains locked until the `hasKey` event is triggered.
- **Interactive Loot:** Medical kits use a trigger-based collision system to restore HP and update the UI dynamically.

---

## 🚀 Installation & Controls

### ⚙️ Quick Start
1. **Clone:** `git clone https://github.com/Ridotakarin/TPS_NhatHuy.git`
2. **Open:** Unity 2022.3 LTS or higher.
3. **Play:** Load `Assets/Scenes/Main.unity`.

### ⌨️ Controls
- **WASD:** Move (Run by default)
- **Left Ctrl (Hold):** Walk
- **Left Shift (Hold):** Sprint
- **Right Click (Hold):** **AIM** (Required to shoot)
- **Left Click:** Fire Weapon
- **Key 1 / 2:** Switch between Rifle and Plasma Gun
- **F / E:** Pick up Key / Medical Kit

---

## 👤 Contact the Creator
**Lâm Nhật Huy** - Gameplay Programmer
* **LinkedIn:** [Huy Lâm](https://www.linkedin.com/in/huy-lâm-3405142a5)
* **GitHub Portfolio:** [Ridotakarin](https://github.com/Ridotakarin)

---
<p align="center">
  If you find this framework helpful, please give it a ⭐!
</p>
