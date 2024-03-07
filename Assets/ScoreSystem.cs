using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer unit;
    [SerializeField] private SpriteRenderer ten;
    [SerializeField] private SpriteRenderer hundred;

    [SerializeField] private List<Sprite> numbers;


    public void UpdateScore(int score)
    {
        int ones = score % 10;
        int tens = 0;
        int hundreds = 0;        

        if (score >= 10)
        {
            tens = (score % 100 - ones) / 10;
        }
        if (score >= 100)
        {
            hundreds = (score % 1000 - ones - tens)/100;
        }

        unit.sprite = numbers[ones];
        ten.sprite = numbers[tens];
        hundred.sprite = numbers[hundreds];
    }
}
