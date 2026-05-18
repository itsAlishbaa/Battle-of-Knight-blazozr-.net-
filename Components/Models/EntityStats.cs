namespace blazor_final_pro.Models
{
    public class EntityStats
    {
        public int PlayerHP { get; set; } = 100;
        public int EnemyHP { get; set; } = 100;
        public int Score { get; set; } = 0;
        public int PlayerX { get; set; } = 100;    
        public int EnemyX { get; set; } = 100;     
        public string PlayerPose { get; set; } = "idle";
        public string EnemyPose { get; set; } = "idle";
        public string LastMessage { get; set; } = "Game started! Click Left or Right side of screen.";
        public bool IsGameOver { get; set; } = false;
    }
}
