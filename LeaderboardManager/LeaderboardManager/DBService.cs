using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderboardManager.Models;
using ServiceStack.Redis;

namespace LeaderboardManager
{
	class DBService
	{
		//Reworked to comply with Redis recommended usage principles
		private static readonly Lazy<RedisManagerPool> _redisManager = new Lazy<RedisManagerPool>(() => { return new RedisManagerPool("localhost:6379"); });

		public void AddNewLeaderboard(Leaderboard leaderboard)
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				var leaderboards = redis.As<Leaderboard>();
				leaderboard.Id = leaderboards.GetNextSequence();
				leaderboards.Store(leaderboard);
			}
		}

		public void UpdateLeaderboard(Leaderboard leaderboard)
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				var leaderboards = redis.As<Leaderboard>();
				leaderboards.Store(leaderboard);
			}
		}

		public List<Leaderboard> GetAllLeaderboards()
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				var leaderboards = redis.As<Leaderboard>();
				IList<Leaderboard> result = leaderboards.GetAll();
				return (List<Leaderboard>)result;
			}
		}

		public Leaderboard GetLeaderboardById(long id)
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				var leaderboards = redis.As<Leaderboard>();
				Leaderboard result = leaderboards.GetById(id);
				return result;
			}
		}

		public void DeleteLeaderboardById(long id)
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				var leaderboards = redis.As<Leaderboard>();
				leaderboards.DeleteById(id);
			}
		}
	}
}
