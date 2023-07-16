using Microsoft.EntityFrameworkCore;
using Toy.Infrastructure.Contexts;

namespace Toy.Application.Services.Initialize;

public class DbInitializeService
{
    private readonly SolutionContext _solutionContext;

    public DbInitializeService(SolutionContext solutionContext)
    {
        _solutionContext = solutionContext;
    }

    public async Task ExecuteAsync()
    {
        var database = _solutionContext.Database;
        
        var isConnected = await database.CanConnectAsync();
        if (isConnected)
        {
            await database.EnsureDeletedAsync();
        }

        await database.EnsureCreatedAsync();

        var createViewQuery = @"
-- https://learn.microsoft.com/ko-kr/sql/t-sql/statements/create-materialized-view-as-select-transact-sql?view=azure-sqldw-latest

CREATE VIEW NoticeSearchView WITH SCHEMABINDING AS
SELECT
    Notice.Id,
    Notice.Title,
    Notice.StartDate,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel1' THEN 1 ELSE 0 END) AS BIT) AS IsChannel01,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel2' THEN 1 ELSE 0 END) AS BIT) AS IsChannel02,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel3' THEN 1 ELSE 0 END) AS BIT) AS IsChannel03,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel4' THEN 1 ELSE 0 END) AS BIT) AS IsChannel04,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel5' THEN 1 ELSE 0 END) AS BIT) AS IsChannel05,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel6' THEN 1 ELSE 0 END) AS BIT) AS IsChannel06,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel7' THEN 1 ELSE 0 END) AS BIT) AS IsChannel07,
    CAST(MAX(CASE WHEN Channel.Code = 'Channel8' THEN 1 ELSE 0 END) AS BIT) AS IsChannel08
FROM
   dbo.Notice as Notice
   LEFT JOIN
      dbo.NoticeChannel as NoticeChannel
      ON Notice.Id = NoticeChannel.NoticeId 
   LEFT JOIN
      dbo.Channel as Channel
      ON Channel.Id = NoticeChannel.ChannelId
GROUP BY
    Notice.Id, 
    Notice.Title, 
    Notice.StartDate
";

        await database.ExecuteSqlRawAsync(createViewQuery);
    }
}