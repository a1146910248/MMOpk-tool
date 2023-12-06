namespace membership
{
	public class Member
	{
		public string mName { get; set; }
		public string mProfession { get; set; }
		public Member(string mName, string mProfession) 
		{
			//ID
			this.mName = mName;
			//цееи
			this.mProfession = mProfession;
		}
	}
}