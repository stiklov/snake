using System;

namespace snake
{
    public class FoodCreator
    {
        private int mapWidht;
        private int mapHeight;
        private char sym;
        
        Random random = new Random();

        public FoodCreator(int mapWidht, int mapHeidht, char sym)
        {
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeidht;
            this.sym = sym;

        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}