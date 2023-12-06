using managefile;
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
using System.Xml.Linq;

namespace party
{
    public partial class SoloForm : Form
    {
        //RadioButton的list
        List<RadioButton> listRadioButton = new List<RadioButton>();
        //每轮的胜利者列表
        List<Member> listVectory;
        //参与总人数
        int numParticipants;
        //比赛轮数
        int rand;
        //本轮人数
        List<Member> membersInRand;

        //当前轮数
        int thisRand = 1;

        //幸运星
        Member? luckyStar;

        public SoloForm()
        {
            InitializeComponent();
        }

        public SoloForm(List<Member> members)
        {
            InitializeComponent();
            numParticipants = members.Count;
            rand = (int)Math.Log(numParticipants, 2) + 1;
            //第一轮人数
            membersInRand = members;

            //把所有RadioButton都装进List里面
            // 遍历 Form 中的所有控件
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Control control = Controls[i];

                // 如果是 Group 控件，执行相应的操作
                if (control is GroupBox groupBox)
                {
                    foreach (Control ctrl in groupBox.Controls)
                    {
                        // 如果是 radioButton 控件，执行相应的操作
                        if (ctrl is RadioButton radioButton)
                        {
                            listRadioButton.Add(radioButton);
                        }
                    }

                }
            }

            //处理存档文件
            //相对于当前工作目录的文件夹路径
            string relativeFolderPath = @".\data\SoloLog.txt";
            //获取当前工作目录
            string currentDirectory = Directory.GetCurrentDirectory();
            //构建完整路径
            string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

            try
            {
                //检查文件,如果存在
                if (File.Exists(folderPath))
                {
                    File.Delete(folderPath);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("打开存档文件失败", ex.Message);
            }
                    
            //第一轮初始化
            gameProcess(thisRand);

        }

        private void gameProcess(int thisRand)
        {
            labelRand.Text = "第" + thisRand + "轮";

            //奇数则找幸运星直接晋级
            if (membersInRand.Count % 2 != 0)
            {
                luckyStar = membersInRand[0];
                membersInRand.RemoveAt(0);
                labelLucky.Text = luckyStar.mName + "(" + luckyStar.mProfession + ")";
            }
            else
            {
                luckyStar = null;
                labelLucky.Text = "无";
            }
            //遍历本轮所有参赛选手
            int i = 0;
            foreach (Member member in membersInRand)
            {
                string name = member.mName;
                string profession = member.mProfession;

                string item = name + "(" + profession + ")";

                listRadioButton[i].Text = item;
                i++;
            }

            //存档
            archive(thisRand, luckyStar, membersInRand);
        }

        //下一轮的点击事件
        private void buttonNextRand_Click(object sender, EventArgs e)
        {
            //非最后一轮
            //胜利者列表
            listVectory = new List<Member>();
            //遍历所有group的radioButton是否全部选择过
            // 遍历 Form 中的所有控件
            bool flag = true;
            for (int i = Controls.Count - 1; i > Controls.Count - 1 - membersInRand.Count / 2; i--)
            {
                Control control = Controls[i];

                // 如果是 Group 控件，执行相应的操作
                if (control is GroupBox groupBox)
                {
                    bool flag2 = false;
                    foreach (Control ctrl in groupBox.Controls)
                    {
                        
                        // 如果是 radioButton 控件，执行相应的操作
                        if (ctrl is RadioButton radioButton)
                        {
                            if (radioButton.Checked)
                            {
                                //被选择意味着胜利，加入胜利者列表
                                flag2 = true;

                                string[] res = radioButton.Text.Split('(');
                                string name = res[0];
                                string profession = res[1].Split(')')[0];

                                Member member = new Member(name, profession);

                                listVectory.Add(member);
                                break;
                            }
                            
                        }
                        else
                        {
                            flag2 = true;
                        }
                        
                    }
                    if (!flag2)
                    {
                        flag = false;
                        break;
                    }                 
                }
            }
            if(!flag) 
            {
                MessageBox.Show("请确保所有组都决出了一个胜者");
                return;
            }

            //成功到这一步，表示胜者已经决出，将胜者存入到下一轮的参与者中
            //存入当前轮胜利者到log中
            archiveVectory(listVectory);
            membersInRand.Clear();
            membersInRand = listVectory;
            if(luckyStar != null)
            {
                membersInRand.Add(luckyStar);
            }

            //将列表中的人员按随机数打乱
            Random random = new Random();
            int n = membersInRand.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Member value = membersInRand[k];
                membersInRand[k] = membersInRand[n];
                membersInRand[n] = value;
            }

