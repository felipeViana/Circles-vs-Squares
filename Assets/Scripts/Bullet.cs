using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timeToLive = 3f;
    private float timeAlive = 0f;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        timeAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        transform.position += direction * speed * Time.deltaTime;

        if (timeAlive > timeToLive)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
