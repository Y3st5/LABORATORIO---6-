
using UnityEngine;


public class OrcControler : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject enemy;
    public float atackRange;
    public float AtackDegree = 90;

    public float health = 10;
    public int contador = 0;

    public Vector2 dir;

    public Transform PistolTransform;
    public GameObject bulletPrefab;
    public GameManager gameManager;
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        radio();
        Movimiento();
        RevisarMuerte();
        Disparo();
    }
    public void radio()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            Collider2D[] enemigos = Physics2D.OverlapCircleAll(transform.position, atackRange);//Detecta todos los colliders en el rango
           // DrawVectors.Instance.DrawCircle(transform.position, atackRange, Color.cyan);//Dibuja el circulo del rango de ataque
            foreach (Collider2D enemigo in enemigos)//Recorre todos los colliders detectados
            {
                print(enemigos.Length);//Imprime la cantidad de colliders detectados


                if (enemigo.tag == "Enemigo")//Si el collider es un enemigo
                {
                    Vector2 enemyDir = (enemigo.transform.position - transform.position).normalized;
                    float producto = Vector2.Dot(enemyDir, dir);

                    float toRadiasn = Mathf.Acos(producto);

                    float toDegrees = toRadiasn * Mathf.Rad2Deg;

                    print("GRADOS " + toDegrees);

                    if (toDegrees <= AtackDegree)
                    {
                        Destroy(enemigo.gameObject);
                        contador++;
                    }

                }


            }
            print("Enemigos eliminados: " + contador);
        }
    }

    public void Disparo()
    {
        Vector2 mousePos = Input.mousePosition;//: Obtener la posición del mouse en pantalla

        Vector3 GamePos = Camera.main.ScreenToWorldPoint(mousePos);//: Convertir la posición del mouse a coordenadas del mundo

        if (Input.GetMouseButtonDown(0))
        {
            GamePos.z = 0; //: Asegurarse de que la posición Z sea 0 para 2D
            Vector3 dir = (GamePos - PistolTransform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, PistolTransform.position, Quaternion.identity);
            bullet.transform.up = dir;
        }


    }



    private void RevisarMuerte()
    {
        if (health <= 0)
        {
            Debug.Log("¡Orquito ha muerto!");
            //- reiniciar la escena o cargar el checkpoint Load)=
           // gameManager.LoadGame();
            contador = 0;
        }
        if (gameObject == null) return;
    }

    public void Movimiento()
    {
        // Cambia la velocidad según Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else
        {
            speed = 3f;
        }

        // Movimiento en cualquier caso
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