using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Exec0002C
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 傳入任意日期，傳回是今年的第幾周。// 例如：2016/12/31，傳回 53。
			Console.WriteLine("請輸入日期:");
			while (true)
			{
				DateTime dt = GetInput();

                GregorianCalendar g = new GregorianCalendar();
                int week = g.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

				Console.WriteLine($"第 {week} 週");

            }


			//DateTime dt1 = new DateTime(2022,01,03);
			//GregorianCalendar g = new GregorianCalendar();
			//int dt1Week = g.GetWeekOfYear(dt1,CalendarWeekRule.FirstDay,DayOfWeek.Monday);
			//Console.WriteLine(dt1Week);
		}
		/// <summary>
		/// 獲得用戶輸入的日期
		/// </summary>
		/// <returns></returns>
		private static DateTime GetInput()
		{
			CycleValidation(out DateTime n);
			return n;
		}
		/// <summary>
		/// 反覆驗證用戶輸入的值，直到輸入正確
		/// </summary>
		/// <param name="n"></param>
		private static void CycleValidation(out DateTime n)
		{
			while (true)
			{
				string input = Console.ReadLine();

                bool inputResult = DateTime.TryParse(input, out n);
				if (!string.IsNullOrEmpty(input) && inputResult) break;
				Console.WriteLine("請輸入正確日期格式!");
			};
		}
	}

}
