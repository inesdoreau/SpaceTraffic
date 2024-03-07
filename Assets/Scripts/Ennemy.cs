using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    private Vector2 direction;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SetSpeed();
        SetSize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.up * int.MaxValue, speed * Time.deltaTime);
    }

    public void SetPositionAndDirection(Vector3 position)
    {
        transform.position = position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    public void SetSpeed()
    {
        float rand = Random.Range(1, maxSpeed);
        speed = rand;
    }

    public void SetSize()
    {
        float rand = Random.Range(0.5f, 2);
        transform.localScale *= rand;
    }

    private void OnBecameInvisible()
    {
        GameManager.Instance.IncreaseScore();
        Destroy(gameObject);
    }
}
