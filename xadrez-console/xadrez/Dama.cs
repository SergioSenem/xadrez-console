using tabuleiro;

namespace xadrez {
    class Dama : Peca{
        public Dama(Tabuleiro tab, Cor cor)
            : base(tab, cor) {

        }

        public override string ToString() {
            return "D";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            bool ok = true;
            //NO
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos) && ok) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    ok = false;
                }
                pos.definirValores(pos.linha - 1, pos.coluna - 1);
            }
            ok = true;

            //SO
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos) && ok) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    ok = false;
                }
                pos.definirValores(pos.linha + 1, pos.coluna - 1);
            }
            ok = true;

            //NE
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos) && ok) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    ok = false;
                }
                pos.definirValores(pos.linha - 1, pos.coluna + 1);
            }
            ok = true;

            //SE
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos) && ok) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    ok = false;
                }
                pos.definirValores(pos.linha + 1, pos.coluna + 1);
            }

            //acima

            pos.definirValores(posicao.linha - 1, posicao.coluna);
            bool okC = true;
            while (tab.posicaoValida(pos) && podeMover(pos) && okC) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    okC = false;
                    //break;
                }
                pos.linha = pos.linha - 1;
            }

            //abaixo

            pos.definirValores(posicao.linha + 1, posicao.coluna);
            bool okB = true;
            while (tab.posicaoValida(pos) && podeMover(pos) && okB) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    okB = false;
                    //break;
                }
                pos.linha = pos.linha + 1;
            }

            //direita

            pos.definirValores(posicao.linha, posicao.coluna + 1);
            bool okD = true;
            while (tab.posicaoValida(pos) && podeMover(pos) && okD) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    okD = false;
                    //break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //esquerda

            pos.definirValores(posicao.linha, posicao.coluna - 1);
            bool okE = true;
            while (tab.posicaoValida(pos) && podeMover(pos) && okE) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    okE = false;
                    //break;
                }
                pos.coluna = pos.coluna - 1;
            }

            ok = true;

            return mat;
        }
    }
}
