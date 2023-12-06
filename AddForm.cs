using membership;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace party
{
    public partial class AddForm : Form
    {
   
        public AddForm()
        {
            InitializeComponent();
        }

        public AddForm(Dictionary<int, Member> members)
        {
            InitializeComponent();
            //填充进List View
            fullListView(members);

            //soloMembers
            Form1.soloMembers.Clear();
        }

        //填充ListView
        private void fullListView(Dictionary<int, Member> members)
        {
            listSolo.Items.Clear();
            if (members.Count > 0)
            {
                foreach (var member in members)
                {

                    ListViewItem item = new ListViewItem(member.Value.mName);
                    item.SubItems.Add(member.Value.mProfession);

                    listSolo.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("当前没有任何成员！");
            }
        }

        //查询
        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (textFind.Text == "")
            {
                MessageBox.Show("请输入玩家ID！", "", MessageBoxButtons.OK);
                return;
            }

            string name = textFind.Text;
            name = name.Trim();

            for (int i = 0; i < listSolo.Items.Count; i++)
            {
                if (listSolo.Items[i].Text == name)
                {
                    listSolo.Items[i].Selected = true;
                    listSolo.Items[i].EnsureVisible();
                    return;
                }
            }

            MessageBox.Show("玩家不存在！", "", MessageBoxButtons.OK);
            return;
        }

        //添加进成员
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            //遍历所有选中的item，加入进字典
            foreach (ListViewItem item in listSolo.SelectedItems)
            {
                string name = item.SubItems[0].Text;
                string profession = item.SubItems[1].Text;
                Member member = new Member(name, profession);

                Form1.soloMembers.Add(i, member);
                i++;
            }
            
            this.Close();
        }
    }
}
