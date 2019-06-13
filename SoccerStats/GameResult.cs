using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerStats
{
    public class GameResult
    {
        //auto-proerty game date, team name,HomeOrAway, Goals, GoalAttempts, ShotsOnGoal, ShotsOffGoal, PosessionPercent
        public DateTime GameDate { get; set; }
        public string TeamName { get; set; }
        public HomeOrAway HomeOrAway { get; set; }
        public int Goals { get; set; }
        public int GoalAttempts { get; set; }
        public int ShotOnGoal { get; set; }
        public int ShotOffGoal { get; set; }
        public double PosessionPercent { get; set; }

    }

    public enum HomeOrAway
    {
        Home,
        Away
    }
}
