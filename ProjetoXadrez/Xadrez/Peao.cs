using tabuleiro;

namespace Xadrez
{

    class Peao : Peca
    {

        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.linhas - 1, posicao.colunas);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
                pos.definirValores(posicao.linhas - 2, posicao.colunas);

                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
                pos.definirValores(posicao.linhas - 1, posicao.colunas - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
                pos.definirValores(posicao.linhas - 1, posicao.colunas + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
            }
            else
            {
                pos.definirValores(posicao.linhas + 1, posicao.colunas);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
                pos.definirValores(posicao.linhas + 2, posicao.colunas);
               
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
                pos.definirValores(posicao.linhas + 1, posicao.colunas - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
                pos.definirValores(posicao.linhas + 1, posicao.colunas + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linhas, pos.colunas] = true;
                }
            }

            return mat;
        }
    }
}