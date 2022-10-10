using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class playermove : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f, 17f)]
    [SerializeField] float speed = 5f;
    float rotationX = 0f;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletTransform;
    [SerializeField] TextMeshPro Health;
    [SerializeField] GameObject Enemy;
    public float healthX = 100f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("add", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(x, 0, z);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX -= mouseY;
        GameObject.Find("Main Camera").transform.localRotation=Quaternion.Euler(rotationX,0,0);
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        Health.text=healthX.ToString();

        
    }
    private void Fire()
    {
        Destroy(Instantiate(Bullet, BulletTransform.position, transform.rotation),3);
    }

    public void add()
    {
        Instantiate(Enemy, new Vector3(Random.Range(-45f, 45f), 0, Random.Range(-45f, 45f)), Quaternion.identity);

    }

}
