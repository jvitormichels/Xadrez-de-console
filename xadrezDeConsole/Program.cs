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
            tab.ColocarPeca(new Torre(tab, Cor.Amarela), new Posicao(7,0));
            tab.ColocarPeca(new Rei(tab, Cor.Amarela), new Posicao(0, 7));
            Tela.ImprimirTabuleiro(tab);
        }
    }
}
