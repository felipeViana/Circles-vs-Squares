using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timeToShoot = 1f;
    private float timeAfterLastShoot = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void Shoot()
    {
        timeAfterLastShoot += Time.deltaTime;
        if (Input.GetMouseButton(0) && timeAfterLastShoot > timeToShoot)
        {
            timeAfterLastShoot = 0f;
            Vector3 mousePosition = Utils.GetMousePosition();
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            Vector3 direction = (mousePosition - transform.position).normalized;
            newBullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }

}
