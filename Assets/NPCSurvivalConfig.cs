using UnityEngine;

// Атрибут CreateAssetMenu позволяет создавать файл настроек через контекстное меню Unity
[CreateAssetMenu(fileName = "NewNPCConfig", menuName = "Survival/NPC Config")]
public class NPCSurvivalConfig : ScriptableObject
{
    [Header("Неизменяемые базовые лимиты")]
    [Tooltip("Максимальный запас здоровья")]
    [SerializeField] private float maxHealth = 100f;

    [Tooltip("Максимальный уровень сытости")]
    [SerializeField] private float maxHunger = 100f;

    [Tooltip("Максимальный уровень гидратации (жажды)")]
    [SerializeField] private float maxThirst = 100f;

    // Публичные свойства только для чтения (Read-Only)
    public float MaxHealth => maxHealth;
    public float MaxHunger => maxHunger;
    public float MaxThirst => maxThirst;
}