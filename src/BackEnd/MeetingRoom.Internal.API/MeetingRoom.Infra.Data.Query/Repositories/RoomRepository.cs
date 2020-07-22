using Dapper;
using MeetingRoom.Infra.Data.Query.Interfaces;
using MeetingRoom.Infra.Data.Query.Queries.DTO;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IDbConnection _dbConnection;


        public RoomRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<RoomDto>> GetAsync(string name)
        {
            var sql = "SELECT Id, [Name], [Description] FROM Room " +
                "where @Name is null or @Name = [Name]";

            var result = await _dbConnection.QueryAsync<RoomDto>(
                sql,
                param: new
                {
                    Name = name
                },
                commandType: CommandType.Text);

            return result;
        }

    }
}
