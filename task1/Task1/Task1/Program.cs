using NLog;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static async void Tasks()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            ClassicString s1 = new ClassicString();
            s1.Intput();
            ClassicString s2 = new ClassicString();
            s2.Intput();
            ClassicString s3 = new ClassicString();
            s3.Intput();
            Task t1 = Task.Run(() => s1.Output(cts));
            Task t2 = Task.Run(() => s2.Output(cts));
            Task t3 = Task.Run(() => s3.Output(cts));
            await Task.WhenAll(t1,t2,t3);
            //Console.WriteLine("Продолжаем метод Tasks");
            if (cts.Token.IsCancellationRequested)
            {
                Console.WriteLine("FAILURE");
            }
            else
            {
                Console.WriteLine("SUCCESS");
            }

        }
        static void Main(string[] args)
        {
            Tasks();
            //Console.WriteLine("о5 в основном потоке");
            Console.ReadKey();
        }
    }
    public abstract class StringPattern
    {
        public static byte Number = 1;
        protected string FileName { get; set; }
        private string StoredValue { get; set; }
        private void PrintRequest()
        {
            Console.WriteLine("Input string {0}", Number);
        }
        public void Intput()
        {
            PrintRequest();
            Number++;
            StoredValue = Console.ReadLine();
        }
        public void Output(CancellationTokenSource cts)
        {
            try
            {
                Random r = new Random();
                if (r.Next(0, 2) == 0)
                {
                    throw new Exception("Пользовательская ошибка");
                }
                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(FileName,false, System.Text.Encoding.Default))
                    {
                        streamWriter.WriteLine(StoredValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Console.WriteLine(ex.Message);
                cts.Cancel();
            }
        }
        private void Log(string message)
        {
            Logger log = LogManager.GetCurrentClassLogger();
            log.Error(message);
        }
    }
    public class ClassicString : StringPattern
    {
        public ClassicString()
        {

            FileName = (Number == 1) ? "task1.txt" : Number == 2 ? "taskN1.txt" : "task_1.txt";
        }
    }
}