            //轮数+1
            thisRand++;
            //清空radioButton的按钮值
            for(int i = 0; i < listRadioButton.Count; i++)
            {
                listRadioButton[i].Text = "无";
                listRadioButton[i].Checked = false;
            }

            if(rand - thisRand >= 0 && membersInRand.Count > 1)
            {
                gameProcess(thisRand);
            }
            else
            {
                label1.Text = "本次的冠军是：";
                labelLucky.Text = membersInRand[0].mName + "(" + membersInRand[0].mProfession + ")";

                //写入
                string write = "";

                //相对于当前工作目录的文件夹路径
                string relativeFolderPath = @".\data\SoloLog.txt";
                //获取当前工作目录
                string currentDirectory = Directory.GetCurrentDirectory();
                //构建完整路径
                string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

                try
                {
                    using (StreamWriter writer = new StreamWriter(folderPath, true))
                    {
                        write = "本次比赛的冠军是：";
                        writer.WriteLine(write);

                        //胜利者
                        write = labelLucky.Text;
                        writer.WriteLine(write);
                    }
                    //写入到赛季记录文本中
                    ManageFile.WriteFile(membersInRand[0].mName, membersInRand[0].mProfession, "Log.txt");

                    buttonNextRand.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("写入失败", ex.Message);
                }
            }
        }

        //每轮文件记录战果
        private void archive(int rand, Member luckyStar, List<Member> members)
        {
            //相对于当前工作目录的文件夹路径
            string relativeFolderPath = @".\data\SoloLog.txt";
            //获取当前工作目录
            string currentDirectory = Directory.GetCurrentDirectory();
            //构建完整路径
            string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

            try
            {
                using (StreamWriter writer = new StreamWriter(folderPath, true))
                {
                    string write = "第" + rand + "轮：";
                    string gamer1 = "";
                    string gamer2 = "";

                    writer.WriteLine(write);

                    if (luckyStar != null)
                    {
                        write = "本轮的幸运星是" + luckyStar.mName + "(" + luckyStar.mProfession + ")";
                        writer.WriteLine(write);
                    }
                    for(int i = 0; i < members.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            gamer1 = members[i].mName + "(" + members[i].mProfession + ")";
                        }
                        else
                        {
                            gamer2 = members[i].mName + "(" + members[i].mProfession + ")";

                            write = gamer1 + " VS " + gamer2;
                            writer.WriteLine(write);
                        }
                    }
                    //插入间隔的空行
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入失败", ex.Message);
            }
        }
        
        //记录胜者
        private void archiveVectory(List<Member> members)
        {
            string write = "";

            //相对于当前工作目录的文件夹路径
            string relativeFolderPath = @".\data\SoloLog.txt";
            //获取当前工作目录
            string currentDirectory = Directory.GetCurrentDirectory();
            //构建完整路径
            string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

            try
            {
                using (StreamWriter writer = new StreamWriter(folderPath, true))
                {
                    write = "此轮胜利者为：";
                    writer.WriteLine(write);

                    //遍历胜利者列表
                    int i = 1;
                    write = "";
                    foreach (Member member in members)
                    {
                        string str = member.mName + "(" + member.mProfession + ")";
                        if(i % 4 != 0)
                        {
                            write += str + "\t";
                        }
                        else
                        {
                            write += str;
                            writer.WriteLine(write);
                            write = "";
                        }
                        i++;
                    }
                    writer.WriteLine(write);
                    writer.WriteLine("----------------------------------------------------------");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("写入失败", ex.Message);
            }
            
        }
    }
}
