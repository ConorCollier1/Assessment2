namespace Assessment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck1=new Deck();
            deck1.ShuffleDeck();
            for (int i = 0; i < 52; i++)
            {
                Console.Write("{0,-19}", deck1.DealCard());
                if((i+1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}