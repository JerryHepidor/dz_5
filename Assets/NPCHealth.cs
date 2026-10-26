using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    [Header("Ссылка на неизменяемый конфиг")]
    [SerializeField] private NPCSurvivalConfig config;

    [Header("Текущие изменяемые показатели")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentHunger;
    [SerializeField] private float currentThirst;

    // Свойства для чтения текущих значений другими скриптами (например, интерфейсом)
    public float CurrentHealth => currentHealth;
    public float CurrentHunger => currentHunger;
    public float CurrentThirst => currentThirst;

    private void Awake()
    {
        // Инициализация стартовых значений из конфига при создании объекта
        if (config != null)
        {
            currentHealth = config.MaxHealth;
            currentHunger = config.MaxHunger;
            currentThirst = config.MaxThirst;
        }
        else
        {
            Debug.LogWarning($"[NPCHealth] Не назначен NPCSurvivalConfig на объекте {gameObject.name}");
        }
    }

    #region Здоровье (Health)

    // Увеличение здоровья (лечение)
    public void IncreaseHealth(float amount)
    {
        if (amount <= 0f || config == null) return;
        currentHealth = Mathf.Min(currentHealth + amount, config.MaxHealth);
    }

    // Уменьшение здоровья (урон)
    public void DecreaseHealth(float amount)
    {
        if (amount <= 0f) return;
        currentHealth = Mathf.Max(currentHealth - amount, 0f);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    #endregion

    #region Сытость (Hunger)

    // Увеличение сытости (кормление)
    public void IncreaseHunger(float amount)
    {
        if (amount <= 0f || config == null) return;
        currentHunger = Mathf.Min(currentHunger + amount, config.MaxHunger);
    }

    // Уменьшение сытости (голодание)
    public void DecreaseHunger(float amount)
    {
        if (amount <= 0f) return;
        currentHunger = Mathf.Max(currentHunger - amount, 0f);
    }

    #endregion

    #region Жажда (Thirst)

    // Увеличение уровня воды (питье)
    public void IncreaseThirst(float amount)
    {
        if (amount <= 0f || config == null) return;
        currentThirst = Mathf.Min(currentThirst + amount, config.MaxThirst);
    }

    // Уменьшение уровня воды (обезвоживание)
    public void DecreaseThirst(float amount)
    {
        if (amount <= 0f) return;
        currentThirst = Mathf.Max(currentThirst - amount, 0f);
    }

    #endregion

    private void Die()
    {
        // Логика гибели NPC (анимация, удаление с сцены, дроп лута)
        Debug.Log($"{gameObject.name} погиб.");
    }
}