namespace GutenbergBookSearchApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.listBoxBooks = new System.Windows.Forms.ListBox();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(683, 22);
            this.textBoxSearch.TabIndex = 3;
            // 
            // listBoxBooks
            // 
            this.listBoxBooks.ItemHeight = 16;
            this.listBoxBooks.Location = new System.Drawing.Point(12, 40);
            this.listBoxBooks.Name = "listBoxBooks";
            this.listBoxBooks.Size = new System.Drawing.Size(400, 388);
            this.listBoxBooks.TabIndex = 2;
            this.listBoxBooks.SelectedIndexChanged += new System.EventHandler(this.listBoxBooks_SelectedIndexChanged);
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Location = new System.Drawing.Point(420, 40);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(368, 400);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 1;
            this.pictureBoxCover.TabStop = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(701, 9);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(87, 25);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.listBoxBooks);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "Form1";
            this.Text = "Gutenberg Book Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ListBox listBoxBooks;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button buttonSearch;
    }
}
