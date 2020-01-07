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
		private readonly RedisManagerPool _redisManager = new RedisManagerPool("localhost:6379");

		public void AddNewLeaderboard(Leaderboard leaderboard)
		{
			IRedisClient redis = _redisManager.GetClient();
			var leaderboards = redis.As<Leaderboard>();
			leaderboard.Id = leaderboards.GetNextSequence();
			leaderboards.Store(leaderboard);
		}

		public void UpdateLeaderboard(Leaderboard leaderboard)
		{
			IRedisClient redis = _redisManager.GetClient();
			var leaderboards = redis.As<Leaderboard>();
			leaderboards.Store(leaderboard);
		}

		public List<Leaderboard> GetAllLeaderboards()
		{
			IRedisClient redis = _redisManager.GetClient();
			var leaderboards = redis.As<Leaderboard>();
			IList<Leaderboard> result = leaderboards.GetAll();
			return (List<Leaderboard>) result;
		}

		public Leaderboard GetLeaderboardById(long id)
		{
			IRedisClient redis = _redisManager.GetClient();
			var leaderboards = redis.As<Leaderboard>();
			Leaderboard result = leaderboards.GetById(id);
			return result;
		}

		public void DeleteLeaderboardById(long id)
		{
			IRedisClient redis = _redisManager.GetClient();
			var leaderboards = redis.As<Leaderboard>();
			leaderboards.DeleteById(id);
		}
	}
}
