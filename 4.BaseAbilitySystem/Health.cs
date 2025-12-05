using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth = 100;

    // ReSharper disable Unity.PerformanceAnalysis
    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log($"{gameObject.name} get {amount} damage, current health: {currentHealth}");
    }
}