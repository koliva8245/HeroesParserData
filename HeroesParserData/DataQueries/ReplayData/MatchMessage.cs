﻿using HeroesParserData.Models.DbModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesParserData.DataQueries.ReplayData
{
    public static partial class Query
    {
        internal static class MatchMessage
        {
            public static long CreateRecord(ReplayMatchMessage replayMatchMessage)
            {
                using (var db = new HeroesParserDataContext())
                {
                    db.ReplayMatchMessages.Add(replayMatchMessage);
                    db.SaveChanges();
                }

                return replayMatchMessage.ReplayId;
            }

            public static long CreateRecord(HeroesParserDataContext db, ReplayMatchMessage replayMatchMessage)
            {
                db.ReplayMatchMessages.Add(replayMatchMessage);
                db.SaveChanges();

                return replayMatchMessage.ReplayId;
            }

            public static List<ReplayMatchMessage> ReadAllRecords()
            {
                using (var db = new HeroesParserDataContext())
                {
                    return db.ReplayMatchMessages.ToList();
                }
            }

            public static async Task<List<ReplayMatchMessage>> ReadAllRecordsAsync()
            {
                using (var db = new HeroesParserDataContext())
                {
                    return await db.ReplayMatchMessages.ToListAsync();
                }
            }

            public static async Task<List<ReplayMatchMessage>> ReadTop100RecordsAsync()
            {
                using (var db = new HeroesParserDataContext())
                {
                    return await db.ReplayMatchMessages.Take(100).ToListAsync();
                }
            }

            public static async Task<List<ReplayMatchMessage>> ReadLast100RecordsAsync()
            {
                using (var db = new HeroesParserDataContext())
                {
                    return await db.ReplayMatchMessages.OrderByDescending(x => x.ReplayId).Take(100).ToListAsync();
                }
            }

            public static async Task<List<ReplayMatchMessage>> ReadRecordsCustomTopAsync(int count, string columnName, string orderBy)
            {
                if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(orderBy))
                    return new List<ReplayMatchMessage>();

                if (count == 0)
                    count = 1;

                using (var db = new HeroesParserDataContext())
                {
                    return await db.ReplayMatchMessages.SqlQuery($"SELECT TOP {count} * FROM dbo.ReplayMatchMessages ORDER BY {columnName} {orderBy}").ToListAsync();
                }
            }

            public static async Task<List<ReplayMatchMessage>> ReadRecordsWhereAsync(string columnName, string operand, string input)
            {
                if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(operand))
                    return new List<ReplayMatchMessage>();

                if (input == null)
                    input = string.Empty;

                using (var db = new HeroesParserDataContext())
                {
                    return await db.ReplayMatchMessages.SqlQuery($"SELECT * FROM dbo.ReplayMatchMessages WHERE {columnName} {operand} @Input", new SqlParameter("@Input", input)).ToListAsync();
                }
            }
        }
    }
}