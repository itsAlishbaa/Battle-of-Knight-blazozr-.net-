using System;
using System.Threading.Tasks;
using blazor_final_pro.Models;

namespace blazor_final_pro.Services
{
    public class BattleEngine
    {
        public EntityStats State { get; set; } = new();
        public event Action? OnStateChanged;
        private System.Threading.Timer? _aiTimer;

        public void StartAiLoop()
        {
            _aiTimer?.Dispose();
            _aiTimer = new System.Threading.Timer(async _ => await ProcessAiTick(), null, 1000, 500);
        }

        public async void HandleGesture(string gesture)
        {
            if (State.IsGameOver) return;

            if (gesture == "SwipeLeft" && State.PlayerX > 10)
            {
                State.PlayerX -= 60; // Bada step peeche
                State.PlayerPose = "walking";
                State.LastMessage = "Knight stepped back!";
            }
            else if (gesture == "SwipeRight")
            {
                // Core relative math calculation logic 
                int currentDistance = 1000 - State.PlayerX - State.EnemyX;

                if (currentDistance > 150)
                {
                    State.PlayerX += 60; // Tezi se aage barhega
                    State.PlayerPose = "walking";
                    State.LastMessage = "Knight is closing the distance...";
                }
                else
                {
                    State.PlayerPose = "attack";
                    State.EnemyPose = "hit";
                    State.EnemyHP -= 15;
                    State.LastMessage = "Knight slashed the Skeleton!";
                    if (State.EnemyHP <= 0)
                    {
                        State.EnemyHP = 0;
                        State.IsGameOver = true;
                        State.Score += 200;
                        State.LastMessage = "VICTORY! The Skeleton has collapsed!";
                    }
                }
            }

            OnStateChanged?.Invoke();
            await Task.Delay(200);
            if (!State.IsGameOver)
            {
                State.PlayerPose = "idle";
                if (State.EnemyPose == "hit") State.EnemyPose = "idle";
            }
            OnStateChanged?.Invoke();
        }

        private async Task ProcessAiTick()
        {
            if (State.IsGameOver) return;

            int currentDistance = 1000 - State.PlayerX - State.EnemyX;

            if (currentDistance > 150)
            {
                State.EnemyX += 40; // Skeleton moves closer from right side boundary
                State.EnemyPose = "walking";
            }
            else
            {
                State.EnemyPose = "attack";
                State.PlayerPose = "hit";
                State.PlayerHP -= 10;
                State.LastMessage = "Skeleton slashes the Knight!";
                if (State.PlayerHP <= 0)
                {
                    State.PlayerHP = 0;
                    State.IsGameOver = true;
                    State.LastMessage = "DEFEAT! The Knight fell in battle.";
                }
            }

            OnStateChanged?.Invoke();
            await Task.Delay(200);
            if (!State.IsGameOver)
            {
                State.EnemyPose = "idle";
                if (State.PlayerPose == "hit") State.PlayerPose = "idle";
            }
            OnStateChanged?.Invoke();
        }

        public void ResetEngine()
        {
            State = new EntityStats { PlayerX = 50, EnemyX = 50 };
            StartAiLoop();
            OnStateChanged?.Invoke();
        }
    }
}
