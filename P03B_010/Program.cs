using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P03B_010
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //設計一個類別來表示一個矩形，擁有長和寬兩個屬性，以及計算面積和周長的方法。
            Square s1 = new Square(3,5);
            s1.ShowInfo();

            Square s2 = new Square(9,10);
            s2.ShowInfo();
        }
    }

    public class Square
    {
        public int Width { get; }
        public int Height { get; }
        public Square(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentException("數值錯誤");

            Width = width;
            Height = height;
        }

        /// <summary>
        /// 計算面積
        /// </summary>
        /// <returns></returns>
        public int CalcArea()
            => this.Width * this.Height;

        /// <summary>
        /// 計算週長
        /// </summary>
        /// <returns></returns>
        public int CalcPerimeter()
            => (this.Width + this.Height) * 2;

        /// <summary>
        /// 輸出訊息文字
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"此方形長: {this.Height,2} , 寬: {this.Width,2} , 面積: {this.CalcArea(),3} , 周長: {this.CalcPerimeter(),3}");
        }
    }
}
