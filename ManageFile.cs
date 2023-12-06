using membership;

namespace managefile
{
	public class ManageFile
	{
		//�ļ��в�������ȡ��Ա��Ϣ
		public static Dictionary<int, membership.Member> GetMemberDictionary()
		{
			//�����ֵ�
			Dictionary<int, membership.Member> dicMember = new Dictionary<int, membership.Member>();
			//����ڵ�ǰ����Ŀ¼���ļ���·��
			string relativeFolderPath = @".\members.txt";
			//��ȡ��ǰ����Ŀ¼
			string currentDirectory = Directory.GetCurrentDirectory();
			//��������·��
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);
			try
			{
				//����ļ�
				if (File.Exists(folderPath))
				{
					//��ȡ
					using (StreamReader reader = new StreamReader(folderPath))
					{
						string line;
						int i = 0;
						while ((line = reader.ReadLine()) != null)
						{
							//�ַ�����-�ָ�
							string[] memberMassage = line.Split('-');
							if (memberMassage.Length == 2)
							{
								//����ṹȻ����뵽�ֵ�
								Member member = new Member(memberMassage[0], memberMassage[1]);
								dicMember.Add(i, member);
							}
							i++;
						}
					}
				}
				else
				{
					//û���ļ��ʹ������ļ�
					using (StreamWriter writer = new StreamWriter(folderPath))
					{
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("��ȡ�ļ�ʧ��", ex.Message);
			}

			return dicMember;
		}

		//д���ļ���
		public static void WriteFile(string name, string profession, string fileName)
		{
			//����ڵ�ǰ����Ŀ¼���ļ���·��
			string relativeFolderPath = @".\" + fileName;
			//��ȡ��ǰ����Ŀ¼
			string currentDirectory = Directory.GetCurrentDirectory();
			//��������·��
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			try
			{
				using (StreamWriter writer = new StreamWriter(folderPath,true))
				{
					if(fileName == "members.txt")
					{
						//�ַ���ȥ�ո�
						name = name.Trim();
						profession = profession.Trim();
						string write = name + "-" + profession;
						writer.WriteLine(write);
					}
					else
					{
						DateTime now = DateTime.Now;
						string time = now.ToString("yyyy-MM-dd");
						string write = time + "��������̨���Թھ���-" + name + "-" + profession;
						writer.WriteLine(write);
					}
					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("д��ʧ��", ex.Message);
			}
		}

		//ɾ������,����ɾ����ɫ�����ɣ�û���ҵ��򷵻�""
		public static string deleteMember(string name)
		{
			//����ڵ�ǰ����Ŀ¼���ļ���·��
			string relativeFolderPath = @".\members.txt";
			//��ȡ��ǰ����Ŀ¼
			string currentDirectory = Directory.GetCurrentDirectory();
			//��������·��
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			try
			{
				//��ȡ���е���
				string[] lines = File.ReadAllLines(folderPath);

				//����������
				for(int i = 0; i < lines.Length; i++)
				{
					string line = lines[i];
					string[] item = line.Split('-');
					string id = item[0];
					
					//�����ȡ��id����Ҫɾ����name
					if(id == name)
					{
						lines = RemoveLine(lines, i);

						//���޸ĺ������д���ļ�
						File.WriteAllLines(folderPath, lines);
						//���ֲ��ظ�������ֱ�ӷ���
						return item[1];
					}
				}
				MessageBox.Show("û���ҵ���Ӧ��ɫ��" );
				return "";
			}
			catch(Exception ex)
			{
				MessageBox.Show("ɾ����ʧ�ܣ�" + ex);
				return "";
			}
		}

		// �Ƴ������е�ָ����
		static string[] RemoveLine(string[] lines, int lineNumber)
		{
			// ����һ���µ��������洢�޸ĺ������
			string[] newLines = new string[lines.Length - 1];

			// ����ԭʼ�������ݣ�����Ҫɾ������
			for (int i = 0, j = 0; i < lines.Length; i++)
			{
				if (i != lineNumber) // ������Ҫɾ������
				{
					newLines[j] = lines[i];
					j++;
				}
			}

			return newLines;
		}

		// ����Id��ѯ
		public static bool select(string name)
		{
			//����ڵ�ǰ����Ŀ¼���ļ���·��
			string relativeFolderPath = @".\members.txt";
			//��ȡ��ǰ����Ŀ¼
			string currentDirectory = Directory.GetCurrentDirectory();
			//��������·��
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			try
			{
				//��ȡ���е���
				string[] lines = File.ReadAllLines(folderPath);

				//����������
				for (int i = 0; i < lines.Length; i++)
				{
					string line = lines[i];
					string id = line.Split('-')[0];

					//�����ȡ��id����Ҫɾ����name
					if (id == name)
					{
						return true;
					}
				}
			}catch(Exception ex) 
			{
				MessageBox.Show("��ѯʧ��" + ex);
			}

			return false;
		}

		public static void newFileDirectory(string pathName)
		{
			//����ڵ�ǰ����Ŀ¼���ļ���·��
			string relativeFolderPath = @".\" + pathName;
			//��ȡ��ǰ����Ŀ¼
			string currentDirectory = Directory.GetCurrentDirectory();
			//��������·��
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			//�ļ��в������򴴽�
			if ( !Directory.Exists(folderPath))
			{
				// ʹ�� CreateDirectory �����½��ļ���
				Directory.CreateDirectory(folderPath);
			}
		}
	}
}