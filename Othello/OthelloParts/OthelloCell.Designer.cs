namespace Othello.OthelloParts
{
    partial class OthelloCell
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.othelloPiece = new Othello.OthelloParts.OthelloPiece();
            this.SuspendLayout();
            // 
            // othelloPiece
            // 
            this.othelloPiece.Location = new System.Drawing.Point(3, 0);
            this.othelloPiece.Name = "othelloPiece";
            this.othelloPiece.PieceSize = new System.Drawing.Rectangle(0, 0, 50, 50);
            this.othelloPiece.PieceStatus = Othello.OthelloParts.OthelloPiece.PieceStatusKind.BLACK;
            this.othelloPiece.Size = new System.Drawing.Size(56, 56);
            this.othelloPiece.TabIndex = 0;
            this.othelloPiece.Text = "othelloPiece1";
            // 
            // OthelloCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.othelloPiece);
            this.Name = "OthelloCell";
            this.Size = new System.Drawing.Size(55, 55);
            this.ResumeLayout(false);

        }

        #endregion

        private OthelloPiece othelloPiece;
    }
}
