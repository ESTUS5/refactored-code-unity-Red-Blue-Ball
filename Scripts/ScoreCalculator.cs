using System.Collections.Generic;
using UnityEngine;

// namespace ScoreCalculator
// {
    public class ScoreCalculator
    {
        private int _currentScore;
        private int _shots;
        private int blueBallsCount,redBallsCount;

        public void UpdateScore(int scoreDiff)
        {
            _currentScore += scoreDiff;
            Debug.Log($"Current score is {_currentScore}");
        }

        public void HandleShoot()
        {
            _shots++;
        }

        public string CreateSummaryMessage(List<Ball> spawnedBalls)
        {
            var state = _currentScore == 5 ? "won" : "lost";
            var scoringVelocity = _currentScore / Time.realtimeSinceStartup;
            var blueBallsCount = 0;
            var redBallsCount = 0;
            foreach (var spawnedBall in spawnedBalls)
            {
                if(spawnedBall.tag == "Blue")
                {
                    blueBallsCount++;
                }
                else
                {
                    redBallsCount++;
                }
            }

            return $"You {state}. You shot {_shots} times and reached score {_currentScore}. " +
                $"You were scoring {scoringVelocity} points per second on average. " +
                $"What's more, you shot {blueBallsCount} blue balls and {redBallsCount} red balls.";
        }

        public bool FinishGame()
        {
            return _currentScore == 5 || _currentScore == -5;
        }
    }
// }
