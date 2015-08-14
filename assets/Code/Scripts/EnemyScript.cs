using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private NavMeshAgent nav;
    private Transform player;
   // PlayerHealth playerHealth; //Думаю игроку нужно будет прикрутить здоровье

	// Use this for initialization
	void Start () {
		nav = GetComponent	<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
       // if(1==1)
            nav.SetDestination(player.position);
	}
}
