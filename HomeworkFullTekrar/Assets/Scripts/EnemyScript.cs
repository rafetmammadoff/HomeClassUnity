using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f, 17f)]
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletTransform;
    [SerializeField] TextMeshPro Health;
    float dis=10;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        InvokeRepeating("Fire", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position);
        dis = Vector3.Distance(Player.transform.position, transform.position);
        if (dis>3)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        

    }
    private void Fire()
    {
        if (dis<5)
        {
            Destroy(Instantiate(Bullet, BulletTransform.position, transform.rotation), 3);
        }
    }
}
