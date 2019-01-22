using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrarWars
{
    // Образец сообщения определяется делегатом
    delegate void Message(string message);

    // Источник сообщения
    class SourceMessage
    {
        // Общедоступное поле ссылки на объект-делегат,
        // который наполнится указателями
        // на функции в классах-получателях 
        public Message mail;
        // Необязательное поле с рассылаемым сообщением
        public string message;
        // Разослать сообщение - функция диспетчеризации
        public void DispatchMessage(string mess)
        {
            // Сохраняем внешнее сообщение во внутреннем поле
            message = mess;
            // Инициируем рассылку сообщения всем, 
            // кто зарегистрировался в объекте-делегате
            if (mail != null)   // Если не пустой делегат
                mail(mess);
        }
    }
    // Получатель сообщения
    class Addressee1
    {
        // Функции
        public void Handler(string message)
        {
            Console.WriteLine("Addressee1 получил:"
                + "\n\t\"{0}\"", message);
        }
    }
    // Получатель сообщения
    class Addressee2
    {
        // Функции
        public void Handler(string message)
        {
            Console.WriteLine("Addressee2 получил:"
                + "\n\t\"{0}\"", message);
        }
    }
    // Вызывающая сторона
    class MyClass1
    {
        static public string Title = "Рассылка сообщений делегатом";
        public MyClass1()
        {
            // Создаем объекты источника и получателей сообщения
            SourceMessage source = new SourceMessage();
            Addressee1 obj1 = new Addressee1();
            Addressee2 obj2 = new Addressee2();
            // Формируем список вызовов объекта-делегата
            source.mail += new Message(obj1.Handler);
            source.mail += new Message(obj2.Handler);
            // Рассылаем сообщение напрямую через делегат
            source.mail("Первое сообщение");
            Console.WriteLine();
            // Рассылаем сообщение через функцию диспетчеризации
            source.DispatchMessage("Второе сообщение");
        }
    }
    // Запуск
   /* class ProgramForEvent
    {
        static void Mainner()
        {
            // Настройка консоли
            Console.Title = MyClass1.Title;
            new MyClass();    // Исполняем
        }
    }
    */
}
