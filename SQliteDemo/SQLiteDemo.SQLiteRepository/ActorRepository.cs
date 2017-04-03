using System;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;
using SQLiteDemo.Interface;
using SQLiteDemo.Models;

namespace SQLiteDemo.SQLiteRepository
{
	public class ActorRepository : IActorRepository
	{
		SQLiteConnection sqlite;
		public ActorRepository(string databasePath)
		{
			Debug.WriteLine("databasePath : {0}", databasePath);
			sqlite = new SQLiteConnection(databasePath);

			InitTable();

		}

		private void InitTable()
		{
			string sqlcmd = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name=?";
			var result = this.sqlite.ExecuteScalar<int>(sqlcmd, "Actor");
			if (result == 0)
			{
				this.sqlite.CreateTable<Actor>();
			}
		}

		public void Delete(Actor entity)
		{
			this.sqlite.Delete<Actor>(entity.ID);
		}

		public void DeleteAll()
		{
			this.sqlite.DeleteAll<Actor>();
		}

		public void Dispose()
		{
			this.sqlite.Dispose();
		}

		public Actor Get(int actorId)
		{
			return this.sqlite.Get<Actor>(actorId);
		}

		public IList<Actor> GetAll()
		{
			return this.sqlite.Query<Actor>("SELECT * FROM Actor");
		}

		public void Insert(Actor entity)
		{
			this.sqlite.Insert(entity);
		}

		public void InsertAll(IList<Actor> entities)
		{
			this.sqlite.InsertAll(entities);
		}

		public void Update(Actor entity)
		{
			this.sqlite.Update(entity);
		}

		public void UpdateAll(IList<Actor> entities)
		{
			this.sqlite.UpdateAll(entities);
		}
	}
}
