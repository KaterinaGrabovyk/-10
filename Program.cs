namespace ПР10
{
    public class DEREVO
    {
        public int Key { get; private set; }
        public DEREVO Left { get; set; }
        public DEREVO Right { get; set; }

        public DEREVO(int key)
        {
            Key = key;
            Left = null;
            Right = null;
        }
    }

    public class POSHUK
    {
        private DEREVO root;

        public int Height()
        {
            return VISOTA(root);
        }
        public void DODATI(int key)
        {
            root = DODATI2(root, key);
        }
        private DEREVO DODATI2(DEREVO node, int key)
        {
            if (node == null)
            {
                return new DEREVO(key);
            }
            if (key < node.Key)
            {
                node.Left = DODATI2(node.Left, key);
            }
            else if (key > node.Key)
            {
                node.Right = DODATI2(node.Right, key);
            }
            return node;
        }

        private int VISOTA(DEREVO node)
        {
            if (node == null)
            {
                return 0;
            }
            int leftHeight = VISOTA(node.Left);
            int rightHeight = VISOTA(node.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть розмір масиву: ");
            int n = int.Parse(Console.ReadLine());
            int[] chisla = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++) { chisla[i] = random.Next(1, 50); }
            POSHUK tree = new POSHUK();
            foreach (int chislo in chisla) { tree.DODATI(chislo); }
            int height = tree.Height();
            Console.WriteLine("VISOTA = " + height);
        }
    }
}
