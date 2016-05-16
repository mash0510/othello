using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class OthelloForm : Form
    {
        private bool _blackPass = false;
        private bool _whitePass = false;

        public OthelloForm()
        {
            InitializeComponent();

            SetTurn(OthelloParts.OthelloPiece.PieceStatusKind.BLACK);

            othelloBoard.CellClicked += OthelloBoard_CellClicked;
            btn_Pass.Click += Btn_Pass_Click;
        }

        /// <summary>
        /// パスボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Pass_Click(object sender, EventArgs e)
        {
            OthelloParts.OthelloPiece.PieceStatusKind turn = OthelloParts.OthelloPiece.PieceStatusKind.BLACK;

            if (othelloBoard.Turn == OthelloParts.OthelloPiece.PieceStatusKind.BLACK)
            {
                this._blackPass = true;
                turn = OthelloParts.OthelloPiece.PieceStatusKind.WHITE;
            }
            else if (othelloBoard.Turn == OthelloParts.OthelloPiece.PieceStatusKind.WHITE)
            {
                this._whitePass = true;
                turn = OthelloParts.OthelloPiece.PieceStatusKind.BLACK;
            }

            SetTurn(turn);

            if (this._blackPass && this._whitePass)
            {
                Judge();
            }
        }

        /// <summary>
        /// セルクリック時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OthelloBoard_CellClicked(object sender, EventArgs e)
        {
            int numBlack = othelloBoard.GetBlackNum();
            int numWhite = othelloBoard.GetWhiteNum();

            this.lbl_numBlack.Text = numBlack.ToString();
            this.lbl_numWhite.Text = numWhite.ToString();

            SetTurn(othelloBoard.Turn);

            if (numBlack + numWhite == 64)
            {
                Judge();
                return;
            }

            if (numBlack == 0 || numWhite == 0)
            {
                Judge();
                return;
            }
        }

        /// <summary>
        /// 黒番、白番の設定
        /// </summary>
        /// <param name="turn"></param>
        private void SetTurn(OthelloParts.OthelloPiece.PieceStatusKind turn)
        {
            othelloBoard.Turn = turn;

            if (turn == OthelloParts.OthelloPiece.PieceStatusKind.BLACK)
            {
                this.lbl_Turn.Text = "黒の番です";
            }
            else if (turn == OthelloParts.OthelloPiece.PieceStatusKind.WHITE)
            {
                this.lbl_Turn.Text = "白の番です";
            }
        }

        /// <summary>
        /// 勝敗
        /// </summary>
        private void Judge()
        {
            int numBlack = othelloBoard.GetBlackNum();
            int numWhite = othelloBoard.GetWhiteNum();

            string mess = string.Empty;

            if (numBlack > numWhite)
            {
                mess = "黒の勝ちです";
            }
            else if (numBlack < numWhite)
            {
                mess = "白の勝ちです";
            }
            else
            {
                mess = "引き分けです";
            }

            MessageBox.Show(mess);
        }
    }
}
