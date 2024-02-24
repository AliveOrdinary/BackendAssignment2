using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendAssignment2.Controllers
{
    public class DroidController : ApiController
    {
        /// <summary>
        /// 
        /// In the game, Deliv-e-droid, a robot droid has to deliver packages while avoiding obstacles.At the end of the game, 
        /// the final score is calculated based on the following points system:
        /// 
        /// Gain 50 points for every package delivered.
        /// Lose 10 points for every collision with an obstacle.
        /// Earn a bonus 500 points if the number of packages delivered is greater than the number of collisions with obstacles.
        /// 
        /// This method will calculate the final score at the end of delivery.
        /// 
        /// </summary>
        /// P is the number of packages delivered.
        /// <param name="P"></param>
        /// C is the number of collisions with obstacles.
        /// <param name="C"></param>
        /// <returns>A single integer F, representing the final score.</returns>
        /// 
        /// Example: GET
        /// /api/droid/5/2
        /// returns 730
        /// 
        /// https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2023/ccc/juniorEF.pdf First problem.


        [HttpGet]
        [Route("api/droid/{P}/{C}")]
        public int Get(int P, int C)
        {
            int score = 0;
            // 50 points for every package delivered added to the score
            score += P * 50;
            // 10 points for every collision with an obstacle subtracted from the score
            score -= C * 10;
            // 500 points if the number of packages delivered is greater than the number of collisions with obstacles
            if (P > C)
            {
                score += 500;
            }
            // return the final score
            return score;
        }

    }
}
