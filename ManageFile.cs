using membership;

namespace managefile
{
	public class ManageFile
	{
		//文件夹操作，读取成员信息
		public static Dictionary<int, membership.Member> GetMemberDictionary()
		{
			//创建字典
			Dictionary<int, membership.Member> dicMember = new Dictionary<int, membership.Member>();
			//相对于当前工作目录的文件夹路径
			string relativeFolderPath = @".\members.txt";
			//获取当前工作目录
			string currentDirectory = Directory.GetCurrentDirectory();
			//构建完整路径
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);
			try
			{
				//检查文件
				if (File.Exists(folderPath))
				{
					//读取
					using (StreamReader reader = new StreamReader(folderPath))
					{
						string line;
						int i = 0;
						while ((line = reader.ReadLine()) != null)
						{
							//字符串以-分割
							string[] memberMassage = line.Split('-');
							if (memberMassage.Length == 2)
							{
								//构造结构然后加入到字典
								Member member = new Member(memberMassage[0], memberMassage[1]);
								dicMember.Add(i, member);
							}
							i++;
						}
					}
				}
				else
				{
					//没有文件就创建空文件
					using (StreamWriter writer = new StreamWriter(folderPath))
					{
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("读取文件失败", ex.Message);
			}

			return dicMember;
		}

		//写入文件夹
		public static void WriteFile(string name, string profession, string fileName)
		{
			//相对于当前工作目录的文件夹路径
			string relativeFolderPath = @".\" + fileName;
			//获取当前工作目录
			string currentDirectory = Directory.GetCurrentDirectory();
			//构建完整路径
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			try
			{
				using (StreamWriter writer = new StreamWriter(folderPath,true))
				{
					if(fileName == "members.txt")
					{
						//字符串去空格
						name = name.Trim();
						profession = profession.Trim();
						string write = name + "-" + profession;
						writer.WriteLine(write);
					}
					else
					{
						DateTime now = DateTime.Now;
						string time = now.ToString("yyyy-MM-dd");
						string write = time + "：本届擂台争霸冠军是-" + name + "-" + profession;
						writer.WriteLine(write);
					}
					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("写入失败", ex.Message);
			}
		}

		//删除操作,返回删除角色的门派，没有找到则返回""
		public static string deleteMember(string name)
		{
			//相对于当前工作目录的文件夹路径
			string relativeFolderPath = @".\members.txt";
			//获取当前工作目录
			string currentDirectory = Directory.GetCurrentDirectory();
			//构建完整路径
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			try
			{
				//读取所有的行
				string[] lines = File.ReadAllLines(folderPath);

				//遍历所有行
				for(int i = 0; i < lines.Length; i++)
				{
					string line = lines[i];
					string[] item = line.Split('-');
					string id = item[0];
					
					//如果读取的id等于要删除的name
					if(id == name)
					{
						lines = RemoveLine(lines, i);

						//将修改后的内容写回文件
						File.WriteAllLines(folderPath, lines);
						//名字不重复，所以直接返回
						return item[1];
					}
				}
				MessageBox.Show("没有找到对应角色！" );
				return "";
			}
			catch(Exception ex)
			{
				MessageBox.Show("删除行失败！" + ex);
				return "";
			}
		}

		// 移除数组中的指定行
		static string[] RemoveLine(string[] lines, int lineNumber)
		{
			// 创建一个新的数组来存储修改后的内容
			string[] newLines = new string[lines.Length - 1];

			// 复制原始数组内容，跳过要删除的行
			for (int i = 0, j = 0; i < lines.Length; i++)
			{
				if (i != lineNumber) // 不复制要删除的行
				{
					newLines[j] = lines[i];
					j++;
				}
			}

			return newLines;
		}

		// 根据Id查询
		public static bool select(string name)
		{
			//相对于当前工作目录的文件夹路径
			string relativeFolderPath = @".\members.txt";
			//获取当前工作目录
			string currentDirectory = Directory.GetCurrentDirectory();
			//构建完整路径
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			try
			{
				//读取所有的行
				string[] lines = File.ReadAllLines(folderPath);

				//遍历所有行
				for (int i = 0; i < lines.Length; i++)
				{
					string line = lines[i];
					string id = line.Split('-')[0];

					//如果读取的id等于要删除的name
					if (id == name)
					{
						return true;
					}
				}
			}catch(Exception ex) 
			{
				MessageBox.Show("查询失败" + ex);
			}

			return false;
		}

		public static void newFileDirectory(string pathName)
		{
			//相对于当前工作目录的文件夹路径
			string relativeFolderPath = @".\" + pathName;
			//获取当前工作目录
			string currentDirectory = Directory.GetCurrentDirectory();
			//构建完整路径
			string folderPath = Path.Combine(currentDirectory, relativeFolderPath);

			//文件夹不存在则创建
			if ( !Directory.Exists(folderPath))
			{
				// 使用 CreateDirectory 方法新建文件夹
				Directory.CreateDirectory(folderPath);
			}
		}
	}
}