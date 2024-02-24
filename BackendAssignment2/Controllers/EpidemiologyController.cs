using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Security;

namespace BackendAssignment2.Controllers
{
    public class EpidemiologyController : ApiController
    {

        /// <summary>
        /// 
        /// In this problem, When a person has a disease, they infect exactly R other people but only on the very next day.
        /// No person is infected more than once.We want to determine when a total of more than P people have had the disease.
        /// 
        /// This method will calculate the number of the first day on which the total number of people who have had the disease is greater than P.
        /// 
        /// </summary>
        /// 
        /// parameter P is the number of people who have had the disease.
        /// <param name="P"></param>
        /// 
        /// parameter N is the number of people who have the disease on Day 0.
        /// <param name="N"></param>
        /// 
        /// parameter R is the number of people infected by a person who has the disease.
        /// <param name="R"></param>
        /// 
        /// <returns>Return an integer,first day on which the total number of people who have had the disease is greater than P. </returns>
        /// 
        /// Example: GET
        /// /api/epidemiology/750/1/5
        /// 
        /// returns 4
        /// 
        /// https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2020/ccc/juniorEF.pdf Second problem.
        /// 

        [HttpGet]
        [Route("api/epidemiology/{P}/{N}/{R}")]

        public int Get(int P, int N, int R)
        {
            // initialize the day to 0
            int day = 0;
            // initialize the total number of people who have had the disease to N
            int infectedTotal = N;
            // initialize the number of people who have the disease on Day 0 to N
            int infectedToday = N;
            // while the total number of people who have had the disease is less than or equal to P
            while (infectedTotal <= P)
            {
                // the number of people who have the disease on the next day is the number of people who have the disease today times R
                infectedToday *= R;
                // the total number of people who have had the disease is the total number of people who have had the disease plus the number of people who have the disease today
                infectedTotal += infectedToday;
                // increment the day by 1
                day++;
            }
            // return the first day on which the total number of people who have had the disease is greater than P
            return day;
        }
    }
}
