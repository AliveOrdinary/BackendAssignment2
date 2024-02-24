using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace BackendAssignment2.Controllers
{
    public class SantosController : ApiController
    { 


        /// <summary>
        /// Professor Santos has decided to hide a secret formula for a new type of biofuel. She has, however, left a sequence of coded instructions for her assistant.
        /// Each instruction is a sequence of five digits which represent a direction to turn and the number of steps to take.
        /// 
        /// This method will decode the instructions so the assistant can use them to find the secret formula.
        /// </summary>
        /// Parameter instructions is a string of digits, where each 5 digits represent a direction to turn and the number of steps to take. 99999 means the end of the sequence.
        /// <param name="instructions"></param>
        /// <returns>A string of decoded instructions</returns>
        /// 
        /// Example GET api/santos/57234009073410099999
        /// 
        /// returns right 234 right 907 left 100
        /// 
        /// Example GET api/santos/543250056899999
        /// 
        /// returns left 325 left 568 


        [HttpGet]
        [Route("api/santos/{instructions}")]
        public string Get(string instructions)
        {
            // a new array to store the instructions
            string[] instructionsArray = new string[instructions.Length / 5];
            int j = 0;

            // loop through the instructions and store them in the array
            for (int i = 0; i < instructions.Length; i += 5)
            {
                instructionsArray[j] = instructions.Substring(i, 5);
                j++;
            }

            // the original length of the array
            int originalLength = instructionsArray.Length;
            // a new array to store the instructions after removing the last element that is 99999.
            string[] newArray = new string[originalLength - 1];

            // loop through the original array and store the instructions in the new array
            for (int i = 0; i < originalLength - 1; i++)
            {
                newArray[i] = instructionsArray[i];
            }

            // loop through the new array and decode the instructions
            for (int i = 0; i < newArray.Length; i++)
            {
                // a string to store the direction
                string direction = "";
                // an integer to store the steps
                int steps = 0;
                // get the first and second digits of the instruction
                int firstDigit = int.Parse(newArray[i].Substring(0, 1));
                int secondDigit = int.Parse(newArray[i].Substring(1, 1));
                // get the sum of the first and second digits
                int sum = firstDigit + secondDigit;

                // check if the sum is even or odd
                if (sum % 2 == 0 && sum != 0)
                {
                    // if the sum is even and not equal to 0, the direction is right
                    direction = "right";
                }
                else if (sum % 2 != 0)
                {
                    // if the sum is odd, the direction is left
                    direction = "left";
                }
                else
                {
                    // if the sum is 0, the direction is the same as the previous
                    direction = "same as previous";
                }

                // get the third, fourth and fifth digits of the instruction
                steps = int.Parse(newArray[i].Substring(2, 3));

                // store the decoded instruction in the new array
                newArray[i] = direction + " " + steps;
               
            }

            // a string to store the result
            string result = "";

            // loop through the new array and store the instructions in the result string
            for (int i = 0; i < newArray.Length; i++)
            {
                result += newArray[i] + " ";
            }

            // return the result
            return result;
            
       
        }
    }
}
