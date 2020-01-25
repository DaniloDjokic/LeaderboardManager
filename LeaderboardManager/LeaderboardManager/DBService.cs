using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
				redis.RemoveEntry(leaderboards.GetById(id).Name); //deletes sorted set of entries for leaderboard

				var relatedEntities = leaderboards.GetRelatedEntities<Entry>(id);
				var entities = redis.As<Entry>();
				foreach (var entity in relatedEntities)
				{
					entities.DeleteById(entity.Id);
				}

				leaderboards.DeleteRelatedEntities<Entry>(id);
				leaderboards.DeleteById(id);
				
			}
		}

		public void AddNewEntry(Leaderboard leaderboard, Entry entry)
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				var leaderboards = redis.As<Leaderboard>();
				var entries = redis.As<Entry>();
				entry.Id = entries.GetNextSequence();

				leaderboards.StoreRelatedEntities(leaderboard.Id, entry);
				redis.AddItemToSortedSet(leaderboard.Id.ToString(), entry.Name, entry.Points);
				
			}
		}

		public IDictionary<string, double> GetEntries(long leaderboardId)
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				IDictionary<string, double> entries = redis.GetRangeWithScoresFromSortedSetByHighestScore(leaderboardId.ToString(), 0, Double.MaxValue);
				return entries;
			}
		}

		public List<Entry> GetFullEntries(long leaderboardId)
		{
			using (IRedisClient redis = _redisManager.Value.GetClient())
			{
				var leaderboards = redis.As<Leaderboard>();
				List<Entry> fullEntries = leaderboards.GetRelatedEntities<Entry>(leaderboardId);
				IDictionary<string, double> entries = redis.GetRangeWithScoresFromSortedSetByHighestScore(leaderboardId.ToString(), 0, Double.MaxValue);
				List<Entry> sortedEntries = fullEntries.OrderByDescending(e => e.Points).ToList();

				return sortedEntries;
			}
		}
	}
}
