using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;
    void Start()
    {
        Player=GameObject.Find("Player");
        Enemy=GameObject.FindGameObjectWithTag("Enemy");


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.forward * speed * Time.deltaTime;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<playermove>().healthX -= 5;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Enemy.GetComponent<EnemyScript>().HealthC -= 10;
            Destroy(Enemy);
            Player.GetComponent<playermove>().add();
        }
    }
}
