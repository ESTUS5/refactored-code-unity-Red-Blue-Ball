using System.Collections.Generic;
using UnityEngine;

public class AimShooterManager : MonoBehaviour
{
    [SerializeField]
    private Ball _ballPrefab;
    [SerializeField]
    private Vector3 _force;
    [SerializeField]
    private float _ballSpawnZ;

    private float _shootTimer;
    private List<Ball> _spawnedBalls;
    public static AimShooterManager instance;
    bool IsGameFinished = false;
    private Camera _camera;
    private ScoreCalculator _scoreCalculator;

    private void Awake()
    {
        instance = this;
        _spawnedBalls = new List<Ball>();
        _camera = Camera.main;
        _scoreCalculator = new ScoreCalculator();
    }

    private void Update()
    {
            if(_scoreCalculator.FinishGame())
            {
                Debug.Log(_scoreCalculator.CreateSummaryMessage(_spawnedBalls));
                for (int i = _spawnedBalls.Count - 1; i >= 0; i--)
                {
                    Destroy(_spawnedBalls[i].gameObject);
                    _spawnedBalls.RemoveAt(i);
                }
                enabled = false;
            }
        
            if (_shootTimer >= 0.3f && Input.GetMouseButtonDown(0))
            {
                ShootBall(Color.red);
            }
            else if (_shootTimer >= 0.3f && Input.GetMouseButtonDown(1))
            {
                ShootBall(Color.blue);
            }
            // }
            Debug.Log(_shootTimer);
            _shootTimer += Time.deltaTime;
        
        // if(!IsGameFinished  )
        // {
        //     // if (_shootTimer >= 0.3f)
        //     // {

        //     if (_shootTimer >= 0.3f && Input.GetMouseButtonDown(0))
        //     {
        //         ShootBall(Color.red);
        //     }
        //     if (_shootTimer >= 0.3f && Input.GetMouseButton(1))
        //     {
        //         ShootBall(Color.blue);
        //     }
        //     // }
        //     _shootTimer += Time.deltaTime;
        
        //     if(_scoreCalculator.FinishGame())
        //     {
        //         Debug.Log(_scoreCalculator.CreateSummaryMessage(_spawnedBalls));
        //         for (int i = _spawnedBalls.Count - 1; i >= 0; i--)
        //         {
        //             Destroy(_spawnedBalls[i].gameObject);
        //             _spawnedBalls.RemoveAt(i);
        //         }
        //         IsGameFinished = true;
        //     }
        // }
    }

    public void UpdateScore(int scoreDiff)
    {
        _scoreCalculator.UpdateScore(scoreDiff);
    }


    private void ShootBall(Color ballCollor)
    {   
        Vector3 ballPosition = Input.mousePosition;
        ballPosition.z = _ballSpawnZ;
        ballPosition = _camera.ScreenToWorldPoint(ballPosition);
        var ball = Instantiate(_ballPrefab, ballPosition, Quaternion.identity);
        ball.ChangeColor(ballCollor);
        ball.AddForce(_force);
        _spawnedBalls.Add(ball);
        _scoreCalculator.HandleShoot();
        _shootTimer = 0f;
    }

    
}
