using System;
using AIssist.Domain.Entities;
using AIssist.Domain.Services.Interfaces;
using Supabase;

namespace AIssist.Domain.Services
{
	public class LogService : ILogService
	{
        private readonly Client _supabaseclient;

        public LogService(Client supabaseclient)
		{
			_supabaseclient = supabaseclient;
		}

        public async Task<List<Logs>> Get()
        {
            var result = await _supabaseclient
                .From<Logs>()
                .Get();

            return result.Models;
        }

        public async Task Add(Logs entity)
        {
            await _supabaseclient
                .From<Logs>()
                .Insert(entity);

        }
    }
}

