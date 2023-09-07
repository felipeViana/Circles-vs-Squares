using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timeToShoot = 1f;
    private float timeAfterLastShoot = 0f;

    public static Player Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
        HandleShoot();
    }

    private void HandleMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
        Camera.main.transform.position = transform.position + Vector3.back * 10;
    }

    private void HandleShoot()
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
