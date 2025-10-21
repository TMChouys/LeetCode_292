using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode_292
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C#的輸入與輸出
            //知識點：Ch2 建立C#應用程式，主控台應用程式的輸出與輸入、程式註解、程式碼縮排
            //知識點：Ch3 變數、資料型別與運算子，變數的宣告、變數的初值、指定敘述、整數資料型別、字串資料的型別轉換
            //知識點：Ch7 函數，呼叫擁有參數和傳回值的函數、函數的執⾏過程
            //知識點：Ch5 選擇控制項與條件敘述，條件運算子「？: 」

            Console.Write("輸入石頭數量：");  //顯示提示訊息，請使用者輸入石頭數量
            string str1 = Console.ReadLine();  //讀取使用者輸入的字串指定給宣告變數str1的初值
            int a = Convert.ToInt32(str1);  //將字串轉換成整數並指定給變數a
            Console.WriteLine("您是先手，您是否會贏？" + (CanWinNim(a)?"會":"不會")); ////條件運算子「？:」  //呼叫CanWinNim函數並傳入參數a，根據傳回值顯示先手是否會贏的訊息

            /*
            LeetCode 292. Nim Game

            You are playing the following Nim Game with your friend:
            Initially, there is a heap of stones on the table.
            You and your friend will alternate taking turns, and you go first.
            On each turn, the person whose turn it is will remove 1 to 3 stones from the heap.
            The one who removes the last stone is the winner.
            Given n, the number of stones in the heap, return true if you can win the game assuming both you and your friend play optimally, otherwise return false.

            Example 1:
            Input: n = 4
            Output: false
            Explanation: These are the possible outcomes:
            1.You remove 1 stone.Your friend removes 3 stones, including the last stone. Your friend wins.
            2.You remove 2 stones.Your friend removes 2 stones, including the last stone. Your friend wins.
            3.You remove 3 stones.Your friend removes the last stone. Your friend wins.
            In all outcomes, your friend wins.
            
            Example 2:
            Input: n = 1
            Output: true
           
            Example 3:
            Input: n = 2
            Output: true

            Constraints:
            1 <= n <= 231 - 1

            LeetCode 292. Nim 遊戲

            你正在和你的朋友玩以下 Nim 遊戲：
            最初，桌子上有一堆石子。
            你和你的朋友輪流行動，你先走。
            每輪，輪到你的人將從石子堆中移除 1 到 3 塊石子。
            移除最後一塊石子的人獲勝。
            給定石子堆中的石子數 n，假設你和你的朋友都以最優策略獲勝，則傳回 true，否則回傳 false。

            範例 1：
            輸入：n = 4
            輸出：false
            解釋：以下是可能的結果：
            1. 你移除 1 塊石子。你的朋友移除 3 塊石子，包括最後一塊石子。你的朋友獲勝。
            2. 你移除 2 塊石子。你的朋友移除 2 塊石子，包括最後一塊石子。你的朋友獲勝。
            3. 你移除 3 塊石子。你的朋友移除最後一塊石子。你的朋友獲勝。
            所有結果均為你的朋友獲勝。

            範例 2：
            輸入：n = 1
            輸出：true

            範例 3：
            輸入：n = 2
            輸出：true

            約束：
            1 <= n <= 231 - 1
            */


            // 解題思路：

            // 規則：一次最多拿三塊石頭走，拿走最後一顆獲勝。
            // 往前回推1，自己要獲勝的組合是，拿走包含最後一顆的三顆石頭組合，就會獲勝。組合：(1)、(1, 2)、(1, 2, 3)
            // 往前回推2，所以要讓對手拿到必輸的組合，是對手拿的三塊石頭裡最多只能拿到倒數第2顆，最少要拿到倒數第4顆。組合是：
            // (2, 3, 4)、(3, 4)、(4)
            // (3, 4, 5)、(4, 5)
            // (4, 5, 6)
            // 意思就是，只要拿到倒數第4顆石頭包含任何組合，就會輸。

            // 以此類推，只要讓對手拿到倒數第8顆石頭，也可以讓對手必定拿到倒數第4顆石頭的組合。
            // 倒數第8顆石頭的組合是：
            // (6, 7, 8)、(7, 8)、(8)
            // (7, 8, 9)、(8, 9)
            // (8, 9, 10)
            // 然後自己再拿的組合：
            // (5, 6, 7)或其他
            // 就可以讓對手進入必拿倒數第4顆石頭的組合。

            // 以此類推倒數第12顆石頭，也可以讓對手拿到倒數第4顆石頭的組合。
            // 因此，只要拿到4的倍數的石頭，必輸。

            //知識點：Ch7 函數，建立C#函數、函數的參數列、函數的傳回值、區域函數
            //知識點：Ch3 變數、資料型別與運算子，變數的宣告、變數的初值、指定敘述、整數資料型別、算術運算⼦
            //知識點：Ch5 選擇控制項與條件敘述，條件運算子「？: 」

            //區域函數  1.傳回值是布林資料型別 bool  2.形式變數是一個整數資料型別 int n
            bool CanWinNim(int n)
            {
                //1. 輸入
                // int n 石頭數

                //2. 處理
                //如果石頭數是4的倍數，先手必輸
                //如果石頭不是4的倍數，可以透過拿1~3顆，讓對手拿到4的倍數的石頭，因此先手必勝。

                bool willWin;  //宣告布林變數，表示先手是否會贏
                int remainder;  //宣告整數變數，表示石頭數除以4的餘數

                remainder = n % 4;  //計算石頭數除以4的餘數
                willWin = (remainder == 0)? false : true; //條件運算子「？:」，如果餘數等於0，表示石頭數是4的倍數，先手必輸，willWin=false；否則先手必勝，willWin=true。

                //3. 輸出
                // 將先手是否會贏的結果傳回
                bool result; //宣告布林變數，儲存先手是否會贏的結果
                result = willWin; //將先手是否會贏的結果指定給result變數
                return result; //傳回result變數的值
            }
            //結束簽名TMChouys
        }
    }
}
