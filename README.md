# 🔫 Third-Person Shooter (TPS) - Nhat Huy Project

![Unity](https://img.shields.io/badge/Unity-2022.3+-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-Language-blue?style=for-the-badge&logo=csharp)
![Status](https://img.shields.io/badge/Status-In--Development-orange?style=for-the-badge)

Dự án phát triển cơ chế điều khiển nhân vật góc nhìn thứ ba (TPS) tập trung vào tính chân thực của chuyển động, hệ thống chiến đấu Raycast và tối ưu hóa hiệu suất thông qua các Design Patterns.

---

## 📸 Demo & Hình ảnh
*(Bạn hãy thay link ảnh thực tế của bạn vào các dấu ngoặc bên dưới)*

| Main Gameplay | Aiming System |
| :---: | :---: |
| ![Gameplay 1](https://via.placeholder.com/400x225.png?text=Main+Locomotion) | ![Gameplay 2](https://via.placeholder.com/400x225.png?text=Combat+Mechanics) |

---

## 🕹️ Cơ chế & Tính năng kỹ thuật (Mechanics)

### 1. Hệ thống di chuyển (Character Locomotion)
* **Movement:** Sử dụng **Character Controller** kết hợp với **Animator Blend Trees** để tạo chuyển động 8 hướng mượt mà.
* **States:** Quản lý trạng thái bằng **State Machine** (Idle, Walk, Run, Aim, Shoot, Reload).
* **Camera:** Tích hợp **Cinemachine** hỗ trợ xoay camera tự do và tự động chuyển góc nhìn (Shoulder Offset) khi ngắm bắn.

### 2. Hệ thống chiến đấu (Combat System)
* **Raycast Shooting:** Xử lý bắn súng dựa trên Raycasting để đảm bảo độ chính xác tuyệt đối theo tâm ngắm.
* **Recoil & Precision:** Lập trình độ giật (Recoil) của súng và độ lệch tâm (Weapon Spread) dựa trên trạng thái di chuyển của nhân vật.
* **VFX/SFX:** Tích hợp Muzzle Flash, Bullet Tracer và hệ thống decal vết đạn trên các bề mặt vật lý khác nhau.

### 3. Tối ưu hóa mã nguồn (Technical Highlights)
* **Object Pooling:** Áp dụng cho đạn, vỏ đạn và các hiệu ứng va chạm để giảm thiểu rác (GC) và duy trì FPS ổn định.
* **Observer Pattern:** Sử dụng C# Events để tách biệt (Decoupling) giữa logic chiến đấu và hệ thống UI (Máu, Đạn).
* **Scriptable Objects:** Lưu trữ thông số vũ khí (Sát thương, Tốc độ bắn, Thay đạn) giúp dễ dàng cân bằng game mà không cần sửa code.

---

## 🛠️ Công nghệ sử dụng
* **Engine:** Unity 2022.3 (LTS)
* **Scripting:** C# (Object-Oriented Programming)
* **Version Control:** Git & GitHub Desktop
* **Assets:** Starter Assets (Third Person Controller), Mixamo Animations.

---

## 🚀 Cách chạy dự án
1. **Clone Repo:**
   ```bash
   git clone [https://github.com/Ridotakarin/TPS_NhatHuy.git](https://github.com/Ridotakarin/TPS_NhatHuy.git)
