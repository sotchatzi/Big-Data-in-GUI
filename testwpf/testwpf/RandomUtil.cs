//Random util class
//stopwatch

namespace MultiThreaded_GUI
{
    static class RandomUtil
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
    }

}
