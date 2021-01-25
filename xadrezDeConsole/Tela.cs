using System;
using tabuleiro;

namespace xadrezDeConsole
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.QualPeca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.QualPeca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
