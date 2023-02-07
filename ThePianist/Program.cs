using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Pieces>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                Pieces current = new Pieces(composer, key);

                if (!dict.ContainsKey(piece))
                {
                    dict.Add(piece, current);
                    
                }
                
            }

            string nextInput = string.Empty;

            while ((nextInput = Console.ReadLine()) != "Stop")
            {
                string[] cmnd = nextInput.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = cmnd[0];
                string piece = cmnd[1];
               
                if (action == "Add")
                {
                    string composer = cmnd[2];
                    string key = cmnd[3];

                    Pieces currPiece = new Pieces(composer, key);
                    if (!dict.ContainsKey(piece))
                    {
                        dict.Add(piece, currPiece);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }

                else if (action == "Remove")
                {
                    

                    if (dict.ContainsKey(piece))
                    {
                        
                        dict.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else 
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                else if (action == "ChangeKey")
                {
                    string newKey = cmnd[2];
                    
                    if (dict.ContainsKey(piece))
                    {
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        dict[piece].Key = newKey;   
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in dict)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }

    public class Pieces
    {
        public Pieces(string composer, string key)
        {
            
            this.Composer = composer;
            this.Key = key;
        }

        
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
