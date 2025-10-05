using UnityEngine;

public class Skeleton : BaseEnemy, ItakeDamage, IAttack, IDropItem
{
    [SerializeField]private Player player;

    public void Update()
    {
        if (player == null) return;

        if (Vector2.Distance(transform.position, player.transform.position) < rangeVision)
        {
            Vector2 dir = (player.transform.position - transform.position).normalized;
            transform.position += (Vector3)(dir * speed * Time.deltaTime);
        }
        Atacar();  
    }
    public void Atacar()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < rangeAttack)
        {
            print("Esqueleto Ataca");
            player.RecibirDaño(damage);
        }
    }

    public void DropItem()
    {
        if (Health == 0)
        {
            DropItemOnDeath = true;
            print("El Enemigo Dropeo un item");
        }
    }

    public void RecibirDaño(int cantidad)
    {
        Health = Mathf.Max(0, Health - cantidad);
        if(Health == 0)
        {
            Debug.Log("Enemigo muerto");
            DropItem();
            Destroy(gameObject);
        }
    }
}
