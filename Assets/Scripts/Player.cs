using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowCursor();
    }

    public void FollowCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        if(direction.SqrMagnitude() > 0.01f)
        {
            transform.up = direction;
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed *Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
            AudioManager.Instance.PlaySFX("Explosion");
            GameManager.Instance.GameOver();
        }        
    }

}
