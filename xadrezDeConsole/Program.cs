using System;
using tabuleiro;
using xadrez;

namespace xadrezDeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            tab.ColocarPeca(new Torre(tab, Cor.Amarela), new Posicao(0,0));
            Tela.ImprimirTabuleiro(tab);
        }
    }
}
