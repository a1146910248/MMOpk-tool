using membership;
using managefile;
using System.Text.RegularExpressions;

namespace party
{
    public partial class Form1 : Form
    {
        Dictionary<int, Member> members;
        List<Member> preparedSoloMember;
        public static Dictionary<int, Member> soloMembers = new Dictionary<int, Member>();
        public Form1()
        {
            InitializeComponent();

            //打开存放成员的文件夹
            members = ManageFile.GetMemberDictionary();
            //填充进List View
            fullListView(members);
            //创建data文件夹
            ManageFile.newFileDirectory("data");

        }

        //填充ListView
        private void fullListView(Dictionary<int, Member> members)
        {
            MemberList.Items.Clear();
            if (members.Count > 0)
            {
                foreach (var member in members)
                {

                    ListViewItem item = new ListViewItem(member.Value.mName);
                    item.SubItems.Add(member.Value.mProfession);

                    MemberList.Items.Add(item);

                }
            }
            else
            {
                MessageBox.Show("当前没有任何成员！");
            }
            labelMemNum.Text = members.Count.ToString();
        }

        //刷新成员列表
        private void refresh()
        {
            members = ManageFile.GetMemberDictionary();
            //填充进List View
            fullListView(members);
        }
        //刷新成员列表
        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }


        //添加成员事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (textAddId.Text == "")
            {
                MessageBox.Show("请输入玩家ID！", "", MessageBoxButtons.OK);
                return;
            }
            if (textAddProffesion.Text == "")
            {
                MessageBox.Show("请输入玩家门派！", "", MessageBoxButtons.OK);
                return;
            }
            //若已经存在则不添加
            foreach (var member in members)
            {
                if (member.Value.mName == textAddId.Text)
                {
                    MessageBox.Show("该玩家已经存在！", "", MessageBoxButtons.OK);
                    return;
                }
            }

            try
            {
                ManageFile.WriteFile(textAddId.Text, textAddProffesion.Text, "members.txt");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //查询
        private void find(ListView listView, TextBox textBox)
        {
            // 取消所有项的选中状态
            foreach (ListViewItem item in listView.SelectedItems)
            {
                item.Selected = false;
            }

            if (textBox.Text == "")
            {
                MessageBox.Show("请输入玩家ID！", "", MessageBoxButtons.OK);
                return;
            }

            string name = textBox.Text;
            name = name.Trim();

            for (int i = 0; i < listView.Items.Count; i++)
            {
                //if (listView.Items[i].Text == name) //完全匹配
                if (CheckKeywordMatch(listView.Items[i].Text, name))
                {
                    listView.Items[i].Selected = true;
                    listView.Items[i].EnsureVisible();
                    return;
                }
            }

            MessageBox.Show("玩家不存在！", "", MessageBoxButtons.OK);
            return;
        }

        //正则查找
        private static bool CheckKeywordMatch(string targetString, string keyword)
        {
            //使用Regex.IsMatch进行匹配
            string  pattern = Regex.Escape(keyword);
            return Regex.IsMatch(targetString, pattern, RegexOptions.IgnoreCase);
        }

        //查询事件
        private void buttonFind_Click(object sender, EventArgs e)
        {
            find(MemberList, textFind);
        }

        //成员的双击事件
        private void MemberList_MouseDoubleClick(object sender, EventArgs e)
        {
            // 获取双击的 Item
            ListViewItem item = MemberList.SelectedItems.Count > 0 ? MemberList.SelectedItems[0] : null;

            if (item != null)
            {
                Form form = new ManageMemForm(item.Text);
                form.ShowDialog();
            }
            refresh();
        }

        //添加擂台争霸参赛成员
        private void button2_Click(object sender, EventArgs e)
        {
            //打开添加窗口
            Form form = new AddForm(members);
            form.ShowDialog();

            //点击添加后会将结果存入soloMembers中
            if (soloMembers.Count > 0)
            {
                foreach (var member in soloMembers)
                {
                    string name = member.Value.mName;

                    //如果列表中已存在则跳过
                    if (isExist(name, listSolo))
                    {
                        continue;
                    }

                    ListViewItem item = new ListViewItem(member.Value.mName);
                    item.SubItems.Add(member.Value.mProfession);

                    listSolo.Items.Add(item);

                }
            }

        }

        //查询列表中是否存在重复的角色
        private bool isExist(string name, ListView listView)
        {
            for (int i = 0; i < listView.Items.Count; i++)
            {
                if (listView.Items[i].Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        //solo选手查询
        private void buttonFindSolo_Click(object sender, EventArgs e)
        {
            find(listSolo, findSoloText);
        }

        //开始争霸赛
        private void button3_Click(object sender, EventArgs e)
        {
            //参赛人数必须为偶数
            if (listSolo.Items.Count < 2)
            {
                MessageBox.Show("参赛人数必须大于等于2！", "", MessageBoxButtons.OK);
                return;
            }

            //将准备好的人员加入到列表中
            preparedSoloMember = new List<Member>();
            int i = 0;
            foreach (ListViewItem item in listSolo.Items)
            {
                string name = item.SubItems[0].Text;
                string profession = item.SubItems[1].Text;

                Member member = new Member(name, profession);

                preparedSoloMember.Add(member);
            }

            //将列表中的人员按随机数打乱
            Random random = new Random();
            int n = preparedSoloMember.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Member value = preparedSoloMember[k];
                preparedSoloMember[k] = preparedSoloMember[n];
                preparedSoloMember[n] = value;
            }

            //打开solo界面
            //打开添加窗口
            Form form = new SoloForm(preparedSoloMember);
            form.ShowDialog();

        }

        private void listSolo_MouseDown(object sender, MouseEventArgs e)
        {
            // 检查是否为右键点击
            if (e.Button == MouseButtons.Right)
            {
                // 获取右击位置的 ListViewItem
                ListViewItem clickedItem = listSolo.GetItemAt(e.X, e.Y);

                // 如果有选中的 ListViewItem，显示上下文菜单
                if (clickedItem != null)
                {
                    contextMenuStrip1.Show(listSolo, e.Location);
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 删除选中的项
            if (listSolo.SelectedItems.Count > 0)
            {
                for (int i = listSolo.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem selectedItem = listSolo.SelectedItems[i];
                    listSolo.Items.Remove(selectedItem);
                }
            }
        }

        //重置listSolo
        private void resetButton_Click(object sender, EventArgs e)
        {
            // 创建并显示一个消息框，让用户选择“是”或“否”
            DialogResult result = MessageBox.Show("你确定要重置参赛列表吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 处理用户选择的结果
            if (result == DialogResult.Yes)
            {
                //重置
                listSolo.Items.Clear();
            }
        }
    }
}