using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using managefile;
using membership;

namespace party
{
    public partial class ManageMemForm : Form
    {
        private string manageObject;
        public ManageMemForm()
        {
            InitializeComponent();
        }
        public ManageMemForm(string name)
        {
            InitializeComponent();
            manageObject = name;
            labelContent.Text = "请选择要对 " + name + " 做的操作：";
        }

        //改名事件
        private void reNameButton_Click(object sender, EventArgs e)
        {
            // 创建并显示一个消息框，让用户选择“是”或“否”
            DialogResult result = MessageBox.Show("你确定要修改用户名 "+ manageObject +" 吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 处理用户选择的结果
            if (result == DialogResult.Yes)
            {
                //改名即删除再重写
                string profession = ManageFile.deleteMember(manageObject);

                if(textRename.Text == "") 
                {
                    MessageBox.Show("请输入玩家ID！", "", MessageBoxButtons.OK);
                    return;
                }
                //查找已存在id，重名不予修改
                if (ManageFile.select(textRename.Text))
                {
                    MessageBox.Show("玩家ID已存在！", "", MessageBoxButtons.OK);
                    return;
                }

                //添加
                if (profession != "")
                { 
                    ManageFile.WriteFile(textRename.Text, profession , "members.txt");
                    MessageBox.Show("修改成功！", "", MessageBoxButtons.OK);
                }

            }    
        }

        //删除事件
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 创建并显示一个消息框，让用户选择“是”或“否”
            DialogResult result = MessageBox.Show("你确定要删除用户 " + manageObject + " 吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 处理用户选择的结果
            if (result == DialogResult.Yes)
            {
                //删除
                string flag = ManageFile.deleteMember(manageObject);

                if(flag != "")
                {
                    MessageBox.Show("删除成功！", "", MessageBoxButtons.OK);
                }
            }
        }

    }
}
