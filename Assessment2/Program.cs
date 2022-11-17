namespace Assessment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck1=new Deck();
            deck1.ShuffleDeck();
            Console.WriteLine(deck1.DealCard());
            Console.WriteLine(deck1.DealCard());
            
            Console.ReadLine();
        }
    }
}