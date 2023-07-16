using Microsoft.EntityFrameworkCore;
using Toy.Domain.Notices;
using Toy.Infrastructure.Contexts;

namespace Toy.Application.Services.Notices;

public class NoticeQueryService
{
    private readonly SolutionContext _context;

    public NoticeQueryService(SolutionContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notice>> GetPagedCollectionAsync(NoticeQueryParameter parameter)
    {
        IQueryable<Notice> query = _context.Notices;

        query = AppendQuery(query, parameter);

        return await query
            .Skip(parameter.PageSize * (parameter.PageNumber - 1))
            .Take(parameter.PageSize)
            .ToListAsync();
    }
    
    public async Task<int> GetTotalCountAsync(NoticeQueryParameter parameter)
    {
        IQueryable<Notice> query = _context.Notices;

        query = AppendQuery(query, parameter);
        
        var totalCount = await query.CountAsync();

        return totalCount;
    }
    
    private static IQueryable<Notice> AppendQuery(
        IQueryable<Notice> query,
        NoticeQueryParameter parameter)
    {
        if (parameter.Channels.Any())
        {
            query = query.Include(
                notice => notice.Channels.Where(
                    channel => parameter.Channels.Contains(channel.Code)));
        }
        else
        {
            query = query.Include(notice => notice.Channels);
        }

        if (parameter.StartToDate.HasValue)
        {
            query = query.Where(notice => parameter.StartFromDate <= notice.StartDate);
        }

        if (parameter.StartFromDate.HasValue)
        {
            query = query.Where(notice => parameter.StartFromDate <= notice.StartDate);
        }

        if (!string.IsNullOrEmpty(parameter.TitleKeyword))
        {
            query = query.Where(notice => notice.Title.Contains(parameter.TitleKeyword));
        }

        query = query.OrderByDescending(notice => notice.StartDate)
            .ThenByDescending(notice => notice.Id);
        return query;
    }
    
    // 최적화한 쿼리
    /*
    SELECT
        Notice.Id,
        Notice.Title,
        Notice.StartDate
    FROM
       dbo.Notice as Notice
       LEFT JOIN
          dbo.NoticeChannel as NoticeChannel
          ON Notice.Id = NoticeChannel.NoticeId 
       LEFT JOIN
          dbo.Channel as Channel
          ON Channel.Id = NoticeChannel.ChannelId
    WHERE
        Channel.Code IN ('Channel1')
    GROUP BY
        Notice.Id, 
        Notice.Title, 
        Notice.StartDate     
    */
}