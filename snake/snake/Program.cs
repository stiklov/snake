﻿using System;
using System.Threading;


namespace snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);  //установка размера буфера
            
            
            Walls walls = new Walls(80, 25);
            walls.Draw();
            
            //отрисовка точек
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            
            //отрисовка еды
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();
            
            //управление и питание
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition( xOffset, yOffset++ );
            WriteText( "============================", xOffset, yOffset++ );
            WriteText( "И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++ );
            yOffset++;
            WriteText( "Ты - пидор", xOffset + 10, yOffset++ );
            WriteText( "============================", xOffset, yOffset++ );
        }

        static void WriteText( string text, int xOffset, int yOffset )
        {
            Console.SetCursorPosition( xOffset, yOffset );
            Console.WriteLine( text );
        }
    }
}