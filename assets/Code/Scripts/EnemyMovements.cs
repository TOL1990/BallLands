using UnityEngine;
using System.Collections;

public class EnemyMovements : MonoBehaviour {

    private NavMeshAgent nav;
    private Transform playerPosition;
    //
    public float speed = 1f;            // Скорость движение Вражины 

    Vector3 movement;                   // Вектор направления движения персонажа
    Rigidbody enemyRigidbody;          // Обращение к физике игрока

    // PlayerHealth playerHealth; //Думаю игроку нужно будет прикрутить здоровье

    // Use this for initialization
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        enemyRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        // определяем оси координат
    //    float h = Input.GetAxisRaw("Horizontal");
      //  float v = Input.GetAxisRaw("Vertical");

        // Движение игрока по сцене
       // Move();
        nav.SetDestination(playerPosition.position);
        // Поворот игрока по направлению к курсору
        Turning();

    }
    //void Move()
    //{


    //    // Определяем скорость движение вражины, как 1 единица расстояния за 1 секунду (не кадр) 
    //    movement = movement.normalized * speed * Time.deltaTime;

    //    // Движение вражины от позиции в данный момент+передвижение
    //    enemyRigidbody.MovePosition(transform.position + movement);
    //}

    void Turning()
    {
         // Вектор между врагом и игроком(минус)текущая позиция
   
            Vector3 enemyToPlayer = - (playerPosition.position - transform.position);

        //нужно подкрутить у чтобы глаз точно смотрел на игрока
            

            // Создаем quaternion (rotation) который отвечает за вектор enemy-player
            Quaternion newRotation = Quaternion.LookRotation(enemyToPlayer);
            
            // Значение  player's rotation к значению new rotation.
            enemyRigidbody.MoveRotation(newRotation);
        }
    }