using UnityEngine;

public class EnemyControlers : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public float distanceToDestroy = 1;
    public float Vida = 8;  
    void Start()
    {
        Player = GameObject.Find("Orquito");
    }


    void Update()
    {
        Enemigo();

    }
    public void Enemigo()
    {

        Vector3 dir = (Player.transform.position - transform.position).normalized;
        transform.position += dir * Speed * Time.deltaTime;

        if (Vector3.Distance(Player.gameObject.transform.position, transform.position) < distanceToDestroy)
        {
            Player.GetComponent<OrcControler>().health--;
            Destroy(gameObject);
        }
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
