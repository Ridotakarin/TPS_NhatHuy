using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform healthBarFill;
    public Transform playerCamera; // Kéo thả đối tượng Camera của người chơi vào đây
    public float maxHealth = 100f;
    private float currentHealth;

    // Biến để làm mượt hiệu ứng
    private float targetScaleX;
    public float lerpSpeed = 5f;

    void Start()
    {
        currentHealth = maxHealth;
        targetScaleX = 1f; // Máu đầy ban đầu
    }

    void Update()
    {
        // Làm mượt việc thay đổi scale của thanh máu
        Vector3 newScale = healthBarFill.localScale;
        newScale.x = Mathf.Lerp(newScale.x, targetScaleX, Time.deltaTime * lerpSpeed);
        healthBarFill.localScale = newScale;

        // Thanh máu luôn quay về phía camera của người chơi
        if (playerCamera != null)
        {
            transform.LookAt(transform.position + playerCamera.forward);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);

        // Cập nhật giá trị scale mục tiêu
        targetScaleX = currentHealth / maxHealth;
    }
}