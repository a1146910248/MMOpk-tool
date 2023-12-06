namespace party
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MemberList = new ListView();
            gName = new ColumnHeader();
            Profession = new ColumnHeader();
            ManageMember = new GroupBox();
            buttonFind = new Button();
            textFind = new TextBox();
            button1 = new Button();
            textAddProffesion = new TextBox();
            textAddId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            refreshButton = new Button();
            groupSolo = new GroupBox();
            resetButton = new Button();
            buttonFindSolo = new Button();
            button3 = new Button();
            findSoloText = new TextBox();
            button2 = new Button();
            listSolo = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            labelNum = new Label();
            labelMemNum = new Label();
            ManageMember.SuspendLayout();
            groupSolo.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // MemberList
            // 
            MemberList.Columns.AddRange(new ColumnHeader[] { gName, Profession });
            MemberList.Location = new Point(17, 32);
            MemberList.Name = "MemberList";
            MemberList.Size = new Size(164, 97);
            MemberList.TabIndex = 0;
            MemberList.UseCompatibleStateImageBehavior = false;
            MemberList.View = View.Details;
            MemberList.MouseDoubleClick += MemberList_MouseDoubleClick;
            // 
            // gName
            // 
            gName.Text = "ID";
            gName.Width = 100;
            // 
            // Profession
            // 
            Profession.Text = "职业";
            Profession.TextAlign = HorizontalAlignment.Center;
            Profession.Width = 45;
            // 
            // ManageMember
            // 
            ManageMember.Controls.Add(labelMemNum);
            ManageMember.Controls.Add(labelNum);
            ManageMember.Controls.Add(buttonFind);
            ManageMember.Controls.Add(textFind);
            ManageMember.Controls.Add(button1);
            ManageMember.Controls.Add(textAddProffesion);
            ManageMember.Controls.Add(textAddId);
            ManageMember.Controls.Add(label2);
            ManageMember.Controls.Add(label1);
            ManageMember.Controls.Add(refreshButton);
            ManageMember.Controls.Add(MemberList);
            ManageMember.Location = new Point(12, 12);
            ManageMember.Name = "ManageMember";
            ManageMember.Size = new Size(316, 185);
            ManageMember.TabIndex = 1;
            ManageMember.TabStop = false;
            ManageMember.Text = "成员管理";
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(215, 106);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(44, 23);
            buttonFind.TabIndex = 8;
            buttonFind.Text = "查找";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // textFind
            // 
            textFind.Location = new Point(187, 77);
            textFind.Name = "textFind";
            textFind.Size = new Size(100, 23);
            textFind.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(243, 144);
            button1.Name = "button1";
            button1.Size = new Size(44, 23);
            button1.TabIndex = 6;
            button1.Text = "添加";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textAddProffesion
            // 
            textAddProffesion.Location = new Point(177, 142);
            textAddProffesion.Name = "textAddProffesion";
            textAddProffesion.Size = new Size(50, 23);
            textAddProffesion.TabIndex = 5;
            // 
            // textAddId
            // 
            textAddId.Location = new Point(36, 142);
            textAddId.Name = "textAddId";
            textAddId.Size = new Size(100, 23);
            textAddId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 147);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 3;
            label2.Text = "职业：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 145);
            label1.Name = "label1";
            label1.Size = new Size(33, 17);
            label1.TabIndex = 2;
            label1.Text = "ID：";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(201, 32);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 1;
            refreshButton.Text = "刷新列表";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // groupSolo
            // 
            groupSolo.Controls.Add(resetButton);
            groupSolo.Controls.Add(buttonFindSolo);
            groupSolo.Controls.Add(button3);
            groupSolo.Controls.Add(findSoloText);
            groupSolo.Controls.Add(button2);
            groupSolo.Controls.Add(listSolo);
            groupSolo.Location = new Point(12, 212);
            groupSolo.Name = "groupSolo";
            groupSolo.Size = new Size(316, 173);
            groupSolo.TabIndex = 2;
            groupSolo.TabStop = false;
            groupSolo.Text = "擂台争霸";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(46, 125);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(75, 23);
            resetButton.TabIndex = 11;
            resetButton.Text = "重置";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // buttonFindSolo
            // 
            buttonFindSolo.Location = new Point(215, 80);
            buttonFindSolo.Name = "buttonFindSolo";
            buttonFindSolo.Size = new Size(44, 23);
            buttonFindSolo.TabIndex = 10;
            buttonFindSolo.Text = "查找";
            buttonFindSolo.UseVisualStyleBackColor = true;
            buttonFindSolo.Click += buttonFindSolo_Click;
            // 
            // button3
            // 
            button3.Location = new Point(215, 109);
            button3.Name = "button3";
            button3.Size = new Size(44, 23);
            button3.TabIndex = 10;
            button3.Text = "开始";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // findSoloText
            // 
            findSoloText.Location = new Point(187, 51);
            findSoloText.Name = "findSoloText";
            findSoloText.Size = new Size(100, 23);
            findSoloText.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(215, 22);
            button2.Name = "button2";
            button2.Size = new Size(44, 23);
            button2.TabIndex = 9;
            button2.Text = "添加";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listSolo
            // 
            listSolo.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listSolo.Location = new Point(12, 22);
            listSolo.Name = "listSolo";
            listSolo.Size = new Size(164, 97);
            listSolo.TabIndex = 9;
            listSolo.UseCompatibleStateImageBehavior = false;
            listSolo.View = View.Details;
            listSolo.MouseDown += listSolo_MouseDown;
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(32, 19);
            deleteToolStripMenuItem.Text = "删除";
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // labelNum
            // 
            labelNum.AutoSize = true;
            labelNum.Location = new Point(200, 56);
            labelNum.Name = "labelNum";
            labelNum.Size = new Size(44, 17);
            labelNum.TabIndex = 9;
            labelNum.Text = "人数：";
            // 
            // labelMemNum
            // 
            labelMemNum.AutoSize = true;
            labelMemNum.Location = new Point(233, 57);
            labelMemNum.Name = "labelMemNum";
            labelMemNum.Size = new Size(15, 17);
            labelMemNum.TabIndex = 10;
            labelMemNum.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 399);
            Controls.Add(groupSolo);
            Controls.Add(ManageMember);
            Name = "Form1";
            Text = "帮会活动管理";
            ManageMember.ResumeLayout(false);
            ManageMember.PerformLayout();
            groupSolo.ResumeLayout(false);
            groupSolo.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ListSolo_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ListView MemberList;
        private GroupBox ManageMember;
        private ColumnHeader gName;
        private ColumnHeader Profession;
        private Button refreshButton;
        private Button button1;
        private TextBox textAddProffesion;
        private TextBox textAddId;
        private Label label2;
        private Label label1;
        private Button buttonFind;
        private TextBox textFind;
        private GroupBox groupSolo;
        private Button button2;
        private ListView listSolo;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button button3;
        private Button buttonFindSolo;
        private TextBox findSoloText;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button resetButton;
        private Label labelMemNum;
        private Label labelNum;
    }
}