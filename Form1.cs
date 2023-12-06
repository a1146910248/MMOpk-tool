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

            //�򿪴�ų�Ա���ļ���
            members = ManageFile.GetMemberDictionary();
            //����List View
            fullListView(members);
            //����data�ļ���
            ManageFile.newFileDirectory("data");

        }

        //���ListView
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
                MessageBox.Show("��ǰû���κγ�Ա��");
            }
            labelMemNum.Text = members.Count.ToString();
        }

        //ˢ�³�Ա�б�
        private void refresh()
        {
            members = ManageFile.GetMemberDictionary();
            //����List View
            fullListView(members);
        }
        //ˢ�³�Ա�б�
        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }


        //��ӳ�Ա�¼�
        private void button1_Click(object sender, EventArgs e)
        {
            if (textAddId.Text == "")
            {
                MessageBox.Show("���������ID��", "", MessageBoxButtons.OK);
                return;
            }
            if (textAddProffesion.Text == "")
            {
                MessageBox.Show("������������ɣ�", "", MessageBoxButtons.OK);
                return;
            }
            //���Ѿ����������
            foreach (var member in members)
            {
                if (member.Value.mName == textAddId.Text)
                {
                    MessageBox.Show("������Ѿ����ڣ�", "", MessageBoxButtons.OK);
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

        //��ѯ
        private void find(ListView listView, TextBox textBox)
        {
            // ȡ���������ѡ��״̬
            foreach (ListViewItem item in listView.SelectedItems)
            {
                item.Selected = false;
            }

            if (textBox.Text == "")
            {
                MessageBox.Show("���������ID��", "", MessageBoxButtons.OK);
                return;
            }

            string name = textBox.Text;
            name = name.Trim();

            for (int i = 0; i < listView.Items.Count; i++)
            {
                //if (listView.Items[i].Text == name) //��ȫƥ��
                if (CheckKeywordMatch(listView.Items[i].Text, name))
                {
                    listView.Items[i].Selected = true;
                    listView.Items[i].EnsureVisible();
                    return;
                }
            }

            MessageBox.Show("��Ҳ����ڣ�", "", MessageBoxButtons.OK);
            return;
        }

        //�������
        private static bool CheckKeywordMatch(string targetString, string keyword)
        {
            //ʹ��Regex.IsMatch����ƥ��
            string  pattern = Regex.Escape(keyword);
            return Regex.IsMatch(targetString, pattern, RegexOptions.IgnoreCase);
        }

        //��ѯ�¼�
        private void buttonFind_Click(object sender, EventArgs e)
        {
            find(MemberList, textFind);
        }

        //��Ա��˫���¼�
        private void MemberList_MouseDoubleClick(object sender, EventArgs e)
        {
            // ��ȡ˫���� Item
            ListViewItem item = MemberList.SelectedItems.Count > 0 ? MemberList.SelectedItems[0] : null;

            if (item != null)
            {
                Form form = new ManageMemForm(item.Text);
                form.ShowDialog();
            }
            refresh();
        }

        //�����̨���Բ�����Ա
        private void button2_Click(object sender, EventArgs e)
        {
            //����Ӵ���
            Form form = new AddForm(members);
            form.ShowDialog();

            //�����Ӻ�Ὣ�������soloMembers��
            if (soloMembers.Count > 0)
            {
                foreach (var member in soloMembers)
                {
                    string name = member.Value.mName;

                    //����б����Ѵ���������
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

        //��ѯ�б����Ƿ�����ظ��Ľ�ɫ
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

        //soloѡ�ֲ�ѯ
        private void buttonFindSolo_Click(object sender, EventArgs e)
        {
            find(listSolo, findSoloText);
        }

        //��ʼ������
        private void button3_Click(object sender, EventArgs e)
        {
            //������������Ϊż��
            if (listSolo.Items.Count < 2)
            {
                MessageBox.Show("��������������ڵ���2��", "", MessageBoxButtons.OK);
                return;
            }

            //��׼���õ���Ա���뵽�б���
            preparedSoloMember = new List<Member>();
            int i = 0;
            foreach (ListViewItem item in listSolo.Items)
            {
                string name = item.SubItems[0].Text;
                string profession = item.SubItems[1].Text;

                Member member = new Member(name, profession);

                preparedSoloMember.Add(member);
            }

            //���б��е���Ա�����������
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

            //��solo����
            //����Ӵ���
            Form form = new SoloForm(preparedSoloMember);
            form.ShowDialog();

        }

        private void listSolo_MouseDown(object sender, MouseEventArgs e)
        {
            // ����Ƿ�Ϊ�Ҽ����
            if (e.Button == MouseButtons.Right)
            {
                // ��ȡ�һ�λ�õ� ListViewItem
                ListViewItem clickedItem = listSolo.GetItemAt(e.X, e.Y);

                // �����ѡ�е� ListViewItem����ʾ�����Ĳ˵�
                if (clickedItem != null)
                {
                    contextMenuStrip1.Show(listSolo, e.Location);
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ɾ��ѡ�е���
            if (listSolo.SelectedItems.Count > 0)
            {
                for (int i = listSolo.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem selectedItem = listSolo.SelectedItems[i];
                    listSolo.Items.Remove(selectedItem);
                }
            }
        }

        //����listSolo
        private void resetButton_Click(object sender, EventArgs e)
        {
            // ��������ʾһ����Ϣ�����û�ѡ���ǡ��򡰷�
            DialogResult result = MessageBox.Show("��ȷ��Ҫ���ò����б���", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // �����û�ѡ��Ľ��
            if (result == DialogResult.Yes)
            {
                //����
                listSolo.Items.Clear();
            }
        }
    }
}