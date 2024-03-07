using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class Star : MonoBehaviour
{
    [SerializeField] private SpriteRenderer starRenderer;

    // Start is called before the first frame update
    void Start()
    {
        starRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetRandomPosition();
        _ = ShineAsync();
    }
    
    private void SetRandomPosition()
    {
        Vector3 randPOs = new Vector3(Random.Range(-10, 10), Random.Range(-5,5), 0);
        transform.position = randPOs;
    }

    private async Task ShineAsync()
    {
        float rand = Random.Range(0.5f, 2f);
        await starRenderer.DOFade(1, rand).AsyncWaitForCompletion();
        await starRenderer.DOFade(0, rand).AsyncWaitForCompletion();
        Destroy(gameObject);
    }
}
