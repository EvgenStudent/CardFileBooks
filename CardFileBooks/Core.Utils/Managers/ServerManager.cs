namespace Core.Utils.Managers
{
	public class ServerManager : IServerManager
	{
		public BookManager BookManager { get; private set; }

		public ServerManager()
		{
			BookManager = new BookManager();
		}
	}
}