

namespace Persion
{
    class Program
    {
        static void Main(string[] args)
        {
            Gorbesan gorbesan = new Gorbesan();
            Tiger tiger = new Tiger();
            Cats cat = new Cats();
            Console.WriteLine("Hello shahab");
        }
    }

    public class Gorbesan
    {
        public string rang { get;  }
        public int size { get; }
        public bool vazn { get;  }
    }

    class Cats : Gorbesan
    {
        public string nejad { get;  }
    }

    class Tiger : Gorbesan
    {
        public string gone { get; }
    }
}

