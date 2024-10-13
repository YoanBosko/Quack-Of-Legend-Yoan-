using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySumpit : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    public bool ready;
    private GameState gameState;
    void Awake()
    {
        gameState = FindAnyObjectByType<GameState>();
    }
    public void SetDirection(Vector2 arah)
    {
        direction = arah.normalized;
        ready = true;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        if (ready)
        {
            Vector3 position = transform.position;
            position.z = 10f;
            if (!gameState.paused && !gameState.gameover)
            {
                position += direction * speed * Time.deltaTime;
            }
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x - 1) || (transform.position.x > max.x + 1) || (transform.position.y < min.y - 1) || (transform.position.y > max.y + 1))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
