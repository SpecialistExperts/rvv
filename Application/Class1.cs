using System;

namespace Application
{
    public class RandomNumber
    {
        public int RandomNumberGenerator(){
            Random random = new Random();
            int RandomNumber = random.Next(0, 1000);

            return RandomNumber;
        }
    }
}
