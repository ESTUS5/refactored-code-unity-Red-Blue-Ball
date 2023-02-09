using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag ==
            collision.gameObject.tag)
        {
            UpdateScoreText(1);
        }
        else
        {
            UpdateScoreText(-1);
        }
    }

    private void UpdateScoreText(int result)
    {
        var score = _scoreText.text.Replace("Score: ", "");
        int.TryParse(score, out int resultNumeric);
        resultNumeric += result;
        _scoreText.text = $"Score: {resultNumeric}";
        AimShooterManager.instance.UpdateScore(result);
    }
}
