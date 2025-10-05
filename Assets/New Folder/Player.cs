using UnityEngine;

public class Player : BasePlayer, ItakeDamage, IAttack, IConsumible, IAplicarBuff
{
    public Vector2 dir;
    public void AplicarBuff()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Random.Range(0, 100)==10)//10% de probabilidad de que el buff falle
            {
                print("El buff fallo");
                return;
            }
            print("Buff aplicado");
            Damage = Mathf.Min(100, Damage + 20);//aumenta el daño del jugador en 20 hasta un maximo de 100
            
        }
    }

    public void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("Jugador ataca");
            Collider2D[] enemigos = Physics2D.OverlapCircleAll(transform.position, rangeAttack);//rango de ataque
            foreach (Collider2D enemigo in enemigos)//verifica si hay enemigos en el rango de ataque
            {
                if (enemigo.tag == "Enemigo")
                {
                    print("Enemigo alcanzado");
                    enemigo.GetComponent<ItakeDamage>().RecibirDaño(Damage); 
                }
            }
        }
    }

    public void Consumir()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {

            health = Mathf.Min(100, health + 20); //aumenta la vida del jugador en 20 hasta un maximo de 100
            print("Vida actual: " + health);
        }
    }

    public void RecibirDaño(int cantidad)
    {
        Health = Mathf.Max(0, Health - cantidad);
        if (Health == 0)
        {
            print("Jugador muerto");
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        Atacar();
        Consumir();
        AplicarBuff();
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            dir = Vector2.down;
        }
    }
}
