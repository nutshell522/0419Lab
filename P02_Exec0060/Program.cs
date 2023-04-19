using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_Exec0060
{
	public class Program
	{
		// 060 讓使用者輸入一個正整數n，然後判斷n是否為質數。如果是質數，則輸出「n是質數」，否則輸出「n不是質數」。如果n小於等於0，則輸出「請輸入正整數
		static void Main(string[] args)
		{
			Console.WriteLine("請輸入數字:");
			while (true)
			{
				int n = GetInput();  // 使用戶輸入 n ，並驗證 n 是否為正數? 否則請用戶重複輸入
				Console.WriteLine(n.GeIsPrimetPrime());
			}

		}

		/// <summary>
		/// 獲得用戶輸入的數字
		/// </summary>
		/// <returns></returns>
		private static int GetInput()
		{
			CycleValidation(out int n);
			return n;
		}
		/// <summary>
		/// 反覆驗證用戶輸入的值，直到輸入正確
		/// </summary>
		/// <param name="n"></param>
		private static void CycleValidation(out int n)
		{
			while (true)
			{
                string input = Console.ReadLine();
                bool inputResult = int.TryParse(input, out n);
				if (!string.IsNullOrEmpty(input) && inputResult && n > 0) break;
				Console.WriteLine("請輸入正整數!");
			};
		}
	}
	public static class MathHelper
	{
		/// <summary>
		/// 驗證是否為質數
		/// </summary>
		/// <param name="n">數字</param>
		/// <returns></returns>
		public static bool IsPrime(this int n)
		{
			if (n <= 1) return false;

			if (n == 2) return true;

			for (int i = 2;  i <= Math.Sqrt(n); i++) { 
				if (n % i == 0) return false;
			}
			return true;
		}

		/// <summary>
		/// 回傳是否為質數的字串
		/// </summary>
		/// <param name="n">需驗證數字</param>
		/// <returns></returns>
		public static string GeIsPrimetPrime(this int n)
		{
			bool result = IsPrime(n);
			return result
				?$"{n} 是質數"
				:$"{n} 不是質數";
		}
	}
}
