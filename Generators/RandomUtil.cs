using System;

namespace Generators
{

    //RandomUtil: random string generator
    public static class RandomUtil
    {
        /// <summary>
        /// https://www.dotnetperls.com/random-string
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            string path = System.IO.Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        //Returns a random string of 12 characters where the last char is a special character
        public static string GetRandomStringSpecialChar()
        {

            char[] chars = SpecialChar();

            Random r = new Random();
            int i = r.Next(chars.Length);

            string randomStringWithSpecialChar = GetRandomString() + chars[i];

            return randomStringWithSpecialChar;
        }


        public static char[] SpecialChar()
        {
            char[] chars = "~!@#$%^&*()_+`-=[];',./{}:<>?\"\\|".ToCharArray();
            return chars;
        }

    }
}