using System;
using SQLiteDemo.Models;

namespace SQLiteDemo.Interface
{
	public interface IActorRepository : IRepository<Actor>
	{
		Actor Get(int id);
	}
}
