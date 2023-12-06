namespace party
{
    partial class ManageMemForm
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
            labelContent = new Label();
            reNameButton = new Button();
            textRename = new TextBox();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // labelContent
            // 
            labelContent.AutoSize = true;
            labelContent.Location = new Point(27, 19);
            labelContent.Name = "labelContent";
            labelContent.Size = new Size(43, 17);
            labelContent.TabIndex = 0;
            labelContent.Text = "label1";
            // 
            // reNameButton
            // 
            reNameButton.Location = new Point(27, 68);
            reNameButton.Name = "reNameButton";
            reNameButton.Size = new Size(75, 23);
            reNameButton.TabIndex = 1;
            reNameButton.Text = "改名";
            reNameButton.UseVisualStyleBackColor = true;
            reNameButton.Click += reNameButton_Click;
            // 
            // textRename
            // 
            textRename.Location = new Point(27, 39);
            textRename.Name = "textRename";
            textRename.Size = new Size(100, 23);
            textRename.TabIndex = 2;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(187, 68);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "删除";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // ManageMemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 130);
            Controls.Add(deleteButton);
            Controls.Add(textRename);
            Controls.Add(reNameButton);
            Controls.Add(labelContent);
            Name = "ManageMemForm";
            Text = "成员管理";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelContent;
        private Button reNameButton;
        private TextBox textRename;
        private Button deleteButton;
    }
}