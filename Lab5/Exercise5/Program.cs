using System;

namespace consoleApplication
{
    public class MyClass
    {
        public delegate void LogHandler(string message);
        public void process(LogHandler loghandler) {
            if (loghandler == null) {
                loghandler("begin");
            }
            if (loghandler == null) {
                loghandler("end");
            }
        }
    }
    public class MyLogger {
        public void logger(string s){
            Console.WriteLine(s);
        }

    }
    public class TestApplication {
        static void logger(string s) {
            Console.WriteLine(s);
        }
        static void Main(string[] args) {
            MyLogger f1 = new MyLogger();
            MyClass myclass = new MyClass();
            MyClass.LogHandler myLogger = null;
            myLogger += new MyClass.LogHandler(logger);
            myLogger += new MyClass.LogHandler(f1.logger);
            return;
        }
    }
}
