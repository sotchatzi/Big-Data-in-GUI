namespace Generators
{
    //ItemList: random string generator setter and getter
    public class ItemList
    {
        public string AString { get; set; }
        public int AnIndex { get; set; }
        public int AFlag { get; set; }
        //Flag = 
        //0 -- Normal
        //1 -- Slow
        //2 -- Fail
        //3 -- Timeout
    }
}