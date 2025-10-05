using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected string ID;
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
}
