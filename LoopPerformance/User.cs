namespace LoopPerformance;

public class User
{
	private readonly string name;

	public User(string name)
	{
		this.name = name;
	}

	public string GetName()
	{
		return name;
	}
}

