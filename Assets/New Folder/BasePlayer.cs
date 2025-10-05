using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] protected int rangeVision;
    [SerializeField] protected int rangeAttack;
    [SerializeField] protected int damage;
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected float attackCooldown;

    public int RangeVision { get => rangeVision; set => rangeVision = value; }
    public int RangeAttack { get => rangeAttack; set => rangeAttack = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Health { get => health; set => health = value; }
    public float Speed { get => speed; set => speed = value; }
    public float AttackCooldown { get => attackCooldown; set => attackCooldown = value; }

    public void Init(int rangeVision, int rangeAttack, int damage, int health, float speed, float attackCooldown)
    {
        this.rangeVision = rangeVision;
        this.rangeAttack = rangeAttack;
        this.damage = damage;
        this.health = health;
        this.speed = speed;
        this.attackCooldown = attackCooldown;
    }
}
