using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrarWars
{
    // Объявляем делегат в пространстве имен
    delegate void TypeShow();

    class DelegateTest
    {
        // Объявляем функции с сигнатурой делегатов
        public void Show1()
        {
            Console.WriteLine("Вызов: void Show1()");
        }
        // Объявляем функции с сигнатурой делегатов
        public void Show2()
        {
            Console.WriteLine("Вызов: void Show2()");
        }
        // Объявляем функции с сигнатурой делегатов
        public int Draw1(string str1)
        {
            Console.WriteLine("Вызов: {0}", str1); return 1;
        }
        // Объявляем функции с сигнатурой делегатов
        public int Draw2(string str2)
        {
            Console.WriteLine("Вызов: {0}", str2); return 2;
        }
        // Объявляем статическую функцию
        public static int Print(string str)
        {
            Console.WriteLine("Вызов: {0}", str); return 0;
        }
    }

    // Вызывающая сторона
    class MyClass
    {
        // Объявляем делегат в классе
        delegate int TypeDraw(string str);

        public MyClass()
        {
            // Создаем экземпляр класса с методами
            DelegateTest delegateTest = new DelegateTest();
            // Объявляем ссылки на объекты делегатов
            TypeShow typeShow;
            TypeDraw typeDraw;
            // Создаем объекты делегатов
            typeShow = new TypeShow(delegateTest.Show1);
            typeDraw = new TypeDraw(delegateTest.Draw1);
            // Вызываем методы посредством делегатов
            typeShow();
            typeDraw("int Draw1(string str1)");
            // Адресуемся к другим методам с той же сигнатурой
            typeShow = new TypeShow(delegateTest.Show2);
            typeDraw = new TypeDraw(delegateTest.Draw2);
            // Вызываем другие методы посредством делегатов
            typeShow();
            typeDraw("int Draw2(string str2)");
            // Вызываем статический метод 
            // посредством подходящего делегата 
            typeDraw = new TypeDraw(DelegateTest.Print);
            typeDraw("static int Print(string str)");
        }
    }
}
