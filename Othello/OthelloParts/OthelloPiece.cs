using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello.OthelloParts
{
    /// <summary>
    /// オセロのコマ
    /// </summary>
    public partial class OthelloPiece : Control
    {
        public enum PieceStatusKind
        {
            NONE,
            BLACK,
            WHITE
        }

        private PieceStatusKind _pieceStatus = PieceStatusKind.NONE;
        /// <summary>
        /// コマの状態
        /// </summary>
        public PieceStatusKind PieceStatus
        {
            set
            {
                this._pieceStatus = value;
                this.DrawColor = value;
            }
            get
            {
                return this._pieceStatus;
            }
        }

        /// <summary>
        /// クリックしたときにどの色のコマを描くか。
        /// </summary>
        public PieceStatusKind DrawColor { get; set; }

        private Rectangle _pieceSize = new Rectangle(0, 0, 50, 50);
        public Rectangle PieceSize
        {
            set { this._pieceSize = value; }
            get { return this._pieceSize; }
        }

        private Brush _whiteColor = Brushes.White;
        public Brush WhiteColor
        {
            set { this._whiteColor = value; }
            get { return this._whiteColor; }
        }

        private Brush _blackColor = Brushes.Black;
        public Brush BlackColor
        {
            set { this._blackColor = value; }
            get { return this._blackColor; }
        }

        /// <summary>
        /// セル座標
        /// </summary>
        public Point CellIndex
        {
            get;
            set;
        }

        public delegate bool CellClicked(object sender, MouseEventArgs e);
        public event CellClicked PieceClicked;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OthelloPiece()
        {
            InitializeComponent();
            this.MouseClick += OthelloPiece_MouseClick;
        }

        /// <summary>
        /// マウスクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OthelloPiece_MouseClick(object sender, MouseEventArgs e)
        {
            bool result = PieceClicked(sender, e);

            if (!result)
                return;

            this.PieceStatus = this.DrawColor;
            Refresh();
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            switch (PieceStatus)
            {
                case PieceStatusKind.NONE:
                    DrawTransparent(pe);
                    break;
                case PieceStatusKind.BLACK:
                    DrawBlack(pe);
                    break;
                case PieceStatusKind.WHITE:
                    DrawWhite(pe);
                    break;
                default:
                    DrawTransparent(pe);
                    break;
            }

            pe.Dispose();
        }

        /// <summary>
        /// 白を描画
        /// </summary>
        private void DrawWhite(PaintEventArgs pe)
        {
            pe.Graphics.FillEllipse(this._whiteColor, this._pieceSize);
        }

        /// <summary>
        /// 黒を描画
        /// </summary>
        private void DrawBlack(PaintEventArgs pe)
        {
            pe.Graphics.FillEllipse(this._blackColor, this._pieceSize);
        }

        /// <summary>
        /// 透明色を描画
        /// </summary>
        /// <param name="pe"></param>
        private void DrawTransparent(PaintEventArgs pe)
        {
            pe.Graphics.FillEllipse(Brushes.Transparent, this._pieceSize);
        }
    }
}
