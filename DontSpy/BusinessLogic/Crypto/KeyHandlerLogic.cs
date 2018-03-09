using System;
using System.Collections.Generic;
using System.Diagnostics;
using DontSpy.Interfaces;

namespace DontSpy.BusinessLogic.Crypto
{
    internal class KeyHandlerLogic : IKeyHandler
    {

        public int[] ProduceKeys(int n)

        {
            int[] key = new int[n];
            int[] amountOfCiphers = new int[n];
            for (var i = 0; i < n; i++) //wegen int array der bei 0 startet hier Tabelle von 0 bis 8099
            {
                amountOfCiphers[i] = i;
            }
            for (var i = 0; i < n; i++)
            {
                var rnd = new Random(); //hier kann noch ein eigener Algorithmus hin
                var next = rnd.Next(0, n - i + 1); //da der Endwert nicht mit einbezogen wird muss +1 gerechnet werden 
                key[i] = amountOfCiphers[next];
                for (var j = next; j < n - i - 1; j++)
                    //-i deswegen, weil i schon nach vorne geschoben wurde, deshlab die letzten i keine Rolle mehr spielen
                {
                    amountOfCiphers[j] = amountOfCiphers[j + 1];
                }
            }
            return key;
        }

        
        public Dictionary<int, int> KeyTable(int[] key)
        {
            Dictionary<int, int> tableOfKeys = new Dictionary<int, int>();

            for (var i = 0; i < key.Length; i++)
            {
                tableOfKeys.Add(i, key[i]);
            }

            return tableOfKeys;
        }

        public int[] SplitKeys(string key)
        {
            int[] _key = new int[8100];
            int lauf = 0;
            for (int i = 0; i < key.Length / 2; i++)
            {
                var keyA = MathematicalMappingLogic.BackTransformationTable[key[lauf]];
                var keyB = MathematicalMappingLogic.BackTransformationTable[key[lauf + 1]];
                _key[i] = (keyA - 1) * 90 + keyB;
                Debug.WriteLine(_key[i]);
                lauf = lauf + 2;
            }
            return _key;
        }
    }

}