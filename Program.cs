namespace LeetCode_292
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(CanWinNim(a));

            //函式 回傳bool 輸入 int n 石頭數量
            //你先拿 一次拿1~3個石頭，拿到最後一顆的贏
            bool CanWinNim(int n)
            {
                //1. 輸入
                // int n 石頭數

                //2. 處理
                //最後一個拿1~3顆贏，所以剩下4顆石頭先手的人會輸。
                bool willWin;
                int remainder;
                remainder = n % 4;

                if (remainder == 0)
                {
                    willWin = false;
                }
                else
                {
                    willWin = true;
                }

                //3. 輸出
                //判斷最後一回合是否等於4
                bool result;
                result = willWin;
                return result;
            }
        }
    }
}
