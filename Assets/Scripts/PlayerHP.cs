using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP < 0)currentHP = 0;
    }

    public void Heal(int heal)
    {
        currentHP += heal;
        if( currentHP > maxHP) currentHP = maxHP;
    }
}
