namespace party
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listSolo = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            buttonFind = new Button();
            textFind = new TextBox();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // listSolo
            // 
            listSolo.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listSolo.Location = new Point(12, 12);
            listSolo.Name = "listSolo";
            listSolo.Size = new Size(164, 97);
            listSolo.TabIndex = 10;
            listSolo.UseCompatibleStateImageBehavior = false;
            listSolo.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "职业";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 45;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(232, 51);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(44, 23);
            buttonFind.TabIndex = 13;
            buttonFind.Text = "查找";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // textFind
            // 
            textFind.Location = new Point(206, 22);
            textFind.Name = "textFind";
            textFind.Size = new Size(100, 23);
            textFind.TabIndex = 12;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(232, 86);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(44, 23);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "添加";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 131);
            Controls.Add(buttonFind);
            Controls.Add(textFind);
            Controls.Add(buttonAdd);
            Controls.Add(listSolo);
            Name = "AddForm";
            Text = "AddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listSolo;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button buttonFind;
        private TextBox textFind;
        private Button buttonAdd;
    }
}